/**************************************************Issue 4700 Laxman **************************************************/
CREATE OR REPLACE PROCEDURE rpt_branch_collection_summ
   (pcompcode           in varchar2,
    pcenter             in varchar2,
    punitcode           in varchar2,
    pdatefrom           in varchar2,
    pdateto             in varchar2,
    ppaymode            in varchar2,
    pagency_type        in varchar2,
    pzonecode           in varchar2,
    pregioncode         in varchar2,
    pstatecode          in varchar2,
    pdistcode           in varchar2,
    ptalukacode         in varchar2,
    pcitycode           in varchar2,
    pbased_on           in varchar2,--branch based on
    puserid             in varchar2,
    pdateformat         in varchar2,
    pextra1             in varchar2,
    pextra2             in varchar2,
    pextra3             in varchar2,
    pextra4             in varchar2,
    pextra5             in varchar2,
    p_accounts          OUT Cur_Type_New1.cursor_type)
IS
    v_frdt      date; 
    v_todt      date;
    
    v_query varchar2(8000);
     cursor cur_paymode is
        select distinct x.unit as "UNIT",x.unit_name AS "UNIT_NAME"
        from (select distinct h."unit" unit,b."Branch_Name" unit_name
        from agency_mast m,ad_rcpthdr h ,branch_mst b
        where h."comp_code"=pcompcode and h."unit"=b."Branch_Code" and (h."unit"=punitcode or punitcode is null) and h."doctype" in('RCR','RCP') and 
              h."recptdt" between v_frdt and v_todt and h."ag_main_code"=m."Agency_Code" and h."ag_sub_code"=m."SUB_Agency_Code" and
              (h."reason"=ppaymode or ppaymode is null) and (m."Agency_Type_Code"=pagency_type or pagency_type is null) and
              (m."City_Code"=pcitycode or pcitycode is null) and (m.state=pstatecode or pstatecode is null) and
              (m.district=pdistcode or pdistcode is null) and (m."region"=pregioncode or pregioncode is null) and
              (m."zone_code"=pzonecode or pzonecode is null) and (b."pub_center"=pcenter or pcenter is null))x      
              order by unit_name;

    rec_paymode cur_paymode%rowtype;
         
    v_var       varchar2(4000);
    v_var_sum   varchar2(4000);
Begin
    v_frdt      := to_date(pdatefrom,''''||pdateformat||'''');
    v_todt      := to_date(pdateto,''''||pdateformat||'''');

    open cur_paymode;
    loop
      fetch cur_paymode into rec_paymode;
      exit when cur_paymode%notfound;
        if v_var is null then
            v_var       :='case when h."unit"='||''''||rec_paymode.unit||''''||' then abs(h."amount") else 0 end "'||rec_paymode.unit||'"';
            v_var_sum   :='round(sum("'||rec_paymode.unit||'"),2)'||' "'||rec_paymode.unit||'"';
        else
            v_var       :=v_var||','||'case when h."unit"='||''''||rec_paymode.unit||''''||' then abs(h."amount") else 0 end "'||rec_paymode.unit||'"';
            v_var_sum   :=v_var_sum||','||'round(sum("'||rec_paymode.unit||'"),2)'||' "'||rec_paymode.unit||'"';
        end if;            
    end loop;
    close cur_paymode;

        
    if v_var is null then
        v_query:='select distinct x.comp_code comp_code,(select "Comp_Name" from comp_mst where "Comp_Code"=x.comp_code) COMP_NAME,
        x.recptdt recptdt,sum(amount) amount
        from(select h."comp_code" comp_code,h."unit" unit,h."recptdt" recptdt,h."amount" amount from agency_mast m,ad_rcpthdr h ,branch_mst b
    where h."comp_code"='||''''||pcompcode||''''||' and h."unit"=b."Branch_Code" and (h."unit"='||''''||punitcode||''''||' or '||''''||punitcode||''''||' is null) and h."doctype" in(''RCR'',''RCP'') and  
          h."recptdt" between '||''''||v_frdt||''''||' and '||''''||v_todt||''''||' and h."ag_main_code"=m."Agency_Code" and h."ag_sub_code"=m."SUB_Agency_Code" and
          (h."reason"='||''''||ppaymode||''''||' or '||''''||ppaymode||''''||' is null) and (m."Agency_Type_Code"='||''''||pagency_type||''''||' or '||''''||pagency_type||''''||' is null) and 
          (m."City_Code"='||''''||pcitycode||''''||' or '||''''||pcitycode||''''||' is null) and 
          (m.state='||''''||pstatecode||''''||' or '||''''||pstatecode||''''||' is null) and (m.district='||''''||pdistcode||''''||' or '||''''||pdistcode||''''||' is null) and
          (m."region"='||''''||pregioncode||''''||' or '||''''||pregioncode||''''||' is null) and (m."zone_code"='||''''||pzonecode||''''||' or '||''''||pzonecode||''''||' is null) and
          (m.taluka='||''''||ptalukacode||''''||' or '||''''||ptalukacode||''''||' is null) and
          (b."pub_center"='||''''||pcenter||''''||' or '||''''||pcenter||''''||' is null)) x
        group by x.comp_code,x.recptdt
        order by comp_code,recptdt';
    else
        v_query:='select distinct x.comp_code comp_code,(select "Comp_Name" from comp_mst where "Comp_Code"=x.comp_code) COMP_NAME,x.recptdt recptdt,
        '||v_var_sum||',sum(amt) total from(select h."comp_code" comp_code,h."unit" unit,h."recptdt" recptdt,'||v_var||',abs(h."amount") amt from agency_mast m,ad_rcpthdr h ,branch_mst b
        where h."comp_code"='||''''||pcompcode||''''||' and h."unit"=b."Branch_Code" and (h."unit"='||''''||punitcode||''''||' or '||''''||punitcode||''''||' is null) and h."doctype" in(''RCR'',''RCP'') and  
          h."recptdt" between '||''''||v_frdt||''''||' and '||''''||v_todt||''''||' and h."ag_main_code"=m."Agency_Code" and h."ag_sub_code"=m."SUB_Agency_Code" and
          (h."reason"='||''''||ppaymode||''''||' or '||''''||ppaymode||''''||' is null) and (m."Agency_Type_Code"='||''''||pagency_type||''''||' or '||''''||pagency_type||''''||' is null) and 
          (m."City_Code"='||''''||pcitycode||''''||' or '||''''||pcitycode||''''||' is null) and 
          (m.state='||''''||pstatecode||''''||' or '||''''||pstatecode||''''||' is null) and (m.district='||''''||pdistcode||''''||' or '||''''||pdistcode||''''||' is null) and
          (m."region"='||''''||pregioncode||''''||' or '||''''||pregioncode||''''||' is null) and (m."zone_code"='||''''||pzonecode||''''||' or '||''''||pzonecode||''''||' is null) and
          (m.taluka='||''''||ptalukacode||''''||' or '||''''||ptalukacode||''''||' is null) and
          (b."pub_center"='||''''||pcenter||''''||' or '||''''||pcenter||''''||' is null)) x
        group by x.comp_code,x.recptdt
        order by comp_code,recptdt';
    end if;
        
    --delete test1;insert into test1(vstring,vstring2) values('rpt_branch_collection_summ1',v_query);commit;
    open p_accounts for v_query;

End rpt_branch_collection_summ;
/
/**************************************************Issue 4700 **************************************************/
/**************************************************Anupama 14/9/11 Issue 4702 **************************************************/
CREATE OR REPLACE PROCEDURE rpt_weekwise_billing_summ
   (pcompcode           in varchar2,
    pcenter             in varchar2,
    pbranchcode         in varchar2,
    ppublcode           in varchar2,
    pdatefrom           in varchar2,
    pdateto             in varchar2,
    puserid             in varchar2,
    pdateformat         in varchar2,
    pdate_basedon       in number,----for booking date(1),publish date(2) or on billing date(3)
    pextra1             in varchar2,
    pextra2             in varchar2,
    pextra3             in varchar2,
    pextra4             in varchar2,
    pextra5             in varchar2,
    pextra6             in varchar2,
    pextra7             in varchar2,
    pextra8             in varchar2,
    pextra9             in varchar2,
    pextra10            in varchar2,    
    p_accounts          OUT Cur_Type_New1.cursor_type,
    p_accounts1         OUT Cur_Type_New1.cursor_type)
IS
    v_frdt      date; 
    v_todt      date;
        
    v_query             varchar2(8000);
    rec_v1_comp_code    varchar2(20);
    rec_v1_pcenter      varchar2(20);
    rec_v1_branch_code  varchar2(20);
    rec_v1_branch_name  varchar2(200);
    rec_v1_bill_date    date;
    rec_v1_publ_code    varchar2(20);
    rec_v1_publ_name    varchar2(200);
    rec_v1_ad_cat       varchar2(200);
    rec_v1_adcat_name   varchar2(200);
    rec_v1_insertion_no number(10);
    rec_v1_amount       number(18,2);
    v_week_name         varchar2(10);
     cursor c1 is
        select x.comp_code,x.pub_center,x.branch_code,x.branch_name, x.bill_date ,x.publ_code,x.publ_name,
        x.ad_cat,x.adcat_name,x.insertion_no,nvl(x.amount,0) from
        (select m."Comp_code" comp_code,b."pub_center" pub_center,b."Branch_Code" branch_code,b."Branch_Name" branch_name,m."date_time" bill_date,
        i."Publication_Code" publ_code,(select pub_mast."Pub_Name" from pub_mast where pub_mast."Pub_Code"=i."Publication_Code") publ_name,
        i."Ad_Cat" ad_cat,c."Adv_Cat_Name" adcat_name,
        count(i."No_Insert") insertion_no,round(Sum(i."Bill_Amt"),2) amount
        from agency_mast a,tbl_booking_mast m,tbl_booking_insert i,branch_mst b,adv_cat_mast c
        where m."Comp_code"=i."Comp_Code" and m."Comp_code"=pcompcode and c."Comp_Code"=m."Comp_code" and c."Adv_Cat_Code"=i."Ad_Cat" and 
        m."cio_booking_id"=i."Cio_Booking_Id" and a."Agency_Code"||a."SUB_Agency_Code"=m."Agency_sub_code" and 
        m."date_time" between v_frdt and v_todt and  
        --new version
        --m."branch"=b."Branch_Code" and
        --old version 
        m."branch"=b."Branch_Name" and
        (b."Branch_Code"=pbranchcode or pbranchcode is null) and (b."pub_center"=pcenter or pcenter is null) and
        (i."Publication_Code"=ppublcode or ppublcode is null) and pdate_basedon=1
        group by m."Comp_code",b."pub_center",b."Branch_Code",b."Branch_Name",m."date_time",i."Publication_Code",i."Ad_Cat",c."Adv_Cat_Name"
        union 
        select m."Comp_code" comp_code,b."pub_center" pub_center,b."Branch_Code" branch_code,b."Branch_Name" branch_name,i."Insert_Date" bill_date,
        i."Publication_Code" publ_code,(select pub_mast."Pub_Name" from pub_mast where pub_mast."Pub_Code"=i."Publication_Code") publ_name,
        i."Ad_Cat" ad_cat,c."Adv_Cat_Name" adcat_name,
        count(i."No_Insert") insertion_no,round(Sum(i."Bill_Amt"),2) amount
        from agency_mast a,tbl_booking_mast m,tbl_booking_insert i,branch_mst b,adv_cat_mast c
        where m."Comp_code"=i."Comp_Code" and m."Comp_code"=pcompcode and c."Comp_Code"=m."Comp_code" and c."Adv_Cat_Code"=i."Ad_Cat" and 
        m."cio_booking_id"=i."Cio_Booking_Id" and a."Agency_Code"||a."SUB_Agency_Code"=m."Agency_sub_code" and 
        i."Insert_Date" between v_frdt and v_todt and  
        --new version
        --m."branch"=b."Branch_Code" and
        --old version 
        m."branch"=b."Branch_Name" and
        (b."Branch_Code"=pbranchcode or pbranchcode is null) and (b."pub_center"=pcenter or pcenter is null) and
        (i."Publication_Code"=ppublcode or ppublcode is null) and pdate_basedon=2
        group by m."Comp_code",b."pub_center",b."Branch_Code",b."Branch_Name",i."Insert_Date",i."Publication_Code",i."Ad_Cat",c."Adv_Cat_Name"
        union 
        select m."Comp_code" comp_code,b."pub_center" pub_center,b."Branch_Code" branch_code,b."Branch_Name" branch_name,i.bill_date bill_date,
        i."Publication_Code" publ_code,(select pub_mast."Pub_Name" from pub_mast where pub_mast."Pub_Code"=i."Publication_Code") publ_name,
        i."Ad_Cat" ad_cat,c."Adv_Cat_Name" adcat_name,
        count(i."No_Insert") insertion_no,round(Sum(i."Bill_Amt"),2) amount
        from agency_mast a,tbl_booking_mast m,tbl_booking_insert i,branch_mst b,adv_cat_mast c
        where m."Comp_code"=i."Comp_Code" and m."Comp_code"=pcompcode and c."Comp_Code"=m."Comp_code" and c."Adv_Cat_Code"=i."Ad_Cat" and 
        m."cio_booking_id"=i."Cio_Booking_Id" and a."Agency_Code"||a."SUB_Agency_Code"=m."Agency_sub_code" and 
        i.bill_date between v_frdt and v_todt and 
        --new version
        --m."branch"=b."Branch_Code" and
        --old version 
        m."branch"=b."Branch_Name" and
        (b."Branch_Code"=pbranchcode or pbranchcode is null) and (b."pub_center"=pcenter or pcenter is null) and
        (i."Publication_Code"=ppublcode or ppublcode is null) and pdate_basedon=3
        group by m."Comp_code",b."pub_center",b."Branch_Code",b."Branch_Name",i.bill_date,i."Publication_Code",i."Ad_Cat",c."Adv_Cat_Name"        ) x;

    v_rec_seqno number(10);
    
    cursor c11 is
            select distinct doctype from temp_ad_receipt_report  
                where sess_id=userenv('sessionid') order by doctype;
    v_var       varchar2(4000);
    v_var_sum   varchar2(4000);
Begin
    v_frdt      := to_date(pdatefrom,''''||pdateformat||'''');
    v_todt      := to_date(pdateto,''''||pdateformat||'''');

    delete from temp_ad_receipt_report where sess_id=userenv('sessionid');
    open c1;
    loop
        fetch c1 into rec_v1_comp_code,rec_v1_pcenter,rec_v1_branch_code,rec_v1_branch_name,rec_v1_bill_date,rec_v1_publ_code,rec_v1_publ_name,rec_v1_ad_cat,rec_v1_adcat_name,rec_v1_insertion_no,rec_v1_amount;
        exit when c1%notfound;
        v_rec_seqno:=nvl(v_rec_seqno,0)+1;
        
        v_week_name:='WEEK'||floor(((rec_v1_bill_date-v_frdt)/7)+1);
        
        insert into temp_ad_receipt_report
            (comp_code,unit_code,pcentre_code,recptdt,exe_code,ad_main_category,ret_code,ad_sub_category,recovary_days,
             amount,rec_seqno,debit_head,doctype)
        values(rec_v1_comp_code,rec_v1_branch_code,rec_v1_pcenter,rec_v1_bill_date,rec_v1_ad_cat,rec_v1_adcat_name,rec_v1_publ_code,rec_v1_publ_name,rec_v1_insertion_no,
                rec_v1_amount,v_rec_seqno,rec_v1_branch_name,v_week_name);
    end loop;
    close c1;
    commit;
    
    v_week_name:=null;
    
    open c11;
    loop
        fetch c11 into v_week_name;
        exit when c11%notfound;
            if v_var is null then
                v_var       :='case when d.doctype='||''''||v_week_name||''''||' then d.recovary_days else 0 end "'||'R#'||v_week_name||'"';
                v_var       :=v_var||','||'case when d.doctype='||''''||v_week_name||''''||' then d.amount else 0 end "'||'A#'||v_week_name||'"';
                v_var_sum   :='round(sum("'||'R#'||v_week_name||'"),2)'||' "'||'R#'||v_week_name||'"';
                v_var_sum   :=v_var_sum||','||'sum("'||'A#'||v_week_name||'")'||' "'||'A#'||v_week_name||'"';
            else
                v_var       :=v_var||','||'case when d.doctype='||''''||v_week_name||''''||' then d.recovary_days else 0 end "'||'R#'||v_week_name||'"';
                v_var       :=v_var||','||'case when d.doctype='||''''||v_week_name||''''||' then d.amount else 0 end "'||'A#'||v_week_name||'"';
                v_var_sum   :=v_var_sum||','||'round(sum("'||'R#'||v_week_name||'"),2)'||' "'||'R#'||v_week_name||'"';
                v_var_sum   :=v_var_sum||','||'sum("'||'A#'||v_week_name||'")'||' "'||'A#'||v_week_name||'"';
            end if;
     end loop;
     close c11;

        
    if v_var is null then
        v_query:='select x.comp_code as "COMP_CODE",(select "Comp_Name" from comp_mst where "Comp_Code"=x.comp_code) COMP_NAME,x.branch_code branch_code,x.branch_name branch_name,
        x.publ_code publ_code,x.publ_name publ_name,
        round(sum("AMOUNT"),2) as "TOTOL",  sum("NO_OF_INSERT") as "NO_OF_INSERT" from
        (select d.comp_code,d.unit_code branch_code,d.debit_head branch_name,d.ret_code publ_code,d.ad_sub_category publ_name,
       nvl(d.recovary_days,0) no_of_insert,nvl(d.amount,0) amount from temp_ad_receipt_report d where sess_id='||userenv('sessionid')||') x 
       group by x.comp_code,x.publ_code,x.publ_name,x.branch_code,x.branch_name order by x.comp_code,x.branch_name,x.publ_name,x.publ_code';
    else
       v_query:='select x.comp_code as "COMP_CODE",(select "Comp_Name" from comp_mst where "Comp_Code"=x.comp_code) COMP_NAME,x.branch_code branch_code,x.branch_name branch_name,
        x.publ_code publ_code,x.publ_name publ_name,
        '||v_var_sum||' ,round(sum("AMOUNT"),2) as "TOTOL",  sum("NO_OF_INSERT") as "NO_OF_INSERT" from
        (select d.comp_code,d.unit_code branch_code,d.debit_head branch_name,d.ret_code publ_code,d.ad_sub_category publ_name,
       '||v_var||',nvl(d.recovary_days,0) no_of_insert,nvl(d.amount,0) amount from temp_ad_receipt_report d where sess_id='||userenv('sessionid')||') x 
       group by x.comp_code,x.publ_code,x.publ_name,x.branch_code,x.branch_name order by x.comp_code,x.branch_name,x.publ_name,x.publ_code';
    end if;
        
    --delete test1;insert into test1(vstring,vstring2) values('rpt_categ_billing_summ1',v_query);commit;
        
    open p_accounts for v_query;
        
    if v_var is null then
        v_query:='select x.comp_code as "COMP_CODE",(select "Comp_Name" from comp_mst where "Comp_Code"=x.comp_code) COMP_NAME,x.branch_code branch_code,x.branch_name branch_name,
        round(sum("AMOUNT"),2) as "TOTOL",  sum("NO_OF_INSERT") as "NO_OF_INSERT" from
        (select d.comp_code,d.unit_code branch_code,d.debit_head branch_name,d.ret_code publ_code,d.ad_sub_category publ_name,
       nvl(d.recovary_days,0) no_of_insert,nvl(d.amount,0) amount from temp_ad_receipt_report d where sess_id='||userenv('sessionid')||') x 
       group by x.comp_code,x.branch_code,x.branch_name order by x.comp_code,x.branch_name';
    else
        v_query:='select x.comp_code as "COMP_CODE",(select "Comp_Name" from comp_mst where "Comp_Code"=x.comp_code) COMP_NAME,x.branch_code branch_code,x.branch_name branch_name,
        '||v_var_sum||' ,round(sum("AMOUNT"),2) as "TOTOL",  sum("NO_OF_INSERT") as "NO_OF_INSERT" from
        (select d.comp_code,d.unit_code branch_code,d.debit_head branch_name,d.ret_code publ_code,d.ad_sub_category publ_name,
       '||v_var||',nvl(d.recovary_days,0) no_of_insert,nvl(d.amount,0) amount from temp_ad_receipt_report d where sess_id='||userenv('sessionid')||') x 
       group by x.comp_code,x.branch_code,x.branch_name order by x.comp_code,x.branch_name';
    end if;

    --insert into test1(vstring,vstring2) values('rpt_categ_billing_summ2',v_query);commit;

    open p_accounts1 for v_query;
    --delete from temp_ad_receipt_report where sess_id=userenv('sessionid');commit;
End rpt_weekwise_billing_summ;
/
/**************************************************Anupama 14/9/11 Issue 4702 **************************************************/
/**************************************************Mimoh 14/9/11 Issue 4682,4569 **************************************************/
CREATE OR REPLACE PACKAGE BODY execcontactbind_grid is
procedure execcontactbind_grid_p(
teamcode in varchar2,
compcode in varchar2,
userid in varchar2,
P_Accounts out T_Accounts_Cursor)

as


--variables declaration

Designation1 varchar2(350);
Country_code1 varchar2(520);
city_code1 varchar2(250);
report_to1 varchar2(250);
Exec_name  varchar2(350);
Designation varchar2(350);
Add1 varchar2(505);
Street varchar2(505);
city_code varchar2(458);
dist_code varchar2(158);
State_code varchar2(158);
Country_code  varchar2(485);
pin_code varchar2(205);
phone varchar2(350);
exe_status varchar2(520);
Exe_no varchar2(205);
city_name varchar2(250);
Team_code varchar2(358);
zip varchar2(105);
comp_code varchar2(58);
report_to varchar2(385);
creation_datetime varchar2(105);
TALUKA_V VARCHAR2(100);
REPRESENTATIVE_V VARCHAR2(100);
 TALUKA_V_NEW VARCHAR2(100);

 REPRESENTATIVE_V_NEW VARCHAR2(100);
Branch_code_v varchar(50);
Branch_Name varchar(100);


--variables ended



--SELECT * FROM TAB WHERE UPPER(TNAME) LIKE '%ADV%'




begin

	DECLARE CURSOR sss is

	select distinct  "Designation","city_code","Country_code","report_to","Exe_no",TALUKA, REPRESENTATIVE,"Branch_code" from Exec_mast
	where "comp_code"=compcode  and "Team_code"=teamcode;


	begin
		OPEN sss;
			loop
				FETCH sss into Designation,city_code,Country_code,report_to,Exe_no,TALUKA_V, REPRESENTATIVE_V,Branch_code_v;
				exit when sss%notfound;


				begin
					select "Agency_Role_Name" into Designation1 from Agency_Role_Master
					where "Agency_Role_Code"=Designation;
					EXCEPTION
					WHEN NO_DATA_FOUND THEN
					  NULL;
				end;

				begin
					select "City_Name" into city_code1 from city_mst where "City_Code"=city_code;
					EXCEPTION
					WHEN NO_DATA_FOUND THEN
					  NULL;
				end;
                
                begin
					select "Branch_Name" into Branch_Name from branch_mst where "Branch_Code"=Branch_code_v;
					EXCEPTION
					WHEN NO_DATA_FOUND THEN
					  NULL;
				end;


				begin
					select "Country_Name" into Country_code1 from count_mst where "Country_Code"=Country_code;
					EXCEPTION
					WHEN NO_DATA_FOUND THEN
					   NULL;
				end;
				if(report_to<>'0') then
					begin
						select "Name_all" into report_to1 from all_module_master where "All_module_code"=report_to;
   						EXCEPTION
						WHEN NO_DATA_FOUND THEN
						NULL;
					end;
					else
    					report_to1:=null;
 			    end if;



				begin

					select TALU_NAME into TALUKA_V_NEW from taluka_mast where TALU_CODE=TALUKA_V;
					EXCEPTION
					WHEN NO_DATA_FOUND THEN
					   NULL;
				end;


				begin

					select "Rep_Name" into REPRESENTATIVE_V_NEW from REP_MAST where "Rep_code"=REPRESENTATIVE_V;
					EXCEPTION
					WHEN NO_DATA_FOUND THEN
					   NULL;
				end;







BEGIN

					insert into temp_adv_NEW1 select distinct "Exe_no","Team_code","Exec_name",Designation1,"Add1","Street"
					,Country_code1,"State_code","dist_code",city_code1,"zip","phone","exe_status","userid","comp_code",
					"pin_code","CIty_Name",report_to1, TALUKA_V_NEW, REPRESENTATIVE_V_NEW,Branch_Name from Exec_mast where "comp_code"=compcode  and "Team_code" =teamcode
					and "Exe_no"=Exe_no;

				exception
				when no_data_found then
					 null;


			     end;
				/*open P_Accounts for
			select *  from temp_adv;*/



			end loop;





		CLOSE sss;
		  open P_Accounts for
			--select EXE_NO, TEAM_CODE, EXEC_NAME, DESIGNATION, ADD1, STREET, COUNTRY_CODE, STATE_CODE, DIST_CODE, CITY_CODE, ZIP, PHONE, EXE_STATUS, USERID, COMP_CODE, PIN_CODE, CITY_NAME, BRANCH_CODE, REPORT_TO, TALUKA, REPNAME  from temp_adv_NEW1;
            select distinct EXE_NO,EXEC_NAME, DESIGNATION,ADD1,STREET, CITY_CODE,DIST_CODE,STATE_CODE, COUNTRY_CODE,PIN_CODE,PHONE,EXE_STATUS,EXE_NO,CITY_NAME,BRANCH_CODE,REPORT_TO ,TALUKA ,REPNAME  from temp_adv_NEW1;
			delete  temp_adv_NEW1;
	end;

end execcontactbind_grid_p;
end execcontactbind_grid;
/

/**************************************************Mimoh 14/9/11 Issue 4682,4569 **************************************************/
/**************************************************Mimoh 15/9/11 Issue 4912 **************************************************/


CREATE OR REPLACE PACKAGE          websp_agencymodify
IS
   PROCEDURE websp_agencymodify_p (
      compcode             IN   VARCHAR2,
      agencytype           IN   VARCHAR2,
      agentcategory        IN   VARCHAR2,
      agentcategory2       IN   VARCHAR2,
      agentcode            IN   VARCHAR2,
      agentname            IN   VARCHAR2,
      alias                IN   VARCHAR2,
      agencyho             IN   VARCHAR2,
      TYPE1                 IN   VARCHAR2,
      address              IN   VARCHAR2,
      street               IN   VARCHAR2,
      city                 IN   VARCHAR2,
      zip                  IN   VARCHAR2,
      district1             IN   VARCHAR2,
      state1               IN   VARCHAR2,
      country              IN   VARCHAR2,
      phone                IN   VARCHAR2,
      txtfax2              IN   VARCHAR2,
      fax                  IN   VARCHAR2,
      mail                 IN   VARCHAR2,
      url1                  IN   VARCHAR2,
      bussinessstartdate   IN   DATE,
      enrolldate           IN   DATE,
      novts                IN   VARCHAR2,
      credit               IN   VARCHAR2,
      pan                  IN   VARCHAR2,
      TAN                  IN   VARCHAR2,
      stacno               IN   VARCHAR2,
      paymode              IN   VARCHAR2,
      status               IN   VARCHAR2,
      remarks              IN   VARCHAR2,
      userid               IN   VARCHAR2,
      mrerefferenceno      IN   VARCHAR2,
      subagencyho          IN   VARCHAR2,
      agencycode           IN   VARCHAR2,
      billto               IN   VARCHAR2,
      alert1                IN   VARCHAR2,
      creditlimit          IN   VARCHAR2,
      code                 IN   VARCHAR2,
      region1               IN   VARCHAR2,
      representative       IN   VARCHAR2,
      pincode              IN   VARCHAR2,
      stacno1              IN   VARCHAR2,
      ZONE1                 IN   VARCHAR2,
      address1             IN   VARCHAR2,
      address2             IN   VARCHAR2,
      curtype              IN   VARCHAR2,
      acagen               IN   VARCHAR2,
      rategrp              IN   VARCHAR2,
      qbcuserid            IN   VARCHAR2,
      depocode                IN    VARCHAR2,
      taluka1              IN    VARCHAR2,
      branchcode              IN    VARCHAR2,
      hddistcode in varchar2,
hdstatecode    in varchar2 ,
billf           in varchar2,
oldagen         in varchar2,
booktype1           in varchar2,
vat1    in varchar2
   );
END websp_agencymodify;
/



CREATE OR REPLACE PACKAGE BODY          websp_agencymodify
IS
   PROCEDURE websp_agencymodify_p (
      compcode             IN   VARCHAR2,
      agencytype           IN   VARCHAR2,
      agentcategory        IN   VARCHAR2,
      agentcategory2       IN   VARCHAR2,
      agentcode            IN   VARCHAR2,
      agentname            IN   VARCHAR2,
      alias                IN   VARCHAR2,
      agencyho             IN   VARCHAR2,
      TYPE1                 IN   VARCHAR2,
      address              IN   VARCHAR2,
      street               IN   VARCHAR2,
      city                 IN   VARCHAR2,
      zip                  IN   VARCHAR2,
      district1             IN   VARCHAR2,
      state1                IN   VARCHAR2,
      country              IN   VARCHAR2,
      phone                IN   VARCHAR2,
      txtfax2              IN   VARCHAR2,
      fax                  IN   VARCHAR2,
      mail                 IN   VARCHAR2,
      url1                  IN   VARCHAR2,
      bussinessstartdate   IN   DATE,
      enrolldate           IN   DATE,
      novts                IN   VARCHAR2,
      credit               IN   VARCHAR2,
      pan                  IN   VARCHAR2,
      TAN                  IN   VARCHAR2,
      stacno               IN   VARCHAR2,
      paymode              IN   VARCHAR2,
      status               IN   VARCHAR2,
      remarks              IN   VARCHAR2,
      userid               IN   VARCHAR2,
      mrerefferenceno      IN   VARCHAR2,
      subagencyho          IN   VARCHAR2,
      agencycode           IN   VARCHAR2,
      billto               IN   VARCHAR2,
      alert1                IN   VARCHAR2,
      creditlimit          IN   VARCHAR2,
      code                 IN   VARCHAR2,
      region1               IN   VARCHAR2,
      representative       IN   VARCHAR2,
      pincode              IN   VARCHAR2,
      stacno1              IN   VARCHAR2,
      zone1                IN   VARCHAR2,
      address1             IN   VARCHAR2,
      address2             IN   VARCHAR2,
      curtype              IN   VARCHAR2,
      acagen               IN   VARCHAR2,
      rategrp              IN   VARCHAR2,
      qbcuserid            IN   VARCHAR2,
      depocode                IN    VARCHAR2,
      taluka1              IN    VARCHAR2,
      branchcode               IN    VARCHAR2,
      hddistcode in varchar2,
hdstatecode    in varchar2 ,
billf           in varchar2,
oldagen         in varchar2,
booktype1           in varchar2,
vat1    in varchar2
   )
   AS
   BEGIN
      UPDATE agency_mast
         SET "Rate_Group" = rategrp,
             "Agency_Code" = agentcode,
             "fax1" = txtfax2,
             "CREDIT_TYPE" = curtype,
             "zone_code" = zone1,
             "Type" = TYPE1,
             "Agency_Type_Code" = agencytype,
             "Agency_Cat_Code" = agentcategory,
             "Agency_SubCat_Code" = agentcategory2,
             "Agency_Name" = agentname,
             "Agency_Alias" = alias,
             "Agency_HO" = agencyho,
             "Add1" = address,
             "Street" = street,
             "City_Code" = city,
             "Zip" = zip,
             "Dist_Code" = district1,
             "State_Code" = state1,
             "Country_Code" = country,
             "Phone" = phone,
             "Fax" = fax,
             "EmailID" = mail,
             "URL" = url1,
             "Buss_Start_Date" = bussinessstartdate,
             "Enroll_Date" = enrolldate,
             "MRV_Ref_No" = mrerefferenceno,
             "No_of_VTS" = novts,
             "Credit_Days" = credit,
             "PAN_No" = pan,
             "TAN_No" = TAN,
             "ST_ACC_No" = stacno1,
             "Pay_Mode_Code" = paymode,
             "Status_Reason" = status,
             "Remarks" = remarks,
             "SUB_Agency_HO" = subagencyho,
             "SUB_Agency_Code" = agencycode,
             "BILL_TO" = acagen,
             "acagency" = billto,
             "ALERT" = alert1,
             "CREDIT_LIMIT" = creditlimit,
             "CODE" = code,
             "region" = region1,
             "Representative_code" = representative,
             "pin_code" = pincode,
             "Add2" = address1,
             "Add3" = address2,
             "qbc_userid" = qbcuserid,
             "TALUKA"=taluka1,
             "Branch_code"=branchcode, 

DISTRICT=hddistcode,STATE=hdstatecode,BILL_FREQUENCY=billf,OLD_AGENCY=oldagen,

BOOKING_TYPE=booktype1,VAT=vat1
       WHERE "Comp_Code" = compcode AND "SUB_Agency_Code" = agencycode;

        --UPDATE ad_user SET "DEPO_CODE"=depocode where "AGENCY_CODE"=agentcode;

      COMMIT;
   END websp_agencymodify_p;
END websp_agencymodify;
/


CREATE OR REPLACE PACKAGE          websp_saveagent
IS
   PROCEDURE websp_saveagent_p (
      compcode             IN   VARCHAR2,
      agencytype           IN   VARCHAR2,
      agentcategory        IN   VARCHAR2,
      agentcategory2       IN   VARCHAR2,
      agentcode            IN   VARCHAR2,
      agentname            IN   VARCHAR2,
      alias                IN   VARCHAR2,
      agencyho             IN   VARCHAR2,
      txtfax1              IN   VARCHAR2,
      address              IN   VARCHAR2,
      street               IN   VARCHAR2,
      city                 IN   VARCHAR2,
      district1             IN   VARCHAR2,
      state1                IN   VARCHAR2,
      country              IN   VARCHAR2,
      phone                IN   VARCHAR2,
      fax                  IN   VARCHAR2,
      mail                 IN   VARCHAR2,
      url1                  IN   VARCHAR2,
      bussinessstartdate   IN   DATE,
      enrolldate           IN   DATE,
      novts                IN   VARCHAR2,
      credit               IN   VARCHAR2,
      pan                  IN   VARCHAR2,
      TAN                  IN   VARCHAR2,
      stacno               IN   VARCHAR2,
      paymode              IN   VARCHAR2,
      status               IN   VARCHAR2,
      remarks              IN   VARCHAR2,
      userid               IN   VARCHAR2,
      mrerefferenceno      IN   VARCHAR2,
      subagencyho          IN   VARCHAR2,
      agencycode           IN   VARCHAR2,
      billto               IN   VARCHAR2,
      alert                IN   VARCHAR2,
      creditlimit          IN   VARCHAR2,
      code                 IN   VARCHAR2,
      representative       IN   VARCHAR2,
      pin                  IN   VARCHAR2,
      region1               IN   VARCHAR2,
      TYPE1                 IN   VARCHAR2,
      ZONE1                 IN   VARCHAR2,
      address1             IN   VARCHAR2,
      address2             IN   VARCHAR2,
      curtype              IN   VARCHAR2,
      acagen               IN   VARCHAR2,
      rategrp              IN   VARCHAR2,
      qbcuserid            IN   VARCHAR2,
      taluka1            IN   VARCHAR2,
      branchcode         in varchar2,
      hddistcode            IN   VARCHAR2,
      hdstatecode         in varchar2,
      billf               in varchar2,
      oldagency           in varchar2,
      booktype1           in varchar2,
      vat1                in varchar2
   );
END websp_saveagent;
/



CREATE OR REPLACE PACKAGE BODY          websp_saveagent
IS
   PROCEDURE websp_saveagent_p (
      compcode             IN   VARCHAR2,
      agencytype           IN   VARCHAR2,
      agentcategory        IN   VARCHAR2,
      agentcategory2       IN   VARCHAR2,
      agentcode            IN   VARCHAR2,
      agentname            IN   VARCHAR2,
      alias                IN   VARCHAR2,
      agencyho             IN   VARCHAR2,
      txtfax1              IN   VARCHAR2,
      address              IN   VARCHAR2,
      street               IN   VARCHAR2,
      city                 IN   VARCHAR2,
      district1             IN   VARCHAR2,
      state1                IN   VARCHAR2,
      country              IN   VARCHAR2,
      phone                IN   VARCHAR2,
      fax                  IN   VARCHAR2,
      mail                 IN   VARCHAR2,
      url1                  IN   VARCHAR2,
      bussinessstartdate   IN   DATE,
      enrolldate           IN   DATE,
      novts                IN   VARCHAR2,
      credit               IN   VARCHAR2,
      pan                  IN   VARCHAR2,
      TAN                  IN   VARCHAR2,
      stacno               IN   VARCHAR2,
      paymode              IN   VARCHAR2,
      status               IN   VARCHAR2,
      remarks              IN   VARCHAR2,
      userid               IN   VARCHAR2,
      mrerefferenceno      IN   VARCHAR2,
      subagencyho          IN   VARCHAR2,
      agencycode           IN   VARCHAR2,
      billto               IN   VARCHAR2,
      alert                IN   VARCHAR2,
      creditlimit          IN   VARCHAR2,
      code                 IN   VARCHAR2,
      representative       IN   VARCHAR2,
      pin                  IN   VARCHAR2,
      region1               IN   VARCHAR2,
      TYPE1                 IN   VARCHAR2,
      ZONE1                IN   VARCHAR2,
      address1             IN   VARCHAR2,
      address2             IN   VARCHAR2,
      curtype              IN   VARCHAR2,
      acagen               IN   VARCHAR2,
      rategrp              IN   VARCHAR2,
      qbcuserid            IN   VARCHAR2,
      taluka1            IN   VARCHAR2,
        branchcode         in varchar2,
        hddistcode            IN   VARCHAR2,
      hdstatecode         in varchar2,
      billf               in varchar2,
      oldagency           in varchar2,
      booktype1           in varchar2,
      vat1                in varchar2
   )
   AS
   BEGIN
      INSERT INTO agency_mast
                  ("Comp_Code", "Agency_Type_Code", "Agency_Cat_Code",
                   "Agency_SubCat_Code", "Agency_Code", "Agency_Name",
                   "Agency_Alias", "Agency_HO", "Add1", "Street",
                   "City_Code", "Dist_Code", "State_Code", "Country_Code",
                   "Phone", "Fax", "EmailID", "URL", "Buss_Start_Date",
                   "Enroll_Date", "MRV_Ref_No", "No_of_VTS", "Credit_Days",
                   "PAN_No", "TAN_No", "ST_ACC_No", "Pay_Mode_Code",
                   "Status_Reason", "Remarks", "UserID", "SUB_Agency_HO",
                   "SUB_Agency_Code", "acagency", "ALERT", "CREDIT_LIMIT",
                   "CODE", "Representative_code", "pin_code", "region",
                   "Type", "code_subcode", "zone_code", "Add2", "Add3",
                   "CREDIT_TYPE", "BILL_TO", "fax1", "Rate_Group",
                   

"qbc_userid","Creation_Datetime","TALUKA","Branch_code",DISTRICT,STATE,BILL_FREQUEN

CY,OLD_AGENCY,BOOKING_TYPE,VAT
                  )
           VALUES (compcode,agencytype, agentcategory, agentcategory2,
                    agentcode, agentname,
                   alias, agencyho, address, street,
                   city, district1, state1, country,
                   phone, fax, mail, url1, bussinessstartdate,
                   enrolldate, mrerefferenceno, novts, credit,
                   pan, TAN, stacno, paymode,
                   status, remarks, userid, subagencyho,
                   agencycode, acagen, alert, creditlimit,
                   code, representative, pin, region1,
                   TYPE1, agentcode || agencycode, zone1, address1, address2,
                   curtype, billto, txtfax1, rategrp,
                   

qbcuserid,sysdate,taluka1,branchcode,hddistcode,hdstatecode,billf,oldagency,booktype1,vat1
                  );

      COMMIT;
   END websp_saveagent_p;
END websp_saveagent;
/





CREATE OR REPLACE PACKAGE          Websp_Executeagency
IS
   TYPE t_accounts_cursor IS REF CURSOR;

   PROCEDURE websp_executeagency_p (
      compcode           IN       VARCHAR2,
      userid             IN       VARCHAR2,
      agentcode          IN       VARCHAR2,
      subagencycode      IN       VARCHAR2,
      agencyname1        IN       VARCHAR2,
      alias              IN       VARCHAR2,
      agenttype          IN       VARCHAR2,
      agentcategory      IN       VARCHAR2,
      agentsubcategory   IN       VARCHAR2,
      city               IN       VARCHAR2,
      COUNT1             IN       VARCHAR2,
      branchcode         IN       VARCHAR2,
      billf              in       varchar2,
      p_accounts         OUT      t_accounts_cursor
   );
END Websp_Executeagency;
/



CREATE OR REPLACE PACKAGE BODY          Websp_Executeagency
IS
   PROCEDURE websp_executeagency_p (
      compcode           IN       VARCHAR2,
      userid             IN       VARCHAR2,
      agentcode          IN       VARCHAR2,
      subagencycode      IN       VARCHAR2,
      agencyname1        IN       VARCHAR2,
      alias              IN       VARCHAR2,
      agenttype          IN       VARCHAR2,
      agentcategory      IN       VARCHAR2,
      agentsubcategory   IN       VARCHAR2,
      city               IN       VARCHAR2,
      COUNT1              IN       VARCHAR2,
      branchcode         IN       VARCHAR2,
      billf              in       varchar2,
      p_accounts         OUT      t_accounts_cursor
   )
   AS
      agencyname2      VARCHAR (50);
      agentcode1       VARCHAR (12);
      subagencycode1   VARCHAR (15);
      alias1           VARCHAR (30);
   BEGIN
  DELETE FROM FIRST1 ; COMMIT;
   --  INSERT INTO FIRST1


    OPEN p_accounts FOR

     SELECT "Comp_Code", "Agency_Type_Code", "Agency_Cat_Code",
                "Agency_SubCat_Code", "Agency_Code", "Agency_Name" AS "Agency_Name",
                "Agency_Alias", "Agency_HO", "Add1", "Street", "City_Code",
                "Zip", "Dist_Code", "State_Code", "Country_Code", "Phone",
                "Fax", "EmailID", "URL", "Buss_Start_Date", "Enroll_Date",
                "MRV_Ref_No", "No_of_VTS", "Credit_Days", "PAN_No", "TAN_No",
                "ST_ACC_No", "Pay_Mode_Code",
                (SELECT status_name FROM STATUS_DETAIL WHERE ROWNUM <= 1 AND 

"agency_code" || "agency_subcat_code" = AGENCY_MAST."code_subcode") AS "status_name",
                "Status_Reason", "Remarks", "UserID", SYSDATE AS "current_Datetime", "UserID",
                "SUB_Agency_HO" AS "SUB_Agency_HO", "SUB_Agency_Code" AS 

"SUB_Agency_Code", "BILL_TO", "ALERT",
                "CREDIT_LIMIT", "CODE", "Representative_code" as "representative_code", 

"pin_code",
                "region",
                (SELECT "TO_DATE"
                   FROM STATUS_DETAIL
                  WHERE ROWNUM <= 1
                    AND "agency_code" || "agency_subcat_code" = AGENCY_MAST."code_subcode") 

AS "to_date",
                "Type", "code_subcode", "zone_code", "Add2", "Add3",
                "CREDIT_TYPE", "acagency", "fax1", "Rate_Group",
                "qbc_userid",(select "DEPO_CODE" from ad_user where 

ad_user."AGENCY_CODE"=agency_mast."code_subcode"  AND ROWNUM<=1) AS 

"DEPOCODE",
                (select "AGENCY_CODE" from ad_user where 

ad_user."AGENCY_CODE"=agency_mast."code_subcode"  AND ROWNUM<=1) AS 

"AGENCYCODE","TALUKA","Branch_code",/*(select dist_mst."Dist_Name" from dist_mst where 

dist_mst."Dist_Code"=agency_mast.DISTRICT and "Comp_Code"=compcode) as 

*/DISTRICT,/*(select state_mst."State_Name" from state_mst where 

state_mst."State_Code"=agency_mast.STATE and "Comp_Code"=compcode) as 

*/STATE,BILL_FREQUENCY,OLD_AGENCY,BOOKING_TYPE,VAT
           FROM AGENCY_MAST
                WHERE ("Comp_Code" = compcode OR compcode IS NULL)
                AND ("Agency_Code" like agentcode||'%')
                AND ("SUB_Agency_Code" like  subagencycode   OR subagencycode IS NULL)
                AND ("Agency_Name" like agencyname1||'%')-- OR agencyname1  IS NULL)
                AND ("Agency_Alias" like alias   OR alias IS NULL)
                AND ("Agency_Type_Code" like agenttype   OR agenttype IS NULL)
                 AND ("Branch_code" like branchcode   OR branchcode IS NULL)
                AND ("Agency_Cat_Code"like agentcategory   OR agentcategory IS NULL)
                AND (BILL_FREQUENCY =billf OR billf IS NULL);












/*

DECLARE

 CURSOR c1 IS SELECT  SUB_AGENCY_CODE FROM FIRST1 ORDER BY 

sub_agency_code;
 AuthorID VARCHAR(100);
 BEGIN



OPEN c1;
LOOP
FETCH c1 INTO AuthorID;

EXIT WHEN c1%NOTFOUND;













UPDATE FIRST1 SET STATUS_NAME= (SELECT   "STATUS_NAME"    FROM 

STATUS_DETAIL WHERE AGENCY_SUBCAT_CODE=AuthorID AND ROWNUM<=1)
 WHERE SUB_AGENCY_CODE=AuthorID;

UPDATE FIRST1 SET TO_DATE= (SELECT "TO_DATE"    FROM STATUS_DETAIL WHERE 

AGENCY_SUBCAT_CODE=AuthorID AND ROWNUM<=1  )
 WHERE SUB_AGENCY_CODE=AuthorID;
END LOOP;

CLOSE c1;
END;







OPEN p_accounts FOR
SELECT  COMP_CODE AS "Comp_Code", AGENCY_TYPE_CODE AS "Agency_Type_Code", 

AGENCY_CAT_CODE AS "Agency_Cat_Code" , AGENCY_SUBCAT_CODE AS 

"Agency_SubCat_Code" , AGENCY_CODE AS "Agency_Code", AGENCY_NAME AS 

"Agency_Name" , AGENCY_ALIAS AS "Agency_Alias" , AGENCY_HO AS "Agency_HO", ADD1 

AS "Add1", STREET AS "Street" , CITY_CODE AS "City_Code", ZIP AS "Zip", DIST_CODE AS 

"Dist_Code", STATE_CODE AS "State_Code", COUNTRY_CODE AS "Country_Code", PHONE 

AS "Phone" , FAX AS "Fax", EMAILID AS "EmailID", URL, BUSS_START_DATE AS 

"Buss_Start_Date", ENROLL_DATE AS "Enroll_Date", MRV_REF_NO AS "MRV_Ref_No", 

NO_OF_VTS AS "No_of_VTS", CREDIT_DAYS AS "Credit_Days", PAN_NO, TAN_NO, 

ST_ACC_NO, PAY_MODE_CODE AS "Pay_Mode_Code" , STATUS_NAME, 

STATUS_REASON AS "Status_Reason" , REMARKS AS "Remarks", USERID AS "UserID", 

CURRENT_DATETIME AS "current_Datetime", USERS AS "users", SUB_AGENCY_HO AS 

"SUB_Agency_HO", SUB_AGENCY_CODE AS "SUB_Agency_Code", BILL_TO, ALERT, 

CREDIT_LIMIT, CODE, REPRESENTATIVE_CODE AS "Representative_code", PIN_CODE 

AS"pin_code"  , Region AS "region", TO_DATE, "TYPE" AS "Type", CODE_SUBCODE AS 

"code_subcode", ZONE_CODE AS "zone_code", ADD2 AS "Add2", ADD3 AS "Add2", 

CREDIT_TYPE, ACAGENCY AS "acagency", FAX1 AS "fax1" , RATE_GROUP AS 

"Rate_Group", QBC_USERID AS "qbc_userid"
  FROM FIRST1      WHERE COMP_CODE = compcode OR compcode IS NULL
                AND AGENCY_CODE LIKE agentcode || '%' OR agentcode IS NULL
                AND SUB_AGENCY_CODE LIKE subagencycode || '%'  OR subagencycode IS NULL
                AND AGENCY_NAME LIKE agencyname1 || '%' OR agencyname1  IS NULL
                AND AGENCY_ALIAS LIKE alias || '%'  OR alias IS NULL
                AND AGENCY_TYPE_CODE LIKE agenttype || '%'  OR agenttype IS NULL
                AND AGENCY_CAT_CODE LIKE agentcategory  || '%' OR agentcategory IS NULL;

*/

       END websp_executeagency_p;
END Websp_Executeagency;
/



/**************************************************Mimoh 15/9/11 Issue 4912 **************************************************/




CREATE OR REPLACE PROCEDURE rpt_publwise_billing_summ
   (pcompcode           in varchar2,
    pcenter             in varchar2,
    pbranchcode         in varchar2,
    ppublcode           in varchar2,
    padtype             in varchar2,
    pcatgcode           in varchar2,
    pdatefrom           in varchar2,
    pdateto             in varchar2,
    puserid             in varchar2,
    pdateformat         in varchar2,
    pextra1             in varchar2,
    pextra2             in varchar2,
    pextra3             in varchar2,
    pextra4             in varchar2,
    pextra5             in varchar2,
    p_accounts          OUT Cur_Type_New1.cursor_type,
    p_accounts1         OUT Cur_Type_New1.cursor_type)
IS
    v_frdt      date; 
    v_todt      date;
        
    v_query             varchar2(20000);
    rec_v1_comp_code    varchar2(20);
    rec_v1_bill_date    date;
    rec_v1_publ_code    varchar2(20);
    rec_v1_publ_name    varchar2(200);
    rec_v1_edtn_code    varchar2(20);
    rec_v1_edtn_name    varchar2(200);
    rec_v1_amount       number(18,2);

    
     cursor c1 is
        select x.comp_code comp_code,x.bill_date bill_date,x.publ_code publ_code,x.publ_name publ_name,
        x.edtn_code edtn_code,x.edtn_name edtn_name,nvl(x.amount,0) amount from
        (select m."Comp_code" comp_code,i.bill_date bill_date,
        i."Publication_Code" publ_code,(select pub_mast."Pub_Name" from pub_mast where 
        pub_mast."Pub_Code"=i."Publication_Code") publ_name,i."Edition_Code" edtn_code,
        (select distinct "Pub_Cent_name" from pub_cent_mast where "Pub_cent_Code"=e."City_Code")  edtn_name,
        round(Sum(i."Bill_Amt"),2) amount
        from agency_mast a,tbl_booking_mast m,tbl_booking_insert i,branch_mst b,adv_cat_mast c,edition_mast e
        where m."Comp_code"=i."Comp_Code" and m."Comp_code"=pcompcode and c."Comp_Code"=m."Comp_code" and e."Comp_Code"=m."Comp_code" and 
        c."Adv_Cat_Code"=i."Ad_Cat" and 
        m."cio_booking_id"=i."Cio_Booking_Id" and a."Agency_Code"||a."SUB_Agency_Code"=m."Agency_sub_code" and 
        i.bill_date between v_frdt and v_todt and (m."Ad_type_code"=padtype or padtype is null) and
        (i."Ad_Cat"=pcatgcode or pcatgcode is null) and 
        --new version
        m."branch"=b."Branch_Code" and
        --old version 
        --m."branch"=b."Branch_Name" and
        (b."Branch_Code"=pbranchcode or pbranchcode is null) and (b."pub_center"=pcenter or pcenter is null) and
        (i."Publication_Code"=ppublcode or ppublcode is null) and e."Edition_Code"=i."Edition_Code"
        group by m."Comp_code",i.bill_date,i."Publication_Code",i."Edition_Code",e."City_Code") x        
        order by comp_code,publ_name,edtn_name,bill_date;

    v_rec_seqno number(10);         
    
    cursor c11 is
            select distinct exe_code publ_code, ad_main_category publ_name,ad_sub_category edtn_name 
            from temp_ad_receipt_report  
                where sess_id=userenv('sessionid') order by publ_name,edtn_name;
    v_var       varchar2(8000);
    v_var_sum   varchar2(8000);
Begin
    v_frdt      := to_date(pdatefrom,''''||pdateformat||'''');
    v_todt      := to_date(pdateto,''''||pdateformat||'''');

    delete from temp_ad_receipt_report where sess_id=userenv('sessionid');
    open c1;
    loop
        fetch c1 into rec_v1_comp_code,rec_v1_bill_date,rec_v1_publ_code,rec_v1_publ_name,rec_v1_edtn_code,rec_v1_edtn_name,rec_v1_amount;
        exit when c1%notfound;
        v_rec_seqno:=nvl(v_rec_seqno,0)+1;
        
        insert into temp_ad_receipt_report
        (comp_code,unit_code,pcentre_code,recptdt,exe_code, ad_main_category,ret_code,ad_sub_category,amount,rec_seqno)
        values(rec_v1_comp_code,pbranchcode,pcenter,rec_v1_bill_date,rec_v1_publ_code,rec_v1_publ_name,rec_v1_edtn_code,rec_v1_edtn_name,
        rec_v1_amount,v_rec_seqno);
    end loop;
    close c1;
    commit;
    
    rec_v1_publ_code:=null;rec_v1_publ_name:=null;rec_v1_edtn_code:=null;rec_v1_edtn_name:=null;
    
    open c11;
    loop
        fetch c11 into rec_v1_publ_code,rec_v1_publ_name,rec_v1_edtn_name;
        exit when c11%notfound;
            if v_var is null then
                v_var       :='case when d.exe_code||''#''||d.ad_sub_category='||''''||rec_v1_publ_code||'#'||rec_v1_edtn_name||''''||' then d.amount else 0 end "'||rec_v1_publ_code||'#'||rec_v1_edtn_name||'"';
                v_var_sum   :='round(sum("'||rec_v1_publ_code||'#'||rec_v1_edtn_name||'"),2)'||' "'||rec_v1_publ_code||'#'||rec_v1_edtn_name||'"';
            else
               v_var        :=v_var||','||'case when d.exe_code||''#''||d.ad_sub_category='||''''||rec_v1_publ_code||'#'||rec_v1_edtn_name||''''||' then d.amount else 0 end "'||rec_v1_publ_code||'#'||rec_v1_edtn_name||'"';
               v_var_sum    :=v_var_sum||','||'round(sum("'||rec_v1_publ_code||'#'||rec_v1_edtn_name||'"),2)'||' "'||rec_v1_publ_code||'#'||rec_v1_edtn_name||'"';
            end if;
    end loop;
    close c11;

    if v_var is null then
       v_query:='select x.comp_code as "COMP_CODE",(select "Comp_Name" from comp_mst where "Comp_Code"=x.comp_code) COMP_NAME,x.bill_date as "BILL_DATE", x.publ_code publ_code,x.publ_name publ_name,
        x.edtn_name edtn_name,round(sum("AMOUNT"),2) as "TOTOL" from
        (select d.comp_code,d.recptdt bill_date,d.exe_code publ_code,d.ad_main_category publ_name, 
        d.ad_sub_category edtn_name,nvl(d.amount,0) amount from temp_ad_receipt_report d where 
        sess_id='||userenv('sessionid')||') x 
        group by x.comp_code,x.publ_code,x.publ_name,x.edtn_name,x.bill_date order by x.comp_code,x.publ_name,x.publ_code,x.edtn_name,x.bill_date';
    else
       v_query:='select x.comp_code as "COMP_CODE",(select "Comp_Name" from comp_mst where "Comp_Code"=x.comp_code) COMP_NAME,x.bill_date as "BILL_DATE", 
        '||v_var_sum||' ,round(sum("AMOUNT"),2) as "TOTOL" from
        (select d.comp_code,d.recptdt bill_date,d.exe_code publ_code,d.ad_main_category publ_name,d.ad_sub_category edtn_name,
       '||v_var||',nvl(d.amount,0) amount from temp_ad_receipt_report d where 
        sess_id='||userenv('sessionid')||') x 
       group by x.comp_code,x.bill_date order by x.comp_code,x.bill_date';
    end if;
        
    delete test1;insert into test1(vstring,vstring2) values('rpt_publwise_billing_summ1',v_query);commit;
        
    open p_accounts for v_query;
        
    if v_var is null then
       v_query:='select x.comp_code as "COMP_CODE",(select "Comp_Name" from comp_mst where "Comp_Code"=x.comp_code) COMP_NAME,round(sum("AMOUNT"),2) as "TOTOL" from
        (select d.comp_code,d.recptdt bill_date,d.exe_code publ_code,d.ad_main_category publ_name,d.ad_sub_category edtn_name,
        nvl(d.amount,0) amount from temp_ad_receipt_report d where 
        sess_id='||userenv('sessionid')||') x 
        group by x.comp_code order by x.comp_code';
    else
       v_query:='select x.comp_code as "COMP_CODE",(select "Comp_Name" from comp_mst where "Comp_Code"=x.comp_code) COMP_NAME,
        '||v_var_sum||' ,round(sum("AMOUNT"),2) as "TOTOL" from
        (select d.comp_code,d.recptdt bill_date,d.exe_code publ_code,d.ad_main_category publ_name,d.ret_code edtn_code,d.ad_sub_category edtn_name,
       '||v_var||',nvl(d.amount,0) amount from temp_ad_receipt_report d where 
        sess_id='||userenv('sessionid')||') x 
        group by x.comp_code order by x.comp_code';
    end if;    

    insert into test1(vstring,vstring2) values('rpt_publwise_billing_summ2',v_query);commit;

    open p_accounts1 for v_query;
    delete from temp_ad_receipt_report where sess_id=userenv('sessionid');commit;
End rpt_publwise_billing_summ;
/
/******************Laxman Sir 16/9/11 4689*****************/

/************************Bhanu 16/9/11 4689********************/
CREATE OR REPLACE FUNCTION HT18JULY.AD_GET_FIELDNAME1 (pcomp_code_f in varchar2,pcomp_code in varchar2,f_code in varchar2,f_code_val in varchar2,f_name in varchar2,t_name in varchar2,f_code1 in varchar2,f_code_val1 in varchar2)RETURN CHAR IS
vexec_name varchar2(200);
Begin
declare query1  varchar2(500);
    BEGIN
    IF t_name='TV_BND_MST' OR  t_name='TV_BTB_MST' OR t_name='TV_AD_TYPE' THEN
        query1:=  'select '|| f_name ||'  from '||t_name||' where '|| pcomp_code_f ||' = '''||pcomp_code||''' and '|| f_code1 ||' = '''||f_code_val1||''' and '|| f_code ||' = '''||f_code_val||'''';
    ELSIF t_name!='TV_AD_CHANNEL' AND t_name!='TV_AD_LOCATION' AND t_name!='TV_AD_TYPE' AND t_name!='TV_AD_PROGRAMME' AND t_name!='TV_BTB_MST' AND t_name!='TV_BND_MST' AND t_name!='TV_AD_PROGRAMME_TY' AND t_name!='TV_COMBIN_MAST' THEN
      query1:=  'select '||'"'|| f_name ||'"'||'  from '||t_name||' where '||'"'|| pcomp_code_f ||'"'||' = '''||pcomp_code||''' and '||'"'|| f_code ||'"'||' = '''||f_code_val||'''';
    else
      query1:=  'select '|| f_name ||'  from '||t_name||' where '|| pcomp_code_f ||' = '''||pcomp_code||''' and '|| f_code ||' = '''||f_code_val||'''';    
    END IF;  
    
      dbg(query1);
      execute immediate query1  into vexec_name ;
        exception when others then
        vexec_name:='';
    end;
    if vexec_name is not null then
         vexec_name:= vexec_name;
    end if;
  return nvl(vexec_name,'');
END;
/


/************************Bhanu 16/9/11 4689********************/






******************************************start issue-0004914 mimoh 21/09/2011*******************************************



DROP PACKAGE HT18JULY.WESP_UPDATEDATE;

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
RO_OUTSTAND_P IN VARCHAR2


);
END      Wesp_Updatedate;
/



DROP PACKAGE BODY HT18JULY.WESP_UPDATEDATE;

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
RO_OUTSTAND_P IN VARCHAR2



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

BILL_SCHEME=P_SCHEME_BILLING,ALLOWED_PDC_DAYS_RECEIPT=P_ALLOW_PDC ,AD_TYPE_MANUL_BILL=PAD_TYPE_FOR_MANUL_BILL,OUTSTANDING_AMT_CRITERIA=RO_OUTSTAND_P
  
   WHERE "comp_code"=compcode;
COMMIT;
END      Wesp_Updatedate_p;
END      Wesp_Updatedate;
/
-----------------------------------------------------------------------------------------------------------------------------------------------------



DROP PACKAGE HT18JULY.CURRBINDPREFERPGLD;

CREATE OR REPLACE PACKAGE HT18JULY.Currbindpreferpgld
IS
   TYPE t_account_cursor IS REF CURSOR;

   PROCEDURE currbindpreferpgld_p (
      compcode     IN       VARCHAR2,
      p_accounts   OUT      t_account_cursor
   );
END Currbindpreferpgld;
/



DROP PACKAGE BODY HT18JULY.CURRBINDPREFERPGLD;

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
           AD_TYPE_MANUL_BILL,OUTSTANDING_AMT_CRITERIA as RO_OUTSTAND
           
            FROM PREFERRENCES
          WHERE "comp_code" = compcode;
          
         
   END currbindpreferpgld_p;
END Currbindpreferpgld;
/
------------------------------------------------------------------------------------------------

******************************************end issue-0004914 mimoh 21/09/2011*******************************************



/**************************prachi 5009 22-sep*******************************************************************/
CREATE OR REPLACE PROCEDURE completereport
(
p_compcode IN VARCHAR2:= NULL,
p_fromdate IN VARCHAR2:= NULL,
p_dateto IN VARCHAR2:= NULL,
p_dateformat IN VARCHAR2:= NULL,
p_publication IN VARCHAR2:= NULL, 
p_pub_cent IN VARCHAR2:= NULL,
p_edition IN VARCHAR2:= NULL,
p_suppliment IN VARCHAR2:= NULL,
p_zone IN VARCHAR2:= NULL,
p_branch IN VARCHAR2:= NULL,
p_district IN VARCHAR2:= NULL,
p_region IN VARCHAR2:= NULL,
p_city IN VARCHAR2:= NULL,
p_revcenter IN VARCHAR2:= NULL,
p_adtype IN VARCHAR2:= NULL,
p_agencytype IN VARCHAR2:= NULL,
p_ratetype IN VARCHAR2:= NULL,
p_adcat IN VARCHAR2:= NULL,
p_adsubcat IN VARCHAR2:= NULL,
p_adsubcat3 IN VARCHAR2:= NULL,
p_adsubcat4 IN VARCHAR2:= NULL,
p_adsubcat5 IN VARCHAR2:= NULL,
p_package IN VARCHAR2:= NULL,
p_scheme IN VARCHAR2:= NULL,
p_agency IN VARCHAR2:= NULL,
p_client IN VARCHAR2:= NULL,
p_executive IN VARCHAR2:= NULL,
p_retainer IN VARCHAR2:= NULL,
p_product IN VARCHAR2:= NULL,
p_brand IN VARCHAR2:= NULL,
p_varient IN VARCHAR2:= NULL,
p_pagetype IN VARCHAR2:= NULL,
p_pageprem IN VARCHAR2:= NULL,
p_postprem IN VARCHAR2:= NULL,
p_rostatus IN VARCHAR2:= NULL,
p_booktype IN VARCHAR2:= NULL,
p_contractname IN varchar2:= NULL,
p_filterby IN varchar2:= NULL,
p_adcheck in varchar2:=null,
p_state in varchar2:=null,
p_taluka in varchar2:=null,
p_base in varchar2:=null,
p_drpstatus in varchar2:=null,
p_chkdetail in varchar2:=null,
p_insertstatus in varchar2:=null,
p_puserid in varchar2:=null,
p_chk_access in varchar2:=null,
p_recordset1 OUT Cur_Type_New1.cursor_type,
p_accounts OUT Cur_Type_New1.cursor_type
)

IS
query1 VARCHAR2(20000);
v_val number(5);
query2 VARCHAR2(20000);
query3 VARCHAR2(20000);


bookdate varchar2(50);
noinsert varchar2(50);
Paidinsert varchar2(50);
Area varchar2(50);
Pagepremium varchar2(50);
cardamt varchar2(50);
Deviationamt varchar2(50);
Deviationper varchar2(50);
aggamt varchar2(50);
DiscAmt varchar2(50);
Discper varchar2(50);
posamt varchar2(50);
posper varchar2(50);
Spdiscamt varchar2(50);
Spdiscper varchar2(50);
Spacedisc varchar2(50);
Spacediscper varchar2(50);
Specialcharge varchar2(50);
AgencyAddlTDper varchar2(50);
AgencyAddlTDAmt varchar2(50);
Grossamt varchar2(50);
RetTDper varchar2(50);
RetTDAmt varchar2(50);
AgencyTDper varchar2(50);
AgencyTDAmt varchar2(50);
Billamt varchar2(50);
RetCommper varchar2(50);
RetCommAmt varchar2(50);
ActualBusines varchar2(50);



Cursor C1 Is
SELECT /*+ index(TBL_BOOKING_MAST IND_TBL_BOOKING_MAST) 

index(TBL_BOOKING_INSERT  INSERT_I) */  distinct 

TBL_BOOKING_mast."cio_booking_id" AS "CIOID",
TBL_BOOKING_MAST."Package_code" as package_code,TBL_BOOKING_mast."Gross_amount" 

as Crate,'1' as chk_var
FROM TBL_BOOKING_MAST, TBL_BOOKING_INSERT
WHERE TBL_BOOKING_MAST."Comp_code"=p_compcode
AND TBL_BOOKING_MAST."cio_booking_id"=TBL_BOOKING_INSERT."Cio_Booking_Id"
AND ((tbl_booking_mast."Insertion_date" BETWEEN p_fromdate AND p_dateto and 

p_filterby='Publish Date') or (tbl_booking_mast."date_time" BETWEEN p_fromdate 

AND p_dateto and p_filterby='Booking Date'))
AND (TBL_BOOKING_INSERT."Publication_Code"=p_publication or p_publication is 

null)
--old version

and TBL_BOOKING_MAST."branch" IN (SELECT "Branch_Name" FROM BRANCH_MST WHERE 

TBL_BOOKING_MAST."branch"="Branch_Name" and "pub_center" in (SELECT 

"Pub_cent_Code" FROM PUB_CENT_MAST WHERE  

branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" and 

"Pub_cent_Code"=p_pub_cent or p_pub_cent is null))
and (tbl_booking_mast."branch" =p_branch or p_branch is null)

--new version
--and TBL_BOOKING_MAST."branch" IN (SELECT "Branch_Code" FROM BRANCH_MST WHERE 

TBL_BOOKING_MAST."branch"="Branch_Code" and "pub_center" in (SELECT 

"Pub_cent_Code" FROM PUB_CENT_MAST WHERE  

branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" and 

"Pub_cent_Code"=p_pub_cent or p_pub_cent is null))
--and (tbl_booking_mast."branch" = (SELECT "Branch_Code" FROM BRANCH_MST where 

"Branch_Name" =p_branch))

AND (TBL_BOOKING_MAST."Ad_type_code"=p_adtype or p_adtype is null)
AND (TBL_BOOKING_MAST."Ad_cat_code"=p_adcat or p_adcat is null)
AND (TBL_BOOKING_INSERT."Edition_Code"=p_edition or p_edition is null)
and (TBL_BOOKING_MAST."Agency_sub_code"  in (select AGENCY_MAST."code_subcode" 

from agency_mast where agency_mast."region" =p_region  or p_region is null))
and (tbl_booking_mast."Revenue_center" =p_revcenter or p_revcenter is null)
and (TBL_BOOKING_MAST."Agency_type" =p_agencytype or p_agencytype is null)
and (TBL_BOOKING_MAST."Ad_sub_cat_code" =p_adsubcat or p_adsubcat is null)
and (TBL_BOOKING_MAST."Ad_Subcat3" =p_adsubcat3 or p_adsubcat3 is null)
and (TBL_BOOKING_MAST."Ad_Subcat4" =p_adsubcat4 or p_adsubcat4 is null)
and (TBL_BOOKING_MAST."Ad_subcat5" =p_adsubcat5 or p_adsubcat5 is null)
and (TBL_BOOKING_MAST."Package_code" =p_package or p_package is null)
and (TBL_BOOKING_MAST."Scheme_type_code" =p_scheme or p_scheme is null)
and (TBL_BOOKING_MAST."Agency_code" =p_agency or p_agency is null)
and (TBL_BOOKING_MAST."Client_code" =p_client or p_client is null)
and (TBL_BOOKING_MAST."Executive_code" =p_executive or p_executive is null)
and (TBL_BOOKING_MAST.RETAINER =p_retainer or p_retainer is null)
and (TBL_BOOKING_MAST."Product_code" =p_product  or p_product is null)
and (TBL_BOOKING_MAST."Brand_code" =p_brand or p_brand is null)
and (TBL_BOOKING_MAST."Variant_code" =p_varient or p_varient is null)
and (TBL_BOOKING_MAST."Page_type_code" =p_pagetype or p_pagetype is null)
and (TBL_BOOKING_MAST."Page_prem" =p_pageprem or p_pageprem is null)
and (TBL_BOOKING_MAST."Page_position_code" =p_postprem or p_postprem is null)
and (TBL_BOOKING_MAST."ro_status" =p_rostatus or p_rostatus is null)
and (TBL_BOOKING_MAST."Booking_type" =p_booktype or p_booktype is null)
and (TBL_BOOKING_MAST."Contract_name" =p_contractname or p_contractname is 

null)
and (tbl_booking_insert."Supp_Code" =p_suppliment or p_suppliment is null)
and (tbl_booking_MAST."Rate_code" =p_ratetype or p_ratetype is null)

and ((p_base='1' and TBL_BOOKING_MAST."Agency_sub_code"  in (select 

AGENCY_MAST."code_subcode" from agency_mast where AGENCY_MAST."City_Code" 

=p_city or p_city is null))
or (p_base='2' and tbl_booking_mast."Executive_code"  in(select 

exec_mast."Exe_no" from exec_mast where exec_mast."city_code" =p_city or p_city 

is null))
or (p_base='3' and tbl_booking_mast.RETAINER in(select 

RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  

RETAINERMASTER."City_Code"=p_city or p_city is null)))

and ((p_base='1' and TBL_BOOKING_MAST."Agency_sub_code"  in (select 

AGENCY_MAST."code_subcode" from agency_mast where AGENCY_MAST."zone_code" 

=p_zone or p_zone is null))
or (p_base='2' and tbl_booking_mast."Executive_code"  in(select 

exec_mast."Exe_no" from exec_mast where exec_mast."city_code" in (select 

city_mst."City_Code" from city_mst where city_mst."Zone_Code"= p_zone or p_zone 

is null) ))
or (p_base='3' and tbl_booking_mast.RETAINER in(select 

RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  

RETAINERMASTER."Zone_Code"=p_zone or p_zone is null)))

and ((p_base='1' and TBL_BOOKING_MAST."Agency_sub_code"  in (select 

AGENCY_MAST."code_subcode" from agency_mast where AGENCY_MAST."Dist_Code" 

=p_district or p_district is null))
or (p_base='2' and tbl_booking_mast."Executive_code"  in(select 

exec_mast."Exe_no" from exec_mast where exec_mast."dist_code"= p_district or 

p_district is null ))
or (p_base='3' and tbl_booking_mast.RETAINER in(select 

RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  

RETAINERMASTER."Dist_Code"=p_district or p_district is null)))

and ((p_base='1' and TBL_BOOKING_MAST."Agency_sub_code"  in (select 

AGENCY_MAST."code_subcode" from agency_mast where AGENCY_MAST."State_Code" 

=p_state or p_state is null))
or (p_base='2' and tbl_booking_mast."Executive_code"  in(select 

exec_mast."Exe_no" from exec_mast where exec_mast."State_code"= p_state or 

p_state is null ))
or (p_base='3' and tbl_booking_mast.RETAINER in(select 

RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  

RETAINERMASTER."State_Code"=p_state or p_state is null)))

and ((p_base='1' and TBL_BOOKING_MAST."Agency_sub_code"  in (select 

AGENCY_MAST."code_subcode" from agency_mast where AGENCY_MAST.TALUKA=p_taluka 

or p_taluka is null) )
or (p_base='2' and tbl_booking_mast."Executive_code"  in(select 

exec_mast."Exe_no" from exec_mast where exec_mast.TALUKA= p_taluka or p_taluka 

is null ))
or (p_base='3' and tbl_booking_mast.RETAINER in(select 

RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  

RETAINERMASTER.TALUKA=p_taluka or p_taluka is null)))

and ((p_base='1' and TBL_BOOKING_MAST."Agency_sub_code" IS NOT NULL AND 

TBL_BOOKING_MAST."Agency_sub_code"!='0')
or (p_base='2' and tbl_booking_mast."Executive_code"    is not null and 

tbl_booking_mast."Executive_code" !='0' )
or (p_base='3' and tbl_booking_mast.RETAINER is not null  and 

tbl_booking_mast.RETAINER !='0'))

and ((p_drpstatus is  not null and  TBL_BOOKING_INSERT."Insert_Status"!='XYZ') 

or (p_drpstatus is  null and  lower("Insert_Status")!='cancel'))
and (lower("Insert_Status")=p_insertstatus or p_insertstatus is null)

and ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from 

login_center where newuser_id=p_puserid) and p_chk_access=1)
or  (p_chk_access=0) )

  
and p_adcheck='1'

union

SELECT /*+ index(TBL_BOOKING_MAST IND_TBL_BOOKING_MAST) 

index(TBL_BOOKING_INSERT  INSERT_I) */ distinct 

TBL_BOOKING_mast."cio_booking_id" AS "CIOID",
TBL_BOOKING_MAST."Package_code" as package_code,tbl_booking_insert."Gross_Rate" 

as Crate,'1' as chk_var
FROM TBL_BOOKING_MAST, TBL_BOOKING_INSERT
WHERE TBL_BOOKING_MAST."Comp_code"=p_compcode
AND TBL_BOOKING_MAST."Comp_code"=TBL_BOOKING_INSERT."Comp_Code"
AND TBL_BOOKING_MAST."cio_booking_id"=TBL_BOOKING_INSERT."Cio_Booking_Id"
AND (tbl_booking_insert."Insert_Date" BETWEEN p_fromdate AND p_dateto )
AND (TBL_BOOKING_INSERT."Publication_Code"=p_publication or p_publication is 

null)
--old version

and TBL_BOOKING_MAST."branch" IN (SELECT "Branch_Name" FROM BRANCH_MST WHERE 

TBL_BOOKING_MAST."branch"="Branch_Name" and "pub_center" in (SELECT 

"Pub_cent_Code" FROM PUB_CENT_MAST WHERE  

branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" and 

"Pub_cent_Code"=p_pub_cent or p_pub_cent is null))
and (tbl_booking_mast."branch" =p_branch or p_branch is null)

--new version
--and TBL_BOOKING_MAST."branch" IN (SELECT "Branch_Code" FROM BRANCH_MST WHERE 

TBL_BOOKING_MAST."branch"="Branch_Code" and "pub_center" in (SELECT 

"Pub_cent_Code" FROM PUB_CENT_MAST WHERE  

branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" and 

"Pub_cent_Code"=p_pub_cent or p_pub_cent is null))
--and (tbl_booking_mast."branch" = (SELECT "Branch_Code" FROM BRANCH_MST where 

"Branch_Name" =p_branch))


AND (TBL_BOOKING_MAST."Ad_type_code"=p_adtype or p_adtype is null)
AND (TBL_BOOKING_insert."Ad_Cat" =p_adcat or p_adcat is null)
AND (TBL_BOOKING_INSERT."Edition_Code"=p_edition or p_edition is null)
and (TBL_BOOKING_MAST."Agency_sub_code"  in (select AGENCY_MAST."code_subcode" 

from agency_mast where agency_mast."region" =p_region  or p_region is null))
and (tbl_booking_mast."Revenue_center" =p_revcenter or p_revcenter is null)
and (TBL_BOOKING_MAST."Agency_type" =p_agencytype or p_agencytype is null)
and (TBL_BOOKING_MAST."Ad_sub_cat_code" =p_adsubcat or p_adsubcat is null)
and (TBL_BOOKING_MAST."Ad_Subcat3" =p_adsubcat3 or p_adsubcat3 is null)
and (TBL_BOOKING_MAST."Ad_Subcat4" =p_adsubcat4 or p_adsubcat4 is null)
and (TBL_BOOKING_MAST."Ad_subcat5" =p_adsubcat5 or p_adsubcat5 is null)
and (TBL_BOOKING_MAST."Package_code" =p_package or p_package is null)
and (TBL_BOOKING_MAST."Scheme_type_code" =p_scheme or p_scheme is null)
and (TBL_BOOKING_MAST."Agency_code" =p_agency or p_agency is null)
and (TBL_BOOKING_MAST."Client_code" =p_client or p_client is null)
and (TBL_BOOKING_MAST."Executive_code" =p_executive or p_executive is null)
and (TBL_BOOKING_MAST.RETAINER =p_retainer or p_retainer is null)
and (TBL_BOOKING_MAST."Product_code" =p_product  or p_product is null)
and (TBL_BOOKING_MAST."Brand_code" =p_brand or p_brand is null)
and (TBL_BOOKING_MAST."Variant_code" =p_varient or p_varient is null)
and (TBL_BOOKING_MAST."Page_type_code" =p_pagetype or p_pagetype is null)
and (TBL_BOOKING_insert."Premium1"  =p_pageprem or p_pageprem is null)
and (tbl_booking_insert."Page_Post" =p_postprem or p_postprem is null)
and (TBL_BOOKING_MAST."ro_status" =p_rostatus or p_rostatus is null)
and (TBL_BOOKING_MAST."Booking_type" =p_booktype or p_booktype is null)
and (TBL_BOOKING_MAST."Contract_name" =p_contractname or p_contractname is 

null)
and (tbl_booking_insert."Supp_Code" =p_suppliment or p_suppliment is null)
and (tbl_booking_MAST."Rate_code" =p_ratetype or p_ratetype is null)
and ((p_base='1' and TBL_BOOKING_MAST."Agency_sub_code"  in (select 

AGENCY_MAST."code_subcode" from agency_mast where AGENCY_MAST."City_Code" 

=p_city or p_city is null))
or (p_base='2' and tbl_booking_mast."Executive_code"  in(select 

exec_mast."Exe_no" from exec_mast where exec_mast."city_code" =p_city or p_city 

is null))
or (p_base='3' and tbl_booking_mast.RETAINER in(select 

RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  

RETAINERMASTER."City_Code"=p_city or p_city is null)))
and ((p_base='1' and TBL_BOOKING_MAST."Agency_sub_code"  in (select 

AGENCY_MAST."code_subcode" from agency_mast where AGENCY_MAST."zone_code" 

=p_zone or p_zone is null))
or (p_base='2' and tbl_booking_mast."Executive_code"  in(select 

exec_mast."Exe_no" from exec_mast where exec_mast."city_code" in (select /*+ 

index(city_mst ind_city_mst) */ city_mst."City_Code" from city_mst where 

city_mst."Zone_Code"= p_zone or p_zone is null) 
))
or (p_base='3' and tbl_booking_mast.RETAINER in(select 

RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  

RETAINERMASTER."Zone_Code"=p_zone or p_zone is null)))
and ((p_base='1' and TBL_BOOKING_MAST."Agency_sub_code"  in (select 

AGENCY_MAST."code_subcode" from agency_mast where AGENCY_MAST."Dist_Code" 

=p_district or p_district is null))
or (p_base='2' and tbl_booking_mast."Executive_code"  in(select 

exec_mast."Exe_no" from exec_mast where exec_mast."dist_code"= p_district or 

p_district is null ))
or (p_base='3' and tbl_booking_mast.RETAINER in(select 

RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  

RETAINERMASTER."Dist_Code"=p_district or p_district is null)))
and ((p_base='1' and TBL_BOOKING_MAST."Agency_sub_code"  in (select 

AGENCY_MAST."code_subcode" from agency_mast where AGENCY_MAST."State_Code" 

=p_state or p_state is null))
or (p_base='2' and tbl_booking_mast."Executive_code"  in(select 

exec_mast."Exe_no" from exec_mast where exec_mast."State_code"= p_state or 

p_state is null ))
or (p_base='3' and tbl_booking_mast.RETAINER in(select 

RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  

RETAINERMASTER."State_Code"=p_state or p_state is null)))
and ((p_base='1' and TBL_BOOKING_MAST."Agency_sub_code"  in (select 

AGENCY_MAST."code_subcode" from agency_mast where AGENCY_MAST.TALUKA=p_taluka 

or p_taluka is null) )
or (p_base='2' and tbl_booking_mast."Executive_code"  in(select 

exec_mast."Exe_no" from exec_mast where exec_mast.TALUKA= p_taluka or p_taluka 

is null ))
or (p_base='3' and tbl_booking_mast.RETAINER in(select 

RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  

RETAINERMASTER.TALUKA=p_taluka or p_taluka is null)))
and ((p_base='1' and TBL_BOOKING_MAST."Agency_sub_code" IS NOT NULL AND 

TBL_BOOKING_MAST."Agency_sub_code"!='0')
or (p_base='2' and tbl_booking_mast."Executive_code"    is not null and 

tbl_booking_mast."Executive_code" !='0' )
or (p_base='3' and tbl_booking_mast.RETAINER is not null  and 

tbl_booking_mast.RETAINER !='0'))
and ((p_drpstatus is  not null and  TBL_BOOKING_INSERT."Insert_Status"!='XYZ')
or (p_drpstatus is  null and  lower("Insert_Status")!='cancel'))
and (lower("Insert_Status")=p_insertstatus or p_insertstatus is null)

and ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from 

login_center where newuser_id=p_puserid) and p_chk_access=1)
or  (p_chk_access=0) )

and p_adcheck='3'

union

SELECT /*+ index (ad_bills_det ind1_ad_bills_det) */distinct ad_bills."IDNUM" 

AS "CIOID",
ad_bills_det.PACKAGE_CODE as package_code,ad_bills.GROSS_AMT as Crate,'2' as 

chk_var
FROM ad_bills, ad_bills_det,agency_mast,branch_mst
WHERE ad_bills.IDNUM=ad_bills_det.IDNUM
AND ad_bills.BILDT >= p_fromdate and ad_bills.BILDT <= p_dateto
and (ad_bills."PRIPUB"=p_publication  or p_publication is null)
and (ad_bills_det."EDITION"=p_edition or p_edition is null)
and ad_bills.AGCODE =AGENCY_MAST."code_subcode" and (agency_mast."region" 

=p_region  or p_region is null)
and (ad_bills_det."AD_TYPE_V"=p_adtype or p_adtype is null)
and (agency_mast."Agency_Type_Code" =p_agencytype or p_agencytype is null)
and (ad_bills_det.PRIADCTG =p_adcat or p_adcat is null)
and (ad_bills_det.SECADCTG =p_adsubcat or p_adsubcat is null)
and (ad_bills_det."AD_SUBCAT3"  =p_adsubcat3 or p_adsubcat3 is null)
and (ad_bills_det.AD_SUBCAT4 =p_adsubcat4 or p_adsubcat4 is null)
and (ad_bills_det.AD_SUBCAT5 =p_adsubcat5 or p_adsubcat5 is null)
and (ad_bills_det.PACKAGE_CODE =p_package or p_package is null)
and (agency_mast."Agency_Code" =p_agency or p_agency is null)
and (ad_bills."CLIENTCD"=p_client or p_client is null)
and (ad_bills."EXECUTIVE_NAME"=p_executive or p_executive is null)
and (ad_bills."PRIPROCTG"=p_product or p_product is null)
and ((ad_bills."PRIPROCTG" in (select /*+ index(brand_mst brand_mst_pk)*/ 

brand_mst."prod_cat_code" from brand_mst where brand_mst."brand_code"=p_brand 

or p_brand is null) 
and ad_bills."PRIPROCTG" is not null)or (ad_bills."PRIPROCTG" is null))
and ((ad_bills."PRIPROCTG" in (select /*+ index(brand_mst brand_mst_pk)*/ 

brand_mst."prod_cat_code" from brand_mst where brand_mst."brand_code" in(select 

/*+ index(varient_mst ind_varient_mst) */ varient_mst."Brand_Code" from 

varient_mst where varient_mst."Varient_Name"=p_varient or p_varient is null)) 
and ad_bills."PRIPROCTG" is not null) or (ad_bills."PRIPROCTG" is null))
and (ad_bills_det.PAGE_PREM =p_pageprem or p_pageprem is null)
and (ad_bills_det.PAGE_POST =p_postprem or p_postprem is null)
and (ad_bills.CONTRACT_NAME =p_contractname or p_contractname is null)
and (ad_bills_det.SUPP_CODE =p_suppliment or p_suppliment is null)
and (ad_bills.RETAINER_CODE =p_retainer or p_retainer is null)
and (ad_bills_det.RATECD =p_ratetype or p_ratetype is null)
and ad_bills.UNIT = branch_mst."Branch_Code" and (branch_mst."Branch_Name" 

=p_branch or p_branch is null) 
and (branch_mst."pub_center"=p_pub_cent or p_pub_cent is null)
and (ad_bills.SCHEME=scheme or scheme is null)
and (AD_BILLS.REVENUE_CENTER =p_revcenter or p_revcenter is null)
and (AD_BILLS.RO_STATUS =p_rostatus or p_rostatus is null)
and (AD_BILLS.PAGE_TYPE =p_pagetype or p_pagetype is null)
and (AD_BILLS.BOOKING_TYPE =p_booktype or p_booktype is null)
 and (ad_bills.SCHEME=p_scheme or p_scheme is null)
 and (AD_BILLS.REVENUE_CENTER =p_revcenter or p_revcenter is null)
 and (AD_BILLS.RO_STATUS =p_rostatus or p_rostatus is null)
 and (AD_BILLS.PAGE_TYPE =p_pagetype or p_pagetype is null)
 and (AD_BILLS.BOOKING_TYPE =p_booktype or p_booktype is null)
and ((p_base='1' and (AGENCY_MAST."City_Code" =p_city or p_city is null))
or (p_base='2' and ad_bills.EXECUTIVE_NAME in(select exec_mast."Exe_no" from 

exec_mast where exec_mast."city_code" =p_city or p_city is null))
or (p_base='3' and ad_bills.RETAINER_CODE in(select 

RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  

RETAINERMASTER."City_Code"=p_city or p_city is null)))

and ((p_base='1' and (AGENCY_MAST."zone_code" =p_zone or p_zone is null))
or (p_base='2' and ad_bills.EXECUTIVE_NAME in(select exec_mast."Exe_no" from 

exec_mast where exec_mast."city_code" in (select city_mst."City_Code" from 

city_mst where city_mst."Zone_Code"= p_zone or p_zone is null) ))
or (p_base='3' and ad_bills.RETAINER_CODE in(select 

RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  

RETAINERMASTER."Zone_Code"=p_zone or p_zone is null)))

and ((p_base='1' and (AGENCY_MAST."Dist_Code" =p_district or p_district is 

null))
or (p_base='2' and ad_bills.EXECUTIVE_NAME in(select exec_mast."Exe_no" from 

exec_mast where exec_mast."dist_code"= p_district or p_district is null ))
or (p_base='3' and ad_bills.RETAINER_CODE in(select 

RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  

RETAINERMASTER."Dist_Code"=p_district or p_district is null)))

and ((p_base='1' and (AGENCY_MAST."State_Code" =p_state or p_state is null))
or (p_base='2' and ad_bills.EXECUTIVE_NAME in(select exec_mast."Exe_no" from 

exec_mast where exec_mast."State_code"= p_state or p_state is null ))
or (p_base='3' and ad_bills.RETAINER_CODE in(select 

RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  

RETAINERMASTER."State_Code"=p_state or p_state is null)))

and ((p_base='1' and (AGENCY_MAST.TALUKA=p_taluka or p_taluka is null) )
or (p_base='2' and ad_bills.EXECUTIVE_NAME   in(select exec_mast."Exe_no" from 

exec_mast where exec_mast.TALUKA= p_taluka or p_taluka is null ))
or (p_base='3' and ad_bills.RETAINER_CODE  in(select 

RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  

RETAINERMASTER.TALUKA=p_taluka or p_taluka is null)))

and ((p_base='1' and ad_bills.AGCODE IS NOT NULL AND ad_bills.AGCODE!='0')
or (p_base='2' and ad_bills.EXECUTIVE_NAME   is not null and 

ad_bills.EXECUTIVE_NAME !='0' )
or (p_base='3' and ad_bills.RETAINER_CODE  is not null  and 

ad_bills.RETAINER_CODE !='0'))

and ((ad_bills_det."BKFOR" in (select distinct pub_center from login_center 

where newuser_id=p_puserid) and p_chk_access=1)
or  (p_chk_access=0) )

and p_adcheck='2';

v1 c1%rowtype;


---**************************************  For Billing 

Data*************************
Cursor C2 Is
SELECT distinct ad_bills."IDNUM" AS "CIOID",ad_bills.BILNO as "BILLNO" 

,ad_bills.ag_main_code as "AGMAINCODE",ad_bills.ag_sub_code as 

"AG_SUB_CODE",ad_bills.agcode as "AGCODE",
"Agency_Name" as "AGNAME",nvl(ad_bills.executive_name,0) as 

"EXECCODE",AD_GET_EXECNAME(p_compcode,ad_bills.EXECUTIVE_NAME) as 

"EXECNAME",ad_bills.RETAINER_CODE as 

"RETCODE",AD_GET_RETAINER(p_compcode,ad_bills.RETAINER_CODE) as "RETNAME"
FROM ad_bills,AGENCY_MAST,branch_mst WHERE ad_bills.comp_code_v=p_compcode 
and ad_bills.BILDT >= p_fromdate and ad_bills.BILDT <=p_dateto 
and ad_bills.UNIT=branch_mst."Branch_Code" and (branch_mst."Branch_Name" 

=p_branch or p_branch is null) 
and (BRANCH_MST."pub_center" =p_pub_cent or p_pub_cent is null)
and ad_bills.AGCODE =AGENCY_MAST."code_subcode" and (agency_mast."region" 

=p_region  or p_region is null)
and (agency_mast."Agency_Type_Code" =p_agencytype or p_agencytype is null)
and (ad_bills."PRIPUB"=p_publication  or p_publication is null)
and (agency_mast."Agency_Code" =p_agency or p_agency is null)
and (ad_bills."CLIENTCD"=p_client or p_client is null)
and (ad_bills."EXECUTIVE_NAME"=p_executive or p_executive is null)
and (ad_bills."PRIPROCTG"=p_product or p_product is null)
and ((ad_bills."PRIPROCTG" in (select brand_mst."prod_cat_code" from brand_mst 

where brand_mst."brand_code"=p_brand or p_brand is null) and 

ad_bills."PRIPROCTG" is not null)or (ad_bills."PRIPROCTG" is null))
and ((ad_bills."PRIPROCTG" in (select brand_mst."prod_cat_code" from brand_mst 

where brand_mst."brand_code" in(select varient_mst."Brand_Code" from 

varient_mst where varient_mst."Varient_Name"=p_varient or p_varient is null)) 

and ad_bills."PRIPROCTG" is not null) or (ad_bills."PRIPROCTG" is null))
and (ad_bills.CONTRACT_NAME =p_contractname or p_contractname is null)
and (ad_bills.RETAINER_CODE =p_retainer or p_retainer is null)
and (ad_bills.SCHEME=p_scheme or p_scheme is null)
and (AD_BILLS.REVENUE_CENTER =p_revcenter or p_revcenter is null)
and (AD_BILLS.RO_STATUS =p_rostatus or p_rostatus is null)
and (AD_BILLS.PAGE_TYPE =p_pagetype or p_pagetype is null)
and (AD_BILLS.BOOKING_TYPE =p_booktype or p_booktype is null)
and ((p_base='1' and (AGENCY_MAST."City_Code" =p_city or p_city is null))
or (p_base='2' and ad_bills.EXECUTIVE_NAME in(select exec_mast."Exe_no" from 

exec_mast where exec_mast."city_code" =p_city or p_city is null))
or (p_base='3' and ad_bills.RETAINER_CODE in(select 

RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  

RETAINERMASTER."City_Code"=p_city or p_city is null)))
and ((p_base='1' and (AGENCY_MAST."zone_code" =p_zone or p_zone is null))
or (p_base='2' and ad_bills.EXECUTIVE_NAME in(select exec_mast."Exe_no" from 

exec_mast where exec_mast."city_code" in (select city_mst."City_Code" from 

city_mst where city_mst."Zone_Code"= p_zone or p_zone is null) ))
or (p_base='3' and ad_bills.RETAINER_CODE in(select 

RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  

RETAINERMASTER."Zone_Code"=p_zone or p_zone is null)))
and ((p_base='1' and (AGENCY_MAST."Dist_Code" =p_district or p_district is 

null))
or (p_base='2' and ad_bills.EXECUTIVE_NAME in(select exec_mast."Exe_no" from 

exec_mast where exec_mast."dist_code"= p_district or p_district is null ))
or (p_base='3' and ad_bills.RETAINER_CODE in(select 

RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  

RETAINERMASTER."Dist_Code"=p_district or p_district is null)))
and ((p_base='1' and (AGENCY_MAST."State_Code" =p_state or p_state is null))
or (p_base='2' and ad_bills.EXECUTIVE_NAME in(select exec_mast."Exe_no" from 

exec_mast where exec_mast."State_code"= p_state or p_state is null ))
or (p_base='3' and ad_bills.RETAINER_CODE in(select 

RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  

RETAINERMASTER."State_Code"=p_state or p_state is null)))
and ((p_base='1' and (AGENCY_MAST.TALUKA=p_taluka or p_taluka is null) )
or (p_base='2' and ad_bills.EXECUTIVE_NAME   in(select exec_mast."Exe_no" from 

exec_mast where exec_mast.TALUKA= p_taluka or p_taluka is null ))
or (p_base='3' and ad_bills.RETAINER_CODE  in(select 

RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  

RETAINERMASTER.TALUKA=p_taluka or p_taluka is null)))
and ((p_base='1' and ad_bills.AGCODE IS NOT NULL AND ad_bills.AGCODE!='0')
or (p_base='2' and ad_bills.EXECUTIVE_NAME   is not null and 

ad_bills.EXECUTIVE_NAME !='0' )
or (p_base='3' and ad_bills.RETAINER_CODE  is not null  and 

ad_bills.RETAINER_CODE !='0'));

v2 C2%rowtype;

--*****************************************************************************

*****

v_edition varchar2(100);
v_edipkg varchar2(500);
prefer   varchar2(10);

BEGIN
delete from searchtbl;
/*insert into searchtbl 

values('compcode-'||compcode||'fromdate-'||fromdate||'dateto-'||dateto||'datefo

rmat-'||dateformat||'publication-'||publication
||'pub_cent-'||pub_cent||'edition-'||edition||'suppliment-'||suppliment||'zone-

'||zone||'branch-'||branch||'district-'||district||'region-'||region||
'city-'||city||'revcenter-'||revcenter||'adtype-'||adtype||'agencytype-'||agenc

ytype||'ratetype-'||ratetype||'adcat-'||adcat||'adsubcat-'||adsubcat||
'adsubcat3-'||adsubcat3||'adsubcat4-'||adsubcat4||'adsubcat5-'||adsubcat5||'pac

kage-'||package||'scheme-'||scheme||'agency-'||agency||'client-'||client||
'executive-'||executive||'retainer-'||retainer||'product-'||product||'brand-'||

brand||'varient-'||varient||'pagetype-'||pagetype||'pageprem-'||pageprem||
'postprem-'||postprem||'rostatus-'||rostatus||'booktype-'||booktype||'contractn

ame-'||contractname||'filterby-'||filterby||'adcheck-'||adcheck||'state-'||stat

e||
'taluka-'||taluka||'base-'||base||'drpstatus-'||drpstatus||'chkdetail-'||chkdet

ail||'insertstatus-'||insertstatus||'puserid-'||puserid||'chk_access-'||chk_acc

ess);

*/


select DISTINCT AGENCY_RETAINER_COMM into prefer from preferrences where 

"comp_code"=p_compcode;

delete from multipack_rep where sess_id=userenv('sessionid')  ;
delete from multipack_rat where sess_id=userenv('sessionid') ;
DELETE FROM multipack_ratnew where sess_id=userenv('sessionid')  ;

commit;
open c1;
loop
fetch c1 into v1;
exit when c1%notfound;

     v_val:=multipack_report(v1.CIOID,v1.package_code,v1.Crate,v1.chk_var);

    v_edition:=null;v_edipkg:=null;
end loop;
close c1; 
commit;

if(p_chkdetail='Detail')then

if(p_adcheck=1)
then
query1:=query1||'SELECT distinct TBL_BOOKING_MAST."cio_booking_id" AS "CIOID",
to_char(TBL_BOOKING_MAST."date_time",'''||p_dateformat||''') as "BookDate",
AGENCY_MAST."Agency_Name" AS "Agency",
NVL((SELECT "Cust_Name" FROM CUST_MAST WHERE 

"Cust_Code"="Client_code"),"Client_code")  AS "Client",
"RO_No" AS "RoNo.",
CASE '''||p_dateformat||'''
WHEN ''mm/dd/yyyy'' THEN TO_CHAR("RO_Date",''mm/dd/yyyy'')
WHEN ''dd/mm/yyyy'' THEN TO_CHAR("RO_Date" ,''dd/mm/yyyy'')
WHEN ''yyyy/mm/dd'' THEN TO_CHAR("RO_Date",''yyyy/mm/dd'') END AS "Ro.Date",
(select EXEC_MAST."Exec_name" from exec_mast where 

tbl_booking_mast."Executive_code"=exec_mast."Exe_no") AS "Executive",
(select RETAINERMASTER."Retain_Name"  FROM  RETAINERMASTER where 

RETAINERMASTER."Retain_Code"=tbl_booking_mast.RETAINER ) AS "Retainer",
decode(tbl_booking_mast."Booking_type",''1'',''Barter'',''2'',''FMG'',''3'',''N

ormal'',''4'',''InHouse'',''5'',''Complimentary'',''Normal'') as "BookType",
(select col_mast."Col_Alias" from col_mast where 

tbl_booking_mast."Color_code"=col_mast."Col_Code") as "Color",
adv_cat_mast."Adv_Cat_Name" as "Adcat",
(select adv_subcat_mast."Adv_Subcat_Name" from adv_subcat_mast where 

tbl_booking_mast."Ad_sub_cat_code"=adv_subcat_mast."Adv_Subcat_Code" and  

adv_cat_mast."Adv_Cat_Code"=adv_subcat_mast."Adv_Cat_Code")as "Adsubcat",
(select ad_cat3."catname" from ad_cat3,adv_subcat_mast  where 

tbl_booking_mast."Ad_Subcat3"=ad_cat3."catcode" and 

ad_cat3."subcatname"=adv_subcat_mast."Adv_Subcat_Code" and 

tbl_booking_mast."Ad_sub_cat_code"=adv_subcat_mast."Adv_Subcat_Code" and  

adv_cat_mast."Adv_Cat_Code"=adv_subcat_mast."Adv_Cat_Code") as "Adsubcat3",
(select tbl_cat4."Cat_Name" from tbl_cat4,adv_subcat_mast where 

tbl_booking_mast."Ad_Subcat4"=tbl_cat4."Cat_Code" and 

tbl_cat4."Sub_Cat_Name"=adv_subcat_mast."Adv_Subcat_Code" and 

tbl_booking_mast."Ad_sub_cat_code"=adv_subcat_mast."Adv_Subcat_Code" and  

adv_cat_mast."Adv_Cat_Code"=adv_subcat_mast."Adv_Cat_Code") as "Adsubcat4",
(select tbl_cat5."Cat_Name" from tbl_cat5,adv_subcat_mast where 

tbl_booking_mast."Ad_subcat5"=tbl_cat5."Cat_Code" and 

tbl_cat5."Sub_Cat_Name"=adv_subcat_mast."Adv_Subcat_Code" and 

tbl_booking_mast."Ad_sub_cat_code"=adv_subcat_mast."Adv_Subcat_Code" and  

adv_cat_mast."Adv_Cat_Code"=adv_subcat_mast."Adv_Cat_Code") as "Adsubcat5",
FETCH_PACK(tbl_booking_mast."cio_booking_id") AS "Package",
to_char(tbl_booking_mast."Insertion_date",'''||p_dateformat||''') as "PubDate",
tbl_booking_mast."No_of_insertion" as "noinsert",
tbl_booking_mast."Paid_ins" as "Paidinsert",
tbl_booking_mast."Ad_size_height" as "height",
 tbl_booking_mast."Ad_size_width" as "width",
tbl_booking_mast."Total_area" as "Area",
(select ADVPOS_PREM_MAST."premiumname" from advpos_prem_mast where 

tbl_booking_mast."Page_prem"=ADVPOS_PREM_MAST."Premiumcode") as "Pagepremium",
(select advpos_type_mast."Pos_Type" from advpos_type_mast where 

tbl_booking_mast."Page_position_code"=advpos_type_mast."Pos_Type_Code") as 

"Postprem",
(select scheme_master."Scheme_Name" from scheme_master where 

tbl_booking_mast."Scheme_type_code"=scheme_master."scheme_id") as "scheme",
tbl_booking_mast."Rate_code" as "Ratecode",
tbl_booking_mast."Card_rate" as "cardrate",
tbl_booking_mast."Card_amount" as "cardamt",
tbl_booking_mast."Contract_rate" as "contractrate",
TBL_BOOKING_mast."Deviation" as "Deviationamt",
TBL_BOOKING_mast."Deviation" AS "Deviation(%)",
tbl_booking_mast."Agrred_rate" as "Aggrate",
tbl_booking_mast."Agreed_amount" as "aggamt",
(tbl_booking_mast."Card_amount" - 

DECODE(NVL(tbl_booking_mast."Agreed_amount",0),0,tbl_booking_mast."Card_amount"

,tbl_booking_mast."Agreed_amount")) as "DiscAmt",
tbl_booking_mast."Discount_per" as "Discper",
(select SUM(nvl(RAT,0)) from multipack_rat where 

cioid=tbl_booking_mast."cio_booking_id"  and 

sess_id='||userenv('sessionid')||') as  "posamt",
(select SUM(nvl(PER_AMT,0)) from multipack_rat where 

cioid=tbl_booking_mast."cio_booking_id"   and 

sess_id='||userenv('sessionid')||') as "pos(%)",
round(((tbl_booking_mast."Special_disc_per" * tbl_booking_mast."Total_area" * 

tbl_booking_mast."Card_rate")/100),2) as "Spdiscamt",
tbl_booking_mast."Special_disc_per" as "Spdiscper",
round(((tbl_booking_mast."Space_disc_per" * tbl_booking_mast."Total_area" * 

tbl_booking_mast."Card_rate")/100),2) as "Spacedisc",
tbl_booking_mast."Space_disc_per" as "Spacediscper",
tbl_booking_mast."Special_charges" as "Specialcharge",
nvl(tbl_booking_mast."ADD_AGENCY_COMM",''0'') as "AgencyAddlTD(%)",
nvl((nvl(tbl_booking_mast."Gross_amount",''0'')*nvl(tbl_booking_mast."ADD_AGENC

Y_COMM",''0'')/100),''0'') as "AgencyAddlTDAmt",
nvl(tbl_booking_mast."Gross_amount",''0'') as "Grossamt",
(select DISTINCT TO_NUMBER(NVL("Comm_Rate",''0''))    from RET_COMM_DETAILS 

WHERE "Comp_code"='''|| p_compcode ||''' and 

"Retain_Code"=nvl(tbl_booking_mast."RETAINER",''0'') AND 

"Eff_from_Date"=(SELECT MAX("Eff_from_Date") FROM RET_COMM_DETAILS WHERE 

"Comp_code"='''|| p_compcode ||''' and 

"Retain_Code"=nvl(tbl_booking_mast."RETAINER",''0'')) AND ROWNUM<=1 ) as 

"RetTD(%)",
nvl(tbl_booking_mast."Gross_amount",''0'')*(select DISTINCT 

TO_NUMBER(NVL("Comm_Rate",''0''))    from RET_COMM_DETAILS WHERE 

"Comp_code"='''|| p_compcode ||''' and 

"Retain_Code"=nvl(tbl_booking_mast."RETAINER",''0'') AND 

"Eff_from_Date"=(SELECT MAX("Eff_from_Date") FROM RET_COMM_DETAILS WHERE 

"Comp_code"='''|| p_compcode ||''' and 

"Retain_Code"=nvl(tbl_booking_mast."RETAINER",''0'')) AND ROWNUM<=1 )/100 as 

"RetTDAmt",
nvl(tbl_booking_mast."Trade_disc",''0'' )as "AgencyTD(%)",
(nvl(tbl_booking_mast."Gross_amount",''0'')* 

nvl(tbl_booking_mast."Trade_disc",''0'' )/100 )as "AgencyTDAmt",
nvl(tbl_booking_mast."Bill_amount",''0'') as "Billamt",
nvl(case( '''||prefer||''' ) 
    when ''Y'' then
        ( CASE (select DISTINCT "Discount" from RET_COMM_DETAILS WHERE 

"Comp_code"='''|| p_compcode ||''' and 

"Retain_Code"=nvl(tbl_booking_mast."RETAINER",''0'') AND 

"Eff_from_Date"=(SELECT MAX("Eff_from_Date") FROM RET_COMM_DETAILS WHERE 

"Comp_code"='''|| p_compcode ||''' and 

"Retain_Code"=nvl(tbl_booking_mast."RETAINER",''0'')) AND ROWNUM<=1)
         when ''Gross'' then
                (
                 CASE to_number(nvl(TBL_BOOKING_MAST.RETAINER_COMM,0))
                 WHEN 0 THEN 0
                 ELSE 

(to_number(nvl(TBL_BOOKING_MAST.RETAINER_COMM,''0''))-to_number(nvl(tbl_booking

_mast."ADD_AGENCY_COMM",''0'' )))
                 end )
         when ''Net''   then  

to_number(nvl(TBL_BOOKING_MAST.RETAINER_COMM,''0''))
        END )
       
    ELSE (select 0  from dual)
end  ,''0'') as "RetComm(%)",
nvl(
case( '''||prefer||''' ) 
    when ''Y'' then
        ( CASE (select DISTINCT "Discount" from RET_COMM_DETAILS WHERE 

"Comp_code"='''|| p_compcode ||''' and 

"Retain_Code"=nvl(tbl_booking_mast."RETAINER",''0'') AND 

"Eff_from_Date"=(SELECT MAX("Eff_from_Date") FROM RET_COMM_DETAILS WHERE 

"Comp_code"='''|| p_compcode ||''' and 

"Retain_Code"=nvl(tbl_booking_mast."RETAINER",''0'')) AND ROWNUM<=1)
         when ''Gross'' then 
                 (
                 CASE to_number(nvl(TBL_BOOKING_MAST.RETAINER_COMM_AMT,0))
                 WHEN 0 THEN 0
                 ELSE 

(to_number(nvl(TBL_BOOKING_MAST.RETAINER_COMM_AMT,''0''))-(nvl((nvl(tbl_booking

_mast."Gross_amount",''0'')*to_number(nvl(tbl_booking_mast."ADD_AGENCY_COMM",''

0''))/100),''0'')))
                 end )
         
          
         when ''Net''   then  

(nvl(tbl_booking_mast."Gross_amount",''0'')*(to_number(nvl(TBL_BOOKING_MAST.RET

AINER_COMM,''0'')) )/100)
        END )
       
    ELSE (select 0  from dual)
end
,''0'') as "RetCommAmt",
minus_to_zero(nvl((  NVL(tbl_booking_mast."Bill_amount",''0'')-
nvl(
case( '''||prefer||''' ) 
    when ''Y'' then
        ( CASE (select DISTINCT "Discount" from RET_COMM_DETAILS WHERE 

"Comp_code"='''|| p_compcode ||''' and 

"Retain_Code"=nvl(tbl_booking_mast."RETAINER",''0'') AND 

"Eff_from_Date"=(SELECT MAX("Eff_from_Date") FROM RET_COMM_DETAILS WHERE 

"Comp_code"='''|| p_compcode ||''' and 

"Retain_Code"=nvl(tbl_booking_mast."RETAINER",''0'')) AND ROWNUM<=1)
         when ''Gross'' then 
         
                 (
                 CASE to_number(nvl(TBL_BOOKING_MAST.RETAINER_COMM_AMT,0))
                 WHEN 0 THEN 0
                 ELSE 

(to_number(nvl(TBL_BOOKING_MAST.RETAINER_COMM_AMT,''0''))-(nvl((nvl(tbl_booking

_mast."Gross_amount",''0'')*to_number(nvl(tbl_booking_mast."ADD_AGENCY_COMM",''

0''))/100),''0'')))
                 end )
                
          
         when ''Net''   then  

(nvl(tbl_booking_mast."Gross_amount",''0'')*(to_number(nvl(TBL_BOOKING_MAST.RET

AINER_COMM,''0'')) )/100)
        END )
       
    ELSE (select 0  from dual)
end
,''0'') ),''0'')) as "ActualBusiness",

(SELECT BRANCH_MST."Branch_Name" FROM BRANCH_MST WHERE 

tbl_booking_mast."Revenue_center"=BRANCH_MST."Branch_Code" )as "Revcenter",
UOM_MAST."Uom_Name"  AS "Uom",
uom_mast.UOM_DESC as "uomdesc"
,(select pub_cent_mast."Pub_Cent_name" from pub_cent_mast where 

pub_cent_mast."Pub_cent_Code" in(select "pub_center" from  BRANCH_MST WHERE 

TBL_BOOKING_MAST."branch"="Branch_Name") ) as "Printcenter"
--old version
,tbl_booking_mast."branch" as "Branch"
--new version
--,(SELECT "Branch_Name" FROM BRANCH_MST where  TBL_BOOKING_mast."branch" = 

"Branch_Code") as "Branch"


,case '''||p_base||'''
when ''1'' then  AGENCY_MAST."Dist_Code"
when ''2'' then (select dist_mst."Dist_Name" from dist_mst where 

dist_mst."Dist_Code" in(select exec_mast."dist_code" from exec_mast where  

exec_mast."Exe_no"=tbl_booking_mast."Executive_code" )  )
when ''3'' then (select dist_mst."Dist_Name" from dist_mst where 

dist_mst."Dist_Code" in(select RETAINERMASTER."Dist_Code" from RETAINERMASTER 

where  RETAINERMASTER."Retain_Code"= tbl_booking_mast.RETAINER )  ) end as 

"District"
,case '''||p_base||'''
when ''1'' then (select taluka_mast.TALU_NAME  from taluka_mast where 

AGENCY_MAST.TALUKA=taluka_mast.TALU_CODE )
when ''2'' then (select taluka_mast.TALU_NAME  from taluka_mast where 

taluka_mast.TALU_CODE in(select exec_mast.TALUKA from exec_mast where  

exec_mast."Exe_no"=tbl_booking_mast."Executive_code" )  )
when ''3'' then (select taluka_mast.TALU_NAME  from taluka_mast where 

taluka_mast.TALU_CODE in(select RETAINERMASTER.TALUKA from RETAINERMASTER where 

 RETAINERMASTER."Retain_Code"= tbl_booking_mast.RETAINER )  ) end as "Taluka"
,nvl(TBL_BOOKING_MAST."Page_no",0) as "Page_No"
,CASHDISCOUNT as "Cash_Disc"
,"Box_code" as "BoxCode"
FROM TBL_BOOKING_MAST,AGENCY_MAST ,UOM_MAST,
adv_cat_mast,
adv_type_mast,
TBL_BOOKING_insert
WHERE TBL_BOOKING_MAST."Comp_code"='''||p_compcode||''' AND
 UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
tbl_booking_mast."Ad_cat_code"=adv_cat_mast."Adv_Cat_Code" and
tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code"
and adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id"
and ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from 

login_center where newuser_id='''||p_puserid||''') and 

'''||p_chk_access||'''=''1'')
or  ('''||p_chk_access||'''=''0'') )' ;


if(p_base='2')then
query1:=query1||' and (tbl_booking_mast."Executive_code" is not null and 

tbl_booking_mast."Executive_code" !=''0'')  ';
end if;

if(p_base='3')then
query1:=query1||' and (tbl_booking_mast.RETAINER is not null  and 

tbl_booking_mast.RETAINER !=''0'')  ';
end if;


if(p_drpstatus is null) then
query1:=query1||' and lower("Insert_Status")!='''||'cancel'||'''';
end if;

if(p_insertstatus is not null) then
query1:=query1||' and lower("Insert_Status")='''||p_insertstatus||'''';
end if;

IF(p_fromdate IS NOT NULL AND p_dateto IS NULL  and  p_filterby='Booking Date')
THEN
query1:=query1||' and tbl_booking_mast."date_time" ='''||p_fromdate||'''';
END IF;

IF(p_fromdate IS NOT NULL AND p_dateto IS NOT NULL and p_filterby='Booking 

Date' )
THEN
query1:=query1||' and tbl_booking_mast."date_time" between  '''||p_fromdate 

||''' and  '''||p_dateto||''' ';
END IF;

IF(p_fromdate IS NOT NULL AND p_dateto IS NULL  and  p_filterby='Publish Date')
THEN
query1:=query1||' and tbl_booking_mast."Insertion_date" ='''||p_fromdate||'''';
END IF;

IF(p_fromdate IS NOT NULL AND p_dateto IS NOT NULL and p_filterby='Publish 

Date' )
THEN
query1:=query1||' and tbl_booking_mast."Insertion_date"  between  

'''||p_fromdate ||''' and  '''||p_dateto||''' ';
END IF;

IF(p_publication IS NOT NULL)
THEN
query1:=query1||' and 

TBL_BOOKING_insert."Publication_Code"='''||p_publication||'''    ';
END IF;

--old version
IF(p_pub_cent IS NOT NULL)
THEN
query1:=query1||'  and TBL_BOOKING_MAST."branch" IN (SELECT "Branch_Name" FROM 

BRANCH_MST WHERE TBL_BOOKING_MAST."branch"="Branch_Name" and "pub_center" in 

(SELECT "Pub_cent_Code" FROM PUB_CENT_MAST WHERE  

branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" and 

"Pub_cent_Code"='''||p_pub_cent||'''))';
END IF;


IF(p_branch IS NOT NULL)
THEN
query1:=query1||'  and tbl_booking_mast."branch" ='''||p_branch||'''';
END IF;


--new version
/*IF(p_pub_cent IS NOT NULL)
THEN
query1:=query1||'  and TBL_BOOKING_MAST."branch" IN (SELECT "Branch_Code" FROM 

BRANCH_MST WHERE TBL_BOOKING_MAST."branch"="Branch_Code" and "pub_center" in 

(SELECT "Pub_cent_Code" FROM PUB_CENT_MAST WHERE  

branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" and 

"Pub_cent_Code"='''||p_pub_cent||'''))';
END IF;


IF(p_branch IS NOT NULL)
THEN
query1:=query1||'  and TBL_BOOKING_mast."branch" = (SELECT "Branch_Code" FROM 

BRANCH_MST where "Branch_Name" ='''||p_branch||''') ';
END IF;
*/

IF(p_edition IS NOT NULL)
THEN
query1:=query1||'  and tbl_booking_insert."Edition_Code"='''||p_edition||'''';
END IF;

IF(p_region IS NOT NULL)
THEN
query1:=query1 ||' and agency_mast."region" ='''||p_region ||''' ';
END IF;

IF(p_revcenter IS NOT NULL)
THEN
query1:=query1 ||' and tbl_booking_mast."Revenue_center" 

='''||p_revcenter||'''';
END IF;

IF(p_adtype IS NOT NULL)
THEN
query1:=query1 || ' and TBL_BOOKING_MAST."Ad_type_code"='''||p_adtype||'''';
END IF;

IF(p_agencytype IS NOT NULL)
THEN
query1:=query1 || ' and TBL_BOOKING_MAST."Agency_type" 

='''||p_agencytype||'''';
END IF;

IF(p_adcat IS NOT NULL)
THEN
query1:=query1 || ' and TBL_BOOKING_MAST."Ad_cat_code" ='''||p_adcat||'''';
END IF;

IF(p_adsubcat IS NOT NULL)
THEN
query1:=query1 || ' and TBL_BOOKING_MAST."Ad_sub_cat_code" 

='''||p_adsubcat||'''';
END IF;

IF(p_adsubcat3 IS NOT NULL)
THEN
query1:=query1 || ' and TBL_BOOKING_MAST."Ad_Subcat3" ='''||p_adsubcat3||'''';
END IF;

IF(p_adsubcat4 IS NOT NULL)
THEN
query1:=query1 || ' and TBL_BOOKING_MAST."Ad_Subcat4" ='''||p_adsubcat4||'''';
END IF;

IF(p_adsubcat5 IS NOT NULL)
THEN
query1:=query1 || ' and TBL_BOOKING_MAST."Ad_subcat5" ='''||p_adsubcat5||'''';
END IF;

IF(p_package IS NOT NULL)
THEN
query1:=query1 || ' and TBL_BOOKING_MAST."Package_code" ='''||p_package||'''';
END IF;

IF(p_scheme IS NOT NULL)
THEN
query1:=query1 || ' and TBL_BOOKING_MAST."Scheme_type_code" 

='''||p_scheme||'''';
END IF;

IF(p_agency IS NOT NULL)
THEN
query1:=query1 || ' and TBL_BOOKING_MAST."Agency_code" ='''||p_agency||'''';
END IF;

IF(p_client IS NOT NULL)
THEN
query1:=query1 || ' and TBL_BOOKING_MAST."Client_code" ='''||p_client||'''';
END IF;

IF(p_executive IS NOT NULL)
THEN
query1:=query1 || ' and TBL_BOOKING_MAST."Executive_code" 

='''||p_executive||'''';
END IF;

IF(p_retainer IS NOT NULL)
THEN
query1:=query1 || ' and TBL_BOOKING_MAST.RETAINER ='''||p_retainer||'''';
END IF;

IF(p_product IS NOT NULL)
THEN
query1:=query1 || ' and TBL_BOOKING_MAST."Product_code" ='''||p_product||'''';
END IF;

IF(p_brand IS NOT NULL)
THEN
query1:=query1 || ' and TBL_BOOKING_MAST."Brand_code" ='''||p_brand||'''';
END IF;

IF(p_varient IS NOT NULL)
THEN
query1:=query1 || ' and TBL_BOOKING_MAST."Variant_code" ='''||p_varient||'''';
END IF;

IF(p_pagetype IS NOT NULL)
THEN
query1:=query1 || ' and TBL_BOOKING_MAST."Page_type_code" 

='''||p_pagetype||'''';
END IF;

IF(p_pageprem IS NOT NULL)
THEN
query1:=query1 || ' and TBL_BOOKING_MAST."Page_prem" ='''||p_pageprem||'''';
END IF;

IF(p_postprem IS NOT NULL)
THEN
query1:=query1 || ' and TBL_BOOKING_MAST."Page_position_code" 

='''||p_postprem||'''';
END IF;

IF(p_rostatus IS NOT NULL)
THEN
query1:=query1 || ' and TBL_BOOKING_MAST."ro_status" ='''||p_rostatus||'''';
END IF;

IF(p_booktype IS NOT NULL)
THEN
query1:=query1 || ' and TBL_BOOKING_MAST."Booking_type" ='''||p_booktype||'''';
END IF;

IF(p_contractname  IS NOT NULL)
THEN
query1:=query1 || ' and TBL_BOOKING_MAST."Contract_name" ='''||p_contractname 

||'''';
END IF;

IF(p_suppliment  IS NOT NULL)
THEN
query1:=query1 || ' and tbl_booking_insert."Supp_Code" 

='''||p_suppliment||'''';
END IF;

IF(p_ratetype  IS NOT NULL)
THEN
query1:=query1 || ' and tbl_booking_MAST."Rate_code" ='''||p_ratetype||'''';
END IF;

IF(p_city  IS NOT NULL)
THEN
if(p_base='1')then
query1:=query1 || ' and AGENCY_MAST."City_Code" ='''||p_city||'''';
end if;

if(p_base='2')then
query1:=query1 || ' and tbl_booking_mast."Executive_code" in(select 

exec_mast."Exe_no" from exec_mast where exec_mast."city_code" ='''||p_city||''' 

)';
end if;

if(p_base='3')then
query1:=query1 || ' and tbl_booking_mast.RETAINER in(select 

RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  

RETAINERMASTER."City_Code"='''||p_city||''')';
end if;
END IF;

IF(p_zone  IS NOT NULL)
THEN
if(p_base='1')then
query1:=query1 || ' and AGENCY_MAST."zone_code" ='''||p_zone||'''';
end if;

if(p_base='2')then
query1:=query1 || ' and tbl_booking_mast."Executive_code" in(select 

exec_mast."Exe_no" from exec_mast where exec_mast."city_code" in (select 

city_mst."City_Code" from city_mst where city_mst."Zone_Code"= 

'''||p_zone||''') )';
end if;

if(p_base='3')then
query1:=query1 || ' and tbl_booking_mast.RETAINER in(select 

RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  

RETAINERMASTER."Zone_Code"='''||p_zone||''')';
end if;
END IF;

IF(p_district  IS NOT NULL)
THEN
if(p_base='1')then
query1:=query1 || ' and AGENCY_MAST."Dist_Code" ='''||p_district||'''';
end if;

if(p_base='2')then
query1:=query1 || ' and tbl_booking_mast."Executive_code" in(select 

exec_mast."Exe_no" from exec_mast where exec_mast."dist_code" 

='''||p_district||''' )';
end if;

if(p_base='3')then
query1:=query1 || ' and tbl_booking_mast.RETAINER in(select 

RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  

RETAINERMASTER."Dist_Code"='''||p_district||''')';
end if;
END IF;

IF(p_state  IS NOT NULL)
THEN
if(p_base='1')then
query1:=query1 || ' and AGENCY_MAST."State_Code" ='''||p_state||'''';
end if;

if(p_base='2')then
query1:=query1 || ' and tbl_booking_mast."Executive_code" in(select 

exec_mast."Exe_no" from exec_mast where exec_mast."State_code" 

='''||p_state||''' )';
end if;

if(p_base='3')then
query1:=query1 || ' and tbl_booking_mast.RETAINER in(select 

RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  

RETAINERMASTER."State_Code"='''||p_state||''')';
end if;
END IF;

IF(p_taluka  IS NOT NULL)
THEN
if(p_base='1')then
query1:=query1 || ' and AGENCY_MAST.TALUKA='''||p_taluka||'''  ';
end if;

if(p_base='2')then
query1:=query1 || ' and tbl_booking_mast."Executive_code" in(select 

exec_mast."Exe_no" from exec_mast where exec_mast.TALUKA ='''||p_taluka||''' 

)';
end if;

if(p_base='3')then
query1:=query1 || ' and tbl_booking_mast.RETAINER in(select 

RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  

RETAINERMASTER.TALUKA='''||p_taluka||''')';
end if;
END IF;

query1:=query1 || ' order by TBL_BOOKING_MAST."cio_booking_id"';


--insert into searchtbl values(query1);
--commit;
OPEN p_recordset1 FOR
query1;


elsif(p_adcheck=2)then
delete from temp_ad_bills_report where sess_id=userenv('sessionid')  ;
open c2;
loop
fetch c2 into v2;
exit when c2%notfound;
--insert into test_amit(a,b)values('amit-',v2.BILLNO);commit;

         

v_val:=FUN_BILL_INSERT(p_compcode,v2.CIOID,v2.BILLNO,prefer,p_dateformat,v2.AGM

AINCODE,v2.AG_SUB_CODE,v2.AGCODE,v2.AGNAME,v2.EXECCODE,v2.EXECNAME,v2.RETCODE,v

2.RETNAME,p_base );    
end loop;
close c2;
commit;

query2:=query2 || 'select CIOID AS "CIOID",BILLNO AS "Billno" ,AGENCY AS 

"Agency", CLIENT AS "Client" ,
RONO  AS "RoNo.",
CASE '''||p_dateformat||'''
WHEN ''mm/dd/yyyy'' THEN TO_CHAR(RODATE ,''mm/dd/yyyy'')
WHEN ''dd/mm/yyyy'' THEN TO_CHAR(RODATE ,''dd/mm/yyyy'')
WHEN ''yyyy/mm/dd'' THEN TO_CHAR(RODATE,''yyyy/mm/dd'') END AS "Ro.Date",
EXECUTIVE  AS "Executive",RETAINER  AS "Retainer" ,BOOKTYPE as "BookType",COLOR 

as "Color",ADCAT as "Adcat",
ADSUBCAT as "Adsubcat",ADSUBCAT3 as "Adsubcat3",ADSUBCAT4  as 

"Adsubcat4",ADSUBCAT5 as "Adsubcat5",PACKAG AS "Package",
to_char(BILLDATE,'''||p_dateformat||''') as "BillDate",
NOINSERT as "noinsert",PAIDINSERT as "Paidinsert" ,HEIGHT as "height",WIDTH as 

"width",AREA as "Area",PAGEPREMIUM as "Pagepremium",POSTPREM as "Postprem",
SCHEME as "scheme",RATECOD as "Ratecode",CARDRATE as "cardrate",CARDAMT as 

"cardamt",
CONTRACTRATE as "contractrate",DEVIATIONAMT as "Deviationamt",DEVIATIONPER AS 

"Deviation(%)",
AGGRATE as "Aggrate",AGGAMT as "aggamt",DISCAMT as "DiscAmt",DISCPER as 

"Discper",
POSAMT as  "posamt",POSPER as "pos(%)",SPDISCAMT as "Spdiscamt",
SPDISCPER as "Spdiscper",SPACEDISC as "Spacedisc",SPACEDISCPER as 

"Spacediscper",SPECIALCHARGE as "Specialcharge",AGENCYADDLTDPER  as 

"AgencyAddlTD(%)",
AGENCYADDLTDAMT as "AgencyAddlTDAmt",GROSSAMT as "Grossamt",
RETTDPER as "RetTD(%)",RETTDAMT as "RetTDAmt",AGENCYTDPER as 

"AgencyTD(%)",AGENCYTDAMT as "AgencyTDAmt",BILLAMT as "Billamt",
RETCOMMPER as "RetComm(%)",RETCOMMAMT as 

"RetCommAmt",minus_to_zero(ACTUALBUSINESS) as "ActualBusiness",
REVCENTER as "Revcenter",UOM AS "Uom",UOMDESC as "uomdesc"
,PUB_CENT_NAME as "Printcenter"
,BRANCH_NAME  as "Branch"
,DIST_NAME as "District"
,TALU_NAME as "Taluka"
,PAGE_NO as "Page_No"
from temp_ad_bills_report where sess_id='||userenv('sessionid');

IF(p_fromdate IS NOT NULL AND p_dateto IS NOT NULL )
THEN
query2:=query2||' and BILLDATE between  '''||p_fromdate ||''' and  

'''||p_dateto||''' ';
END IF;

IF(p_publication IS NOT NULL)
THEN
query2:=query2||' and PRIPUB='''||p_publication||'''';
END IF;

IF(p_pub_cent IS NOT NULL)
THEN
query2:=query2||'   and PUB_CENT_CODE='''||p_pub_cent||'''';
END IF;

IF(p_edition IS NOT NULL)
THEN
query2:=query2||'  and PEDITION='''||p_edition||'''';
END IF;

IF(p_branch IS NOT NULL)
THEN
query2:=query2||'  and  BRANCH_NAME ='''||p_branch||''' ';
END IF;

IF(p_region IS NOT NULL)
THEN
query2:=query2 ||' and REGION='''||p_region ||'''';
END IF;

IF(p_adtype IS NOT NULL)
THEN
query2:=query2 || ' and PADTYPE='''||p_adtype||'''';
END IF;

IF(p_agencytype IS NOT NULL)
THEN
query2:=query2 || ' and AGENCY_TYPE_CODE= '''||p_agencytype||'''';
END IF;

IF(p_adcat IS NOT NULL)
THEN
query2:=query2 || ' and PRIADCTG='''||p_adcat||'''';
END IF;

IF(p_adsubcat IS NOT NULL)
THEN
query2:=query2 || ' and SECADCTG ='''||p_adsubcat||'''';
END IF;

IF(p_adsubcat3 IS NOT NULL)
THEN
query2:=query2 || ' and AD_SUBCAT3 ='''||p_adsubcat3||'''';
END IF;

IF(p_adsubcat4 IS NOT NULL)
THEN
query2:=query2 || ' and AD_SUBCAT4 ='''||p_adsubcat4||'''';
END IF;

IF(p_adsubcat5 IS NOT NULL)
THEN
query2:=query2 || ' and AD_SUBCAT5 ='''||p_adsubcat5||'''';
END IF;

IF(p_package IS NOT NULL)
THEN
query2:=query2 || ' and PACKAGE_CODE='''||p_package||'''';
END IF;

IF(p_agency IS NOT NULL)
THEN
query2:=query2 || ' and AG_MAIN_CODE ='''||p_agency ||'''';
END IF;

IF(p_client IS NOT NULL)
THEN
query2:=query2 || ' and CLIENTCD='''||p_client ||'''';
END IF;

IF(p_executive IS NOT NULL)
THEN
query2:=query2 || ' and EXECUTIVE_NAME='''||p_executive||'''';
END IF;

IF(p_product IS NOT NULL)
THEN
query2:=query2 || ' and PRIPROCTG='''||p_product||'''';
END IF;

IF(p_brand IS NOT NULL)
THEN
query2:=query2 || ' and BRAND_CODE='''||p_brand||'''';
END IF;

IF(p_varient IS NOT NULL)
THEN
query2:=query2 || ' and   VARIENT_NAME='''||p_varient||'''';
END IF;

IF(p_pageprem IS NOT NULL)
THEN
query2:=query2 || ' and PAGE_PREM ='''||p_pageprem||'''';
END IF;

IF(p_postprem IS NOT NULL)
THEN
query2:=query2 || ' and PAGE_POST ='''||p_postprem||'''';
END IF;

IF(p_contractname  IS NOT NULL)
THEN
query2:=query2 || ' and CONTRACT_NAME ='''||p_contractname ||'''';
END IF;

IF(p_suppliment  IS NOT NULL)
THEN
query2:=query2 || ' and SUPP_CODE='''||p_suppliment||'''';
END IF;

IF(p_retainer IS NOT NULL)
THEN
query2:=query2 || ' and RETAINER_CODE='''||p_retainer||'''';
END IF;

IF(p_ratetype  IS NOT NULL)
THEN
query2:=query2 || ' and RATECD ='''||p_ratetype||'''';
END IF;

IF(p_scheme IS NOT NULL)
THEN
query2:=query2 || ' and PSCHEME='''||p_scheme||'''';
END IF;

IF(p_revcenter IS NOT NULL)
THEN
query2:=query2 ||' and REVENUE_CENTER='''||p_revcenter||'''';
END IF;

IF(p_rostatus IS NOT NULL)
THEN
query2:=query2 || ' and RO_STATUS='''||p_rostatus||'''';
END IF;

IF(p_pagetype IS NOT NULL)
THEN
query2:=query2 || ' and PAGE_TYPE ='''||p_pagetype||'''';
END IF;

IF(p_booktype IS NOT NULL)
THEN
query2:=query2 || ' and BOOKING_TYPE='''||p_booktype||'''';
END IF;

IF(p_city  IS NOT NULL)
THEN
query2:=query2 || ' and CITY_CODE ='''||p_city||'''';
END IF;

IF(p_zone  IS NOT NULL)
THEN
query2:=query2 || ' and ZONE_CODE ='''||p_zone||'''';
end if;

IF(p_district  IS NOT NULL)
THEN
query2:=query2 || ' and DIST_CODE ='''||p_district||'''';
end if;

IF(p_state  IS NOT NULL)
THEN
query2:=query2 || ' and STATE_CODE ='''||p_state||'''';
end if;

IF(p_taluka  IS NOT NULL)
THEN
query2:=query2 || ' and PTALUKA='''||p_taluka||'''  ';
end if;


if(p_base='2')then
query2:=query2 ||' and (EXECUTIVE_NAME   is not null and EXECUTIVE_NAME 

!=''0'')  ';
end if;

if(p_base='3')then
query2:=query2 ||' and (RETAINER_CODE  is not null  and RETAINER_CODE  !=''0'') 

 ';
end if;



query2:=query2 || ' order by CIOID';

--delete from searchtbl;
--insert into searchtbl values(query2);
--commit;

OPEN p_recordset1 FOR 
query2;

elsif(p_adcheck=3) then
query3:=query3 ||'SELECT  TBL_BOOKING_MAST."cio_booking_id" AS "CIOID",
to_char(TBL_BOOKING_MAST."date_time",'''||p_dateformat||''') as "BookDate",
AGENCY_MAST."Agency_Name" AS "Agency",
NVL((SELECT "Cust_Name" FROM CUST_MAST WHERE 

"Cust_Code"="Client_code"),"Client_code")  AS "Client",
"RO_No" AS "RoNo.",
CASE '''||p_dateformat||'''
WHEN ''mm/dd/yyyy'' THEN TO_CHAR("RO_Date",''mm/dd/yyyy'')
WHEN ''dd/mm/yyyy'' THEN TO_CHAR("RO_Date" ,''dd/mm/yyyy'')
WHEN ''yyyy/mm/dd'' THEN TO_CHAR("RO_Date",''yyyy/mm/dd'') END AS "Ro.Date",
(select EXEC_MAST."Exec_name" from exec_mast where 

tbl_booking_mast."Executive_code"=exec_mast."Exe_no") AS "Executive",
(select RETAINERMASTER."Retain_Name"  FROM  RETAINERMASTER where 

RETAINERMASTER."Retain_Code"=tbl_booking_mast.RETAINER ) AS "Retainer",
decode(tbl_booking_mast."Booking_type",''1'',''Barter'',''2'',''FMG'',''3'',''N

ormal'',''4'',''InHouse'',''5'',''Complimentary'',''Normal'') as "BookType",
(select col_mast."Col_Alias" from col_mast where tbl_booking_insert."Col_Code" 

=col_mast."Col_Code") as "Color",
adv_cat_mast."Adv_Cat_Name" as "Adcat",
(select adv_subcat_mast."Adv_Subcat_Name" from adv_subcat_mast where 

tbl_booking_mast."Ad_sub_cat_code"=adv_subcat_mast."Adv_Subcat_Code" and  

adv_cat_mast."Adv_Cat_Code"=adv_subcat_mast."Adv_Cat_Code")as "Adsubcat",
(select ad_cat3."catname" from ad_cat3,adv_subcat_mast  where 

tbl_booking_mast."Ad_Subcat3"=ad_cat3."catcode" and 

ad_cat3."subcatname"=adv_subcat_mast."Adv_Subcat_Code" and 

tbl_booking_mast."Ad_sub_cat_code"=adv_subcat_mast."Adv_Subcat_Code" and  

adv_cat_mast."Adv_Cat_Code"=adv_subcat_mast."Adv_Cat_Code") as "Adsubcat3",
(select tbl_cat4."Cat_Name" from tbl_cat4,adv_subcat_mast where 

tbl_booking_mast."Ad_Subcat4"=tbl_cat4."Cat_Code" and 

tbl_cat4."Sub_Cat_Name"=adv_subcat_mast."Adv_Subcat_Code" and 

tbl_booking_mast."Ad_sub_cat_code"=adv_subcat_mast."Adv_Subcat_Code" and  

adv_cat_mast."Adv_Cat_Code"=adv_subcat_mast."Adv_Cat_Code") as "Adsubcat4",
(select tbl_cat5."Cat_Name" from tbl_cat5,adv_subcat_mast where 

tbl_booking_mast."Ad_subcat5"=tbl_cat5."Cat_Code" and 

tbl_cat5."Sub_Cat_Name"=adv_subcat_mast."Adv_Subcat_Code" and 

tbl_booking_mast."Ad_sub_cat_code"=adv_subcat_mast."Adv_Subcat_Code" and  

adv_cat_mast."Adv_Cat_Code"=adv_subcat_mast."Adv_Cat_Code") as "Adsubcat5",
FETCH_PACK(tbl_booking_mast."cio_booking_id") AS "Package",
to_char(tbl_booking_insert."Insert_Date" ,'''||p_dateformat||''') as "PubDate",
 tbl_booking_insert."Height" as "height",
 tbl_booking_insert."Width"  as "width",
tbl_booking_insert."Size_Book" as "Area",
(select ADVPOS_PREM_MAST."premiumname" from advpos_prem_mast where 

tbl_booking_insert."Premium1" =ADVPOS_PREM_MAST."Premiumcode") as 

"Pagepremium",
(select advpos_type_mast."Pos_Type" from advpos_type_mast where 

tbl_booking_insert."Page_Post" =advpos_type_mast."Pos_Type_Code") as 

"Postprem",
(select scheme_master."Scheme_Name" from scheme_master where 

tbl_booking_mast."Scheme_type_code"=scheme_master."scheme_id") as "scheme",
tbl_booking_mast."Rate_code" as "Ratecode",
tbl_booking_mast."Card_rate" as "cardrate",
tbl_booking_mast."Card_rate"*tbl_booking_insert."Size_Book" as "cardamt",
tbl_booking_mast."Contract_rate" as "contractrate",
TBL_BOOKING_mast."Deviation" as "Deviationamt",
TBL_BOOKING_mast."Deviation" AS "Deviation(%)",
tbl_booking_mast."Agrred_rate" as "Aggrate",
tbl_booking_insert."Agreed_Rate"  as "aggamt",
((tbl_booking_mast."Card_rate"*tbl_booking_insert."Size_Book") - 

DECODE(NVL(tbl_booking_insert."Agreed_Rate",0),0,(tbl_booking_mast."Card_rate"*

tbl_booking_insert."Size_Book"),tbl_booking_insert."Agreed_Rate")) as 

"DiscAmt",
tbl_booking_mast."Discount_per" as "Discper",
(select SUM(nvl(RAT,0)) from multipack_rat where 

cioid=tbl_booking_mast."cio_booking_id"  and 

sess_id='||userenv('sessionid')||') as  "posamt",
(select SUM(nvl(PER_AMT,0)) from multipack_rat where 

cioid=tbl_booking_mast."cio_booking_id"   and 

sess_id='||userenv('sessionid')||') as "pos(%)",
round(((tbl_booking_mast."Special_disc_per" * tbl_booking_insert."Size_Book" * 

tbl_booking_mast."Card_rate")/100),2) as "Spdiscamt",
tbl_booking_mast."Special_disc_per" as "Spdiscper",
round(((tbl_booking_mast."Space_disc_per" * tbl_booking_insert."Size_Book" * 

tbl_booking_mast."Card_rate")/100),2) as "Spacedisc",
tbl_booking_mast."Space_disc_per" as "Spacediscper",
tbl_booking_mast."Special_charges" as "Specialcharge",
nvl(tbl_booking_mast."ADD_AGENCY_COMM",''0'') as "AgencyAddlTD(%)",
nvl((nvl(tbl_booking_insert."Gross_Rate" 

,''0'')*nvl(tbl_booking_mast."ADD_AGENCY_COMM",''0'')/100),''0'') as 

"AgencyAddlTDAmt",
nvl(tbl_booking_insert."Gross_Rate",''0'') as "Grossamt",
(select DISTINCT TO_NUMBER(NVL("Comm_Rate",''0''))    from RET_COMM_DETAILS 

WHERE "Comp_code"='''|| p_compcode ||''' and 

"Retain_Code"=nvl(tbl_booking_mast."RETAINER",''0'') AND 

"Eff_from_Date"=(SELECT MAX("Eff_from_Date") FROM RET_COMM_DETAILS WHERE 

"Comp_code"='''|| p_compcode ||''' and 

"Retain_Code"=nvl(tbl_booking_mast."RETAINER",''0'')) AND ROWNUM<=1 ) as 

"RetTD(%)",
nvl(tbl_booking_insert."Gross_Rate",''0'')*(select DISTINCT 

TO_NUMBER(NVL("Comm_Rate",''0''))    from RET_COMM_DETAILS WHERE 

"Comp_code"='''|| p_compcode ||''' and 

"Retain_Code"=nvl(tbl_booking_mast."RETAINER",''0'') AND 

"Eff_from_Date"=(SELECT MAX("Eff_from_Date") FROM RET_COMM_DETAILS WHERE 

"Comp_code"='''|| p_compcode ||''' and 

"Retain_Code"=nvl(tbl_booking_mast."RETAINER",''0'')) AND ROWNUM<=1 )/100 as 

"RetTDAmt",
nvl(tbl_booking_mast."Trade_disc",''0'' )as "AgencyTD(%)",
(nvl(tbl_booking_insert."Gross_Rate",''0'')* 

nvl(tbl_booking_mast."Trade_disc",''0'' )/100 )as "AgencyTDAmt",
NVL(TBL_BOOKING_INSERT."Bill_Amt",''0'') as "Billamt",
nvl(case( '''||prefer||''' ) 
    when ''Y'' then
        ( CASE (select DISTINCT "Discount" from RET_COMM_DETAILS WHERE 

"Comp_code"='''|| p_compcode ||''' and 

"Retain_Code"=nvl(tbl_booking_mast."RETAINER",''0'') AND 

"Eff_from_Date"=(SELECT MAX("Eff_from_Date") FROM RET_COMM_DETAILS WHERE 

"Comp_code"='''|| p_compcode ||''' and 

"Retain_Code"=nvl(tbl_booking_mast."RETAINER",''0'')) AND ROWNUM<=1)
         when ''Gross'' then 
         
               (
                 CASE to_number(nvl(TBL_BOOKING_MAST.RETAINER_COMM,0))
                 WHEN 0 THEN 0
                 ELSE 

(to_number(nvl(TBL_BOOKING_MAST.RETAINER_COMM,''0''))-to_number(nvl(tbl_booking

_mast."ADD_AGENCY_COMM",''0'') ))
                end  )
         
         
         when ''Net''   then  

to_number(nvl(TBL_BOOKING_MAST.RETAINER_COMM,''0''))
        END )
       
    ELSE (select 0  from dual)
end  ,''0'') as "RetComm(%)",

nvl(
case( '''||prefer||''' ) 
    when ''Y'' then
        ( CASE (select DISTINCT "Discount" from RET_COMM_DETAILS WHERE 

"Comp_code"='''|| p_compcode ||''' and 

"Retain_Code"=nvl(tbl_booking_mast."RETAINER",''0'') AND 

"Eff_from_Date"=(SELECT MAX("Eff_from_Date") FROM RET_COMM_DETAILS WHERE 

"Comp_code"='''|| p_compcode ||''' and 

"Retain_Code"=nvl(tbl_booking_mast."RETAINER",''0'')) AND ROWNUM<=1)
         when ''Gross'' then 
         
        
               
                (
                 CASE to_number(nvl(TBL_BOOKING_MAST.RETAINER_COMM_AMT,0))
                 WHEN 0 THEN 0
               -- ELSE 

(to_number(nvl(TBL_BOOKING_MAST.RETAINER_COMM_AMT,''0''))-(nvl((nvl(tbl_booking

_insert."Gross_Rate",''0'')*to_number(nvl(tbl_booking_mast."ADD_AGENCY_COMM",''

0''))/100),''0'')))
                else 

(nvl(tbl_booking_insert."Gross_Rate",0)*(to_number(nvl(TBL_BOOKING_MAST.RETAINE

R_COMM,''0''))-to_number(nvl(tbl_booking_mast."ADD_AGENCY_COMM",''0'')) )/100)
                 end )
         
         
          
         when ''Net''   then  

(nvl(tbl_booking_insert."Gross_Rate",''0'')*(to_number(nvl(TBL_BOOKING_MAST.RET

AINER_COMM,''0'')) )/100)
        END )
       
    ELSE (select 0  from dual)
end
,''0'') as "RetCommAmt",


minus_to_zero(nvl((  NVL(TBL_BOOKING_INSERT."Bill_Amt",''0'')-
nvl(
case( '''||prefer||''' ) 
    when ''Y'' then
        ( CASE (select DISTINCT "Discount" from RET_COMM_DETAILS WHERE 

"Comp_code"='''|| p_compcode ||''' and 

"Retain_Code"=nvl(tbl_booking_mast."RETAINER",''0'') AND 

"Eff_from_Date"=(SELECT MAX("Eff_from_Date") FROM RET_COMM_DETAILS WHERE 

"Comp_code"='''|| p_compcode ||''' and 

"Retain_Code"=nvl(tbl_booking_mast."RETAINER",''0'')) AND ROWNUM<=1)
         when ''Gross'' then 
           (
                 CASE to_number(nvl(TBL_BOOKING_MAST.RETAINER_COMM_AMT,0))
                 WHEN 0 THEN 0
                -- ELSE 

(to_number(nvl(TBL_BOOKING_MAST.RETAINER_COMM_AMT,''0''))-(nvl((nvl(tbl_booking

_insert."Gross_Rate",''0'')*to_number(nvl(tbl_booking_mast."ADD_AGENCY_COMM",''

0''))/100),''0'')))
                 else 

(nvl(tbl_booking_insert."Gross_Rate",0)*(to_number(nvl(TBL_BOOKING_MAST.RETAINE

R_COMM,''0''))-to_number(nvl(tbl_booking_mast."ADD_AGENCY_COMM",''0'')) )/100)
               
                 end )
          
         when ''Net''   then  

(nvl(tbl_booking_insert."Gross_Rate",''0'')*(to_number(nvl(TBL_BOOKING_MAST.RET

AINER_COMM,''0'')) )/100)
        END )
       
    
    
    ELSE (select 0  from dual)
end
,''0'') ),''0'')) as "ActualBusiness",
(SELECT BRANCH_MST."Branch_Name" FROM BRANCH_MST WHERE 

tbl_booking_mast."Revenue_center"=BRANCH_MST."Branch_Code" )as "Revcenter"
,UOM_MAST."Uom_Name"  AS "Uom",
pub_mast."Pub_Name" as "Publication",
TBL_BOOKING_INSERT."Edition" as "Edition",
uom_mast.UOM_DESC as "uomdesc"
,(select pub_cent_mast."Pub_Cent_name" from pub_cent_mast where 

pub_cent_mast."Pub_cent_Code" in(select "pub_center" from  BRANCH_MST WHERE 

TBL_BOOKING_MAST."branch"="Branch_Name") ) as "Printcenter"
--old version
,tbl_booking_mast."branch" as "Branch"
--new version
--,(SELECT "Branch_Name" FROM BRANCH_MST where  TBL_BOOKING_mast."branch" = 

"Branch_Code") as "Branch"

,case '''||p_base||'''
when ''1'' then  AGENCY_MAST."Dist_Code"
when ''2'' then (select dist_mst."Dist_Name" from dist_mst where 

dist_mst."Dist_Code" in(select exec_mast."dist_code" from exec_mast where  

exec_mast."Exe_no"=tbl_booking_mast."Executive_code" )  )
when ''3'' then (select dist_mst."Dist_Name" from dist_mst where 

dist_mst."Dist_Code" in(select RETAINERMASTER."Dist_Code" from RETAINERMASTER 

where  RETAINERMASTER."Retain_Code"= tbl_booking_mast.RETAINER )  ) end as 

"District"
,case '''||p_base||'''
when ''1'' then (select taluka_mast.TALU_NAME  from taluka_mast where 

AGENCY_MAST.TALUKA=taluka_mast.TALU_CODE )
when ''2'' then (select taluka_mast.TALU_NAME  from taluka_mast where 

taluka_mast.TALU_CODE in(select exec_mast.TALUKA from exec_mast where  

exec_mast."Exe_no"=tbl_booking_mast."Executive_code" )  )
when ''3'' then (select taluka_mast.TALU_NAME  from taluka_mast where 

taluka_mast.TALU_CODE in(select RETAINERMASTER.TALUKA from RETAINERMASTER where 

 RETAINERMASTER."Retain_Code"= tbl_booking_mast.RETAINER )  ) end as "Taluka"
,tbl_booking_insert."Page_No" as "Page_No"
,CASHDISCOUNT as "Cash_Disc"
,"Insert_Status" as "Status"
,"Box_code" as "BoxCode"
FROM TBL_BOOKING_MAST,AGENCY_MAST ,uom_mast,
adv_cat_mast,
adv_type_mast,pub_mast,
TBL_BOOKING_insert
WHERE TBL_BOOKING_MAST."Comp_code"='''||p_compcode||''' AND
UOM_MAST."Uom_Code"=TBL_BOOKING_MAST."Uom_code" and
TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
tbl_booking_insert."Ad_Cat" =adv_cat_mast."Adv_Cat_Code" and
tbl_booking_mast."Ad_type_code"=adv_type_mast."Adv_Type_Code"
and adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
pub_mast."Pub_Code"=TBL_BOOKING_insert."Publication_Code" and
tbl_booking_mast."cio_booking_id"=tbl_booking_insert."Cio_Booking_Id" 
and ((tbl_booking_insert."Pub_Cent_Code" in (select distinct pub_center from 

login_center where newuser_id='''||p_puserid||''') and 

'''||p_chk_access||'''=''1'')
or  ('''||p_chk_access||'''=''0'') )' ;

if(p_base='2')then
query3:=query3 ||' and (tbl_booking_mast."Executive_code" is not null and 

tbl_booking_mast."Executive_code" !=''0'')  ';
end if;

if(p_base='3')then
query3:=query3 ||' and (tbl_booking_mast.RETAINER is not null  and 

tbl_booking_mast.RETAINER !=''0'')  ';
end if;


if(p_drpstatus is null) then
query3:=query3||' and lower("Insert_Status")!='''||'cancel'||'''';
end if;


if(p_insertstatus is not null) then
query3:=query3||' and lower("Insert_Status")='''||p_insertstatus||'''';
end if;


IF(p_fromdate IS NOT NULL AND p_dateto IS NULL )
THEN
query3:=query3 ||' and tbl_booking_insert."Insert_Date" ='''||p_fromdate||'''';
END IF;

IF(p_fromdate IS NOT NULL AND p_dateto IS NOT NULL)
THEN
query3:=query3 ||' and tbl_booking_insert."Insert_Date" between  

'''||p_fromdate ||''' and  '''||p_dateto||''' ';
END IF;

IF(p_publication IS NOT NULL)
THEN
query3:=query3 ||' and 

TBL_BOOKING_insert."Publication_Code"='''||p_publication||'''    ';
END IF;

--old version
IF(p_pub_cent IS NOT NULL)
THEN
query3:=query3||'  and TBL_BOOKING_MAST."branch" IN (SELECT "Branch_Name" FROM 

BRANCH_MST WHERE TBL_BOOKING_MAST."branch"="Branch_Name" and "pub_center" in 

(SELECT "Pub_cent_Code" FROM PUB_CENT_MAST WHERE  

branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" and 

"Pub_cent_Code"='''||p_pub_cent||'''))';
END IF;

IF(p_branch IS NOT NULL)
THEN
query3:=query3 ||'  and tbl_booking_mast."branch" ='''||p_branch||'''';
END IF;
--new version
/*
IF(p_pub_cent IS NOT NULL)
THEN
query3:=query3||'  and TBL_BOOKING_MAST."branch" IN (SELECT "Branch_Code" FROM 

BRANCH_MST WHERE TBL_BOOKING_MAST."branch"="Branch_Code" and "pub_center" in 

(SELECT "Pub_cent_Code" FROM PUB_CENT_MAST WHERE  

branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" and 

"Pub_cent_Code"='''||p_pub_cent||'''))';
END IF;


IF(p_branch IS NOT NULL)
THEN
query3:=query3||'  and TBL_BOOKING_mast."branch" = (SELECT "Branch_Code" FROM 

BRANCH_MST where "Branch_Name" ='''||p_branch||''') ';
END IF;
*/
IF(p_edition IS NOT NULL)
THEN
query3:=query3 ||'  and tbl_booking_insert."Edition_Code"='''||p_edition||'''';
END IF;
IF(p_region IS NOT NULL)
THEN
query3:=query3  ||' and agency_mast."region" ='''||p_region||'''';
END IF;

IF(p_revcenter IS NOT NULL)
THEN
query3:=query3  ||' and tbl_booking_mast."Revenue_center" 

='''||p_revcenter||'''';
END IF;

IF(p_adtype IS NOT NULL)
THEN
query3:=query3  || ' and TBL_BOOKING_MAST."Ad_type_code"='''||p_adtype||'''';
END IF;

IF(p_agencytype IS NOT NULL)
THEN
query3:=query3  || ' and TBL_BOOKING_MAST."Agency_type" 

='''||p_agencytype||'''';
END IF;

IF(p_adcat IS NOT NULL)
THEN
query3:=query3  || ' and TBL_BOOKING_insert."Ad_Cat" ='''||p_adcat||'''';
END IF;

IF(p_adsubcat IS NOT NULL)
THEN
query3:=query3  || ' and TBL_BOOKING_MAST."Ad_sub_cat_code" 

='''||p_adsubcat||'''';
END IF;

IF(p_adsubcat3 IS NOT NULL)
THEN
query3:=query3  || ' and TBL_BOOKING_MAST."Ad_Subcat3" ='''||p_adsubcat3||'''';
END IF;

IF(p_adsubcat4 IS NOT NULL)
THEN
query3:=query3  || ' and TBL_BOOKING_MAST."Ad_Subcat4" ='''||p_adsubcat4||'''';
END IF;

IF(p_adsubcat5 IS NOT NULL)
THEN
query3:=query3  || ' and TBL_BOOKING_MAST."Ad_subcat5" ='''||p_adsubcat5||'''';
END IF;

IF(p_package IS NOT NULL)
THEN
query3:=query3  || ' and TBL_BOOKING_MAST."Package_code" ='''||p_package||'''';
END IF;

IF(p_scheme IS NOT NULL)
THEN
query3:=query3  || ' and TBL_BOOKING_MAST."Scheme_type_code" 

='''||p_scheme||'''';
END IF;

IF(p_agency IS NOT NULL)
THEN
query3:=query3  || ' and TBL_BOOKING_MAST."Agency_code" ='''||p_agency||'''';
END IF;

IF(p_client IS NOT NULL)
THEN
query3:=query3  || ' and TBL_BOOKING_MAST."Client_code" ='''||p_client||'''';
END IF;

IF(p_executive IS NOT NULL)
THEN
query3:=query3  || ' and TBL_BOOKING_MAST."Executive_code" 

='''||p_executive||'''';
END IF;

IF(p_retainer IS NOT NULL)
THEN
query3:=query3  || ' and TBL_BOOKING_MAST.RETAINER ='''||p_retainer||'''';
END IF;

IF(p_product IS NOT NULL)
THEN
query3:=query3 || ' and TBL_BOOKING_MAST."Product_code" ='''||p_product||'''';
END IF;

IF(p_brand IS NOT NULL)
THEN
query3:=query3  || ' and TBL_BOOKING_MAST."Brand_code" ='''||p_brand||'''';
END IF;

IF(p_varient IS NOT NULL)
THEN
query3:=query3  || ' and TBL_BOOKING_MAST."Variant_code" ='''||p_varient||'''';
END IF;

IF(p_pagetype IS NOT NULL)
THEN
query3:=query3  || ' and TBL_BOOKING_MAST."Page_type_code" 

='''||p_pagetype||'''';
END IF;

IF(p_pageprem IS NOT NULL)
THEN
query3:=query3 || ' and TBL_BOOKING_insert."Premium1" ='''||p_pageprem||'''';
END IF;

IF(p_postprem IS NOT NULL)
THEN
query3:=query3 || ' and TBL_BOOKING_insert."Page_Post" ='''||p_postprem||'''';
END IF;

IF(p_rostatus IS NOT NULL)
THEN
query3:=query3 || ' and TBL_BOOKING_MAST."ro_status" ='''||p_rostatus||'''';
END IF;

IF(p_booktype IS NOT NULL)
THEN
query3:=query3 || ' and TBL_BOOKING_MAST."Booking_type" ='''||p_booktype||'''';
END IF;

IF(p_contractname  IS NOT NULL)
THEN
query3:=query3 || ' and TBL_BOOKING_MAST."Contract_name" ='''||p_contractname 

||'''';
END IF;

IF(p_suppliment  IS NOT NULL)
THEN
query3:=query3 || ' and tbl_booking_insert."Supp_Code" 

='''||p_suppliment||'''';
END IF;

IF(p_ratetype  IS NOT NULL)
THEN
query3:=query3 || ' and tbl_booking_MAST."Rate_code" ='''||p_ratetype||'''';
END IF;

IF(p_city  IS NOT NULL)
THEN
if(p_base='1')then
query3:=query3 || ' and AGENCY_MAST."City_Code" ='''||p_city||'''';
end if;

if(p_base='2')then
query3:=query3 || ' and tbl_booking_mast."Executive_code" in(select 

exec_mast."Exe_no" from exec_mast where exec_mast."city_code" ='''||p_city||''' 

)';
end if;

if(p_base='3')then
query3:=query3 || ' and tbl_booking_mast.RETAINER in(select 

RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  

RETAINERMASTER."City_Code"='''||p_city||''')';
end if;
END IF;

IF(p_zone  IS NOT NULL)
THEN
if(p_base='1')then
query3:=query3 || ' and AGENCY_MAST."zone_code" ='''||p_zone||'''';
end if;

if(p_base='2')then
query3:=query3 || ' and tbl_booking_mast."Executive_code" in(select 

exec_mast."Exe_no" from exec_mast where exec_mast."city_code" in (select 

city_mst."City_Code" from city_mst where city_mst."Zone_Code"= 

'''||p_zone||''') )';
end if;

if(p_base='3')then
query3:=query3 || ' and tbl_booking_mast.RETAINER in(select 

RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  

RETAINERMASTER."Zone_Code"='''||p_zone||''')';
end if;
END IF;

IF(p_district  IS NOT NULL)
THEN
if(p_base='1')then
query3:=query3 || ' and AGENCY_MAST."Dist_Code" ='''||p_district||'''';
end if;

if(p_base='2')then
query3:=query3 || ' and tbl_booking_mast."Executive_code" in(select 

exec_mast."Exe_no" from exec_mast where exec_mast."dist_code" 

='''||p_district||''' )';
end if;

if(p_base='3')then
query3:=query3 || ' and tbl_booking_mast.RETAINER in(select 

RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  

RETAINERMASTER."Dist_Code"='''||p_district||''')';
end if;
END IF;

IF(p_state  IS NOT NULL)
THEN
if(p_base='1')then
query3:=query3 || ' and AGENCY_MAST."State_Code" ='''||p_state||'''';
end if;

if(p_base='2')then
query3:=query3 || ' and tbl_booking_mast."Executive_code" in(select 

exec_mast."Exe_no" from exec_mast where exec_mast."State_code" 

='''||p_state||''' )';
end if;

if(p_base='3')then
query3:=query3 || ' and tbl_booking_mast.RETAINER in(select 

RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  

RETAINERMASTER."State_Code"='''||p_state||''')';
end if;
END IF;

IF(p_taluka  IS NOT NULL)
THEN
if(p_base='1')then
query3:=query3 || ' and AGENCY_MAST.TALUKA='''||p_taluka||'''  ';
end if;

if(p_base='2')then
query3:=query3 || ' and tbl_booking_mast."Executive_code" in(select 

exec_mast."Exe_no" from exec_mast where exec_mast.TALUKA ='''||p_taluka||''' 

)';
end if;

if(p_base='3')then
query3:=query3 || ' and tbl_booking_mast.RETAINER in(select 

RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  

RETAINERMASTER.TALUKA='''||p_taluka||''')';
end if;
END IF;

query3:=query3 || ' order by tbl_booking_insert."Insert_Date" 

,TBL_BOOKING_MAST."cio_booking_id"';
--DELETE FROM SEARCHTBL;
--insert into searchtbl values(query3);
--commit;
OPEN p_recordset1 FOR
query3;

end if;

else

if(p_adcheck=1)
then


query1:=query1||'SELECT
to_char(a."date_time",''dd/mm/yyyy'') as "Date",
sum(a."No_of_insertion") as "noinsert",
sum(a."Paid_ins") as "Paidinsert",sum(a."Total_area") as "Area",
sum(a."Card_amount") as "cardamt",
sum(a."Deviation") as "Deviationamt",
round(((nvl(sum(a."Deviation"),0)*100)/sum(a."Card_amount")),2) AS 

"Deviation(%)",
sum(a."Agreed_amount") as "aggamt",
(sum(a."Card_amount")- 

DECODE(NVL(sum(a."Agreed_amount"),0),0,sum(a."Card_amount"),sum(a."Agreed_amoun

t"))) as "DiscAmt",
round((((sum(a."Card_amount")- 

DECODE(NVL(sum(a."Agreed_amount"),0),0,sum(a."Card_amount"),sum(a."Agreed_amoun

t"))) *100)/sum(a."Card_amount")),2)  as "Discper",
sum((select SUM(nvl(RAT,0)) from multipack_rat where cioid=a."cio_booking_id"  

and sess_id='||userenv('sessionid')||')) as  "posamt",
round(((sum((select SUM(nvl(RAT,0)) from multipack_rat where 

cioid=a."cio_booking_id"  and 

sess_id='||userenv('sessionid')||'))*100)/sum(a."Card_amount")),2)   as 

"pos(%)",
sum(a."Special_disc_per" * a."Total_area" * a."Card_rate"/100) as "Spdiscamt",
round(((sum(a."Special_disc_per" * a."Total_area" * 

a."Card_rate"/100)*100)/sum(a."Card_amount")),2)  as "Spdiscper",
sum(a."Space_disc_per" * a."Total_area" * a."Card_rate"/100) as "Spacedisc",
round(((sum(a."Space_disc_per" * a."Total_area" * a."Card_rate"/100) 

*100)/sum(a."Card_amount")),2) as "Spacediscper",
sum(a."Special_charges") as "Specialcharge",
round(((sum(nvl((nvl(a."Gross_amount",''0'')*nvl(a."ADD_AGENCY_COMM",''0'')/100

),''0''))*100)/(sum(a."Card_amount")+sum((select SUM(nvl(RAT,0)) from 

multipack_rat where cioid=a."cio_booking_id" and 

sess_id='||userenv('sessionid')||'))+sum(a."Special_charges")-sum(a."Deviation"

)-(sum(a."Card_amount")- 

DECODE(NVL(sum(a."Agreed_amount"),0),0,sum(a."Card_amount"),sum(a."Agreed_amoun

t"))) -sum(a."Space_disc_per" * a."Total_area" * 

a."Card_rate"/100)-sum(a."Special_disc_per" * a."Total_area" * 

a."Card_rate"/100))),2) as "AgencyAddlTD(%)",
sum(nvl((nvl(a."Gross_amount",''0'')*nvl(a."ADD_AGENCY_COMM",''0'')/100),''0'')

) as "AgencyAddlTDAmt",
sum(nvl(a."Gross_amount",''0'')) as "Grossamt",
round(((sum(nvl(nvl(a."Gross_amount",''0'')*(select DISTINCT 

TO_NUMBER(NVL("Comm_Rate",''0''))    from RET_COMM_DETAILS WHERE 

"Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(a."RETAINER",''0'') 

AND "Eff_from_Date"=(SELECT MAX("Eff_from_Date") FROM RET_COMM_DETAILS WHERE 

"Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(a."RETAINER",''0'')) 

AND ROWNUM<=1 )/100,''0''))*100)/sum(nvl(a."Gross_amount",''0''))),2) as 

"RetTD(%)",
sum(nvl(nvl(a."Gross_amount",''0'')*(select DISTINCT 

TO_NUMBER(NVL("Comm_Rate",''0''))    from RET_COMM_DETAILS WHERE 

"Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(a."RETAINER",''0'') 

AND "Eff_from_Date"=(SELECT MAX("Eff_from_Date") FROM RET_COMM_DETAILS WHERE 

"Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(a."RETAINER",''0'')) 

AND ROWNUM<=1 )/100,''0''))as "RetTDAmt",
round(((sum((nvl(a."Gross_amount",''0'')* nvl(a."Trade_disc",''0'' )/100) 

)*100)/(sum(a."Card_amount")+sum((select SUM(nvl(RAT,0)) from multipack_rat 

where cioid=a."cio_booking_id"  and 

sess_id='||userenv('sessionid')||'))+sum(a."Special_charges")-sum(a."Deviation"

)-(sum(a."Card_amount")- 

DECODE(NVL(sum(a."Agreed_amount"),0),0,sum(a."Card_amount"),sum(a."Agreed_amoun

t"))) -sum(a."Space_disc_per" * a."Total_area" * 

a."Card_rate"/100)-sum(a."Special_disc_per" * a."Total_area" * 

a."Card_rate"/100))),2)as "AgencyTD(%)",
sum((nvl(a."Gross_amount",''0'')* nvl(a."Trade_disc",''0'' )/100) )as 

"AgencyTDAmt",
sum(nvl(a."Bill_amount",''0'')) as "Billamt",
round(((sum(nvl(
case( '''||prefer||''' ) 
    when ''Y'' then
        ( CASE (select DISTINCT "Discount" from RET_COMM_DETAILS WHERE 

"Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(a."RETAINER",''0'') 

AND "Eff_from_Date"=(SELECT MAX("Eff_from_Date") FROM RET_COMM_DETAILS WHERE 

"Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(a."RETAINER",''0'')) 

AND ROWNUM<=1)
       when ''Gross'' then 
       
         (
                 CASE to_number(nvl(a.RETAINER_COMM,0))
                 WHEN 0 THEN 0
                 ELSE 

(to_number(nvl(a.RETAINER_COMM,''0''))-to_number(nvl(a."ADD_AGENCY_COMM",''0'') 

))
                 end )
       
       
         when ''Net''   then  to_number(nvl(a.RETAINER_COMM,''0''))
          END )
        
        
       
    ELSE (select 0  from dual)
end
,''0''))*100)/sum(nvl(a."Gross_amount",''0''))),2) as "RetComm(%)",
sum(nvl(
case( '''||prefer||''' ) 
    when ''Y'' then
        ( CASE (select DISTINCT "Discount" from RET_COMM_DETAILS WHERE 

"Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(a."RETAINER",''0'') 

AND "Eff_from_Date"=(SELECT MAX("Eff_from_Date") FROM RET_COMM_DETAILS WHERE 

"Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(a."RETAINER",''0'')) 

AND ROWNUM<=1)
       when ''Gross'' then 
       
                
                 (
                 CASE to_number(nvl(a.RETAINER_COMM_AMT,0))
                 WHEN 0 THEN 0
                 ELSE 

(to_number(nvl(a.RETAINER_COMM_AMT,''0''))-(nvl((nvl(a."Gross_amount",''0'')*to

_number(nvl(a."ADD_AGENCY_COMM",''0''))/100),''0'')))
                 end )
        
         when ''Net''   then  

(nvl(a."Gross_amount",''0'')*(to_number(nvl(a.RETAINER_COMM,''0'')) )/100)
            END )
        
        
      
       
    ELSE (select 0  from dual)
end
,''0'')) as "RetCommAmt",

minus_to_zero(sum(nvl((a."Bill_amount"-nvl(
case( '''||prefer||''' ) 
    when ''Y'' then
        ( CASE (select DISTINCT "Discount" from RET_COMM_DETAILS WHERE 

"Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(a."RETAINER",''0'') 

AND "Eff_from_Date"=(SELECT MAX("Eff_from_Date") FROM RET_COMM_DETAILS WHERE 

"Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(a."RETAINER",''0'')) 

AND ROWNUM<=1)
       when ''Gross'' then 
       (
                 CASE to_number(nvl(a.RETAINER_COMM_AMT,0))
                 WHEN 0 THEN 0
                 ELSE 

(to_number(nvl(a.RETAINER_COMM_AMT,''0''))-(nvl((nvl(a."Gross_amount",''0'')*to

_number(nvl(a."ADD_AGENCY_COMM",''0''))/100),''0'')))
                 end )
       
        
         when ''Net''   then  

(nvl(a."Gross_amount",''0'')*(to_number(nvl(a.RETAINER_COMM,''0'')) )/100)
           END )
       
    ELSE (select 0  from dual)
end
,''0'')  ),''0'') ))as "ActualBusiness"

FROM TBL_BOOKING_MAST a,
agency_mast
WHERE a."Comp_code"='''||p_compcode||''' AND
a."Agency_sub_code"=AGENCY_MAST."code_subcode"' ;


if(p_chk_access='1')then
query1:=query1||' and a."cio_booking_id"  in (select distinct 

b."Cio_Booking_Id" from tbl_booking_insert b where 

a."cio_booking_id"=b."Cio_Booking_Id" and b."Pub_Cent_Code" in (select distinct 

pub_center from login_center where newuser_id='''||p_puserid||''')) ';
end if;

if(p_base='2')then
query1:=query1||' and (a."Executive_code" is not null and a."Executive_code" 

!=''0'')  ';
end if;

if(p_base='3')then
query1:=query1||' and (a.RETAINER is not null  and a.RETAINER !=''0'')  ';
end if;


if(p_drpstatus is null) then
query1:=query1||' and a."cio_booking_id"  in (select distinct 

b."Cio_Booking_Id" from tbl_booking_insert b where 

a."cio_booking_id"=b."Cio_Booking_Id" AND 

lower("Insert_Status")!='''||'cancel'||''' )';
end if;

if(p_insertstatus is not null) then
query1:=query1||' and a."cio_booking_id"  in (select distinct 

b."Cio_Booking_Id" from tbl_booking_insert b where 

a."cio_booking_id"=b."Cio_Booking_Id" AND 

lower("Insert_Status")='''||p_insertstatus||''' )';
end if;


IF(p_fromdate IS NOT NULL AND p_dateto IS NULL  and  p_filterby='Booking Date')
THEN
query1:=query1||' and a."date_time" ='''||p_fromdate||'''';
END IF;

IF(p_fromdate IS NOT NULL AND p_dateto IS NOT NULL and p_filterby='Booking 

Date' )
THEN
query1:=query1||' and a."date_time" between  '''||p_fromdate ||''' and  

'''||p_dateto||''' ';
END IF;

IF(p_fromdate IS NOT NULL AND p_dateto IS NULL  and  p_filterby='Publish Date')
THEN
query1:=query1||' and a."Insertion_date" ='''||p_fromdate||'''';
END IF;

IF(p_fromdate IS NOT NULL AND p_dateto IS NOT NULL and p_filterby='Publish 

Date' )
THEN
query1:=query1||' and a."Insertion_date"  between  '''||p_fromdate ||''' and  

'''||p_dateto||''' ';
END IF;

IF(p_publication IS NOT NULL)
THEN
query1:=query1||'  and a."cio_booking_id"  in (select distinct 

b."Cio_Booking_Id" from tbl_booking_insert b where 

b."Publication_Code"='''||p_publication||''' )    ';
END IF;

--old version
IF(p_pub_cent IS NOT NULL)
THEN
query1:=query1||'  and a."branch" IN (SELECT "Branch_Name" FROM BRANCH_MST 

WHERE a."branch"="Branch_Name" and "pub_center" in (SELECT "Pub_cent_Code" FROM 

PUB_CENT_MAST WHERE  branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" and 

"Pub_cent_Code"='''||p_pub_cent||'''))';
END IF;


IF(p_branch IS NOT NULL)
THEN
query1:=query1||' and a."branch" ='''||p_branch||'''';
END IF;


--new version
/*
IF(p_pub_cent IS NOT NULL)
THEN
query1:=query1||'  and a."branch" IN (SELECT "Branch_Code" FROM BRANCH_MST 

WHERE a."branch"="Branch_Code" and "pub_center" in (SELECT "Pub_cent_Code" FROM 

PUB_CENT_MAST WHERE  branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" and 

"Pub_cent_Code"='''||p_pub_cent||'''))';
END IF;


IF(p_branch IS NOT NULL)
THEN
query1:=query1||'  and a."branch" = (SELECT "Branch_Code" FROM BRANCH_MST where 

"Branch_Name" ='''||p_branch||''') ';
END IF;
*/

IF(p_edition IS NOT NULL)
THEN
query1:=query1||' and a."cio_booking_id"  in (select distinct 

b."Cio_Booking_Id" from tbl_booking_insert b where 

b."Edition_Code"='''||p_edition||''' )';
END IF;

IF(p_region IS NOT NULL)
THEN
query1:=query1 ||'  and agency_mast."region" ='''||p_region||'''';
END IF;

IF(p_suppliment  IS NOT NULL)
THEN
query1:=query1 || '  and a."cio_booking_id"  in (select distinct 

b."Cio_Booking_Id" from tbl_booking_insert b where b."Supp_Code" 

='''||p_suppliment||''' )';
END IF;

IF(p_revcenter IS NOT NULL)
THEN
query1:=query1 ||' and a."Revenue_center" ='''||p_revcenter||'''';
END IF;

IF(p_adtype IS NOT NULL)
THEN
query1:=query1 || ' and a."Ad_type_code"='''||p_adtype||'''';
END IF;

IF(p_agencytype IS NOT NULL)
THEN
query1:=query1 || ' and a."Agency_type" ='''||p_agencytype||'''';
END IF;

IF(p_adcat IS NOT NULL)
THEN
query1:=query1 || ' and a."Ad_cat_code" ='''||p_adcat||'''';
END IF;

IF(p_adsubcat IS NOT NULL)
THEN
query1:=query1 || ' and a."Ad_sub_cat_code" ='''||p_adsubcat||'''';
END IF;

IF(p_adsubcat3 IS NOT NULL)
THEN
query1:=query1 || ' and a."Ad_Subcat3" ='''||p_adsubcat3||'''';
END IF;

IF(p_adsubcat4 IS NOT NULL)
THEN
query1:=query1 || ' and a."Ad_Subcat4" ='''||p_adsubcat4||'''';
END IF;

IF(p_adsubcat5 IS NOT NULL)
THEN
query1:=query1 || ' and a."Ad_subcat5" ='''||p_adsubcat5||'''';
END IF;

IF(p_package IS NOT NULL)
THEN
query1:=query1 || ' and a."Package_code" ='''||p_package||'''';
END IF;

IF(p_scheme IS NOT NULL)
THEN
query1:=query1 || ' and a."Scheme_type_code" ='''||p_scheme||'''';
END IF;

IF(p_agency IS NOT NULL)
THEN
query1:=query1 || ' and a."Agency_code" ='''||p_agency||'''';
END IF;

IF(p_client IS NOT NULL)
THEN
query1:=query1 || ' and a."Client_code" ='''||p_client||'''';
END IF;

IF(p_executive IS NOT NULL)
THEN
query1:=query1 || ' and a."Executive_code" ='''||p_executive||'''';
END IF;

IF(p_retainer IS NOT NULL)
THEN
query1:=query1 || ' and a.RETAINER ='''||p_retainer||'''';
END IF;

IF(p_product IS NOT NULL)
THEN
query1:=query1 || ' and a."Product_code" ='''||p_product||'''';
END IF;

IF(p_brand IS NOT NULL)
THEN
query1:=query1 || ' and a."Brand_code" ='''||p_brand||'''';
END IF;

IF(p_varient IS NOT NULL)
THEN
query1:=query1 || ' and a."Variant_code" ='''||p_varient||'''';
END IF;

IF(p_pagetype IS NOT NULL)
THEN
query1:=query1 || ' and a."Page_type_code" ='''||p_pagetype||'''';
END IF;

IF(p_pageprem IS NOT NULL)
THEN
query1:=query1 || ' and a."Page_prem" ='''||p_pageprem||'''';
END IF;

IF(p_postprem IS NOT NULL)
THEN
query1:=query1 || ' and a."Page_position_code" ='''||p_postprem||'''';
END IF;

IF(p_rostatus IS NOT NULL)
THEN
query1:=query1 || ' and a."ro_status" ='''||p_rostatus||'''';
END IF;

IF(p_booktype IS NOT NULL)
THEN
query1:=query1 || ' and a."Booking_type" ='''||p_booktype||'''';
END IF;

IF(p_contractname  IS NOT NULL)
THEN
query1:=query1 || ' and a."Contract_name" ='''||p_contractname ||'''';
END IF;



IF(p_ratetype  IS NOT NULL)
THEN
query1:=query1 || ' and a."Rate_code" ='''||p_ratetype||'''';
END IF;

IF(p_city  IS NOT NULL)
THEN
if(p_base='1')then
query1:=query1 || ' and AGENCY_MAST."City_Code" ='''||p_city||'''';
end if;

if(p_base='2')then
query1:=query1 || ' and a."Executive_code" in(select exec_mast."Exe_no" from 

exec_mast where exec_mast."city_code" ='''||p_city||''' )';
end if;

if(p_base='3')then
query1:=query1 || ' and a.RETAINER in(select RET."Retain_Code" from  

RETAINERMASTER RET where  RET."City_Code"='''||p_city||''')';
end if;
END IF;

IF(p_zone  IS NOT NULL)
THEN
if(p_base='1')then
query1:=query1 || ' and AGENCY_MAST."zone_code" ='''||p_zone||'''';
end if;

if(p_base='2')then
query1:=query1 || ' and a."Executive_code" in(select exec_mast."Exe_no" from 

exec_mast where exec_mast."city_code" in (select city_mst."City_Code" from 

city_mst where city_mst."Zone_Code"= '''||p_zone||''') )';
end if;

if(p_base='3')then
query1:=query1 || ' and a.RETAINER in(select RET."Retain_Code" from  

RETAINERMASTER RET where  RET."Zone_Code"='''||p_zone||''')';
end if;
END IF;

IF(p_district  IS NOT NULL)
THEN
if(p_base='1')then
query1:=query1 || ' and AGENCY_MAST."Dist_Code" ='''||p_district||'''';
end if;

if(p_base='2')then
query1:=query1 || ' and a."Executive_code" in(select exec_mast."Exe_no" from 

exec_mast where exec_mast."dist_code" ='''||p_district||''' )';
end if;

if(p_base='3')then
query1:=query1 || ' and a.RETAINER in(select RET."Retain_Code" from  

RETAINERMASTER RET where  RET."Dist_Code"='''||p_district||''')';
end if;
END IF;

IF(p_state  IS NOT NULL)
THEN
if(p_base='1')then
query1:=query1 || ' and AGENCY_MAST."State_Code" ='''||p_state||'''';
end if;

if(p_base='2')then
query1:=query1 || ' and a."Executive_code" in(select exec_mast."Exe_no" from 

exec_mast where exec_mast."State_code" ='''||p_state||''' )';
end if;

if(p_base='3')then
query1:=query1 || ' and a.RETAINER in(select RET."Retain_Code" from  

RETAINERMASTER RET where  RET."State_Code"='''||p_state||''')';
end if;
END IF;

IF(p_taluka  IS NOT NULL)
THEN
if(p_base='1')then
query1:=query1 || ' and AGENCY_MAST.TALUKA='''||p_taluka||'''  ';
end if;

if(p_base='2')then
query1:=query1 || ' and a."Executive_code" in(select exec_mast."Exe_no" from 

exec_mast where exec_mast.TALUKA ='''||p_taluka||''' )';
end if;

if(p_base='3')then
query1:=query1 || ' and a.RETAINER in(select RET."Retain_Code" from  

RETAINERMASTER RET where  RET.TALUKA='''||p_taluka||''')';
end if;
END IF;

query1:=query1 || ' group by a."date_time" order by "Date" ';



OPEN p_recordset1 FOR
query1;



elsif(p_adcheck=2)then

delete from temp_ad_bills_report where sess_id=userenv('sessionid');
open c2;
loop
fetch c2 into v2;
exit when c2%notfound;
     

v_val:=FUN_BILL_INSERT(p_compcode,v2.CIOID,v2.BILLNO,prefer,p_dateformat,v2.AGM

AINCODE,v2.AG_SUB_CODE,v2.AGCODE,v2.AGNAME,v2.EXECCODE,v2.EXECNAME,v2.RETCODE,v

2.RETNAME,p_base );    
end loop;
close c2;
commit;


query2:=query2||'SELECT 
to_char(BILLDATE,'''||p_dateformat||''') as "Date",
sum(NOINSERT) as "noinsert",
sum(PAIDINSERT) as "Paidinsert" ,
sum(AREA) as "Area",
sum(CARDAMT) as "cardamt",
sum(DEVIATIONAMT) as "Deviationamt",
round(((nvl(sum(DEVIATIONAMT),0) *100)/nvl(sum(CARDAMT),0)),2)   AS 

"Deviation(%)",
sum(AGGAMT)  as "aggamt",
sum(DISCAMT) as "DiscAmt",
round(((nvl(sum(DISCAMT),0) *100)/nvl(sum(CARDAMT),0)),2) as "Discper",
sum(POSAMT)as  "posamt",
round(((nvl(sum(POSAMT),0) *100)/nvl(sum(CARDAMT),0)),2)  as "pos(%)",
sum(SPDISCAMT) as "Spdiscamt",
round(((nvl(sum(SPDISCAMT),0)*100)/nvl(sum(CARDAMT),0)),2)  as "Spdiscper",
sum(SPACEDISC) as "Spacedisc",
round(((nvl(sum(SPACEDISC),0)*100)/nvl(sum(CARDAMT),0)),2)  as "Spacediscper",
sum(SPECIALCHARGE) as "Specialcharge",
sum(AGENCYADDLTDAMT) as "AgencyAddlTDAmt",
round(((nvl(sum(AGENCYADDLTDAMT),0)*100)/(nvl(sum(CARDAMT),0)+nvl(sum(POSAMT),0

)+nvl(sum(SPECIALCHARGE),0)-nvl(sum(DEVIATIONAMT),0)-nvl(sum(DISCAMT),0)-nvl(su

m(SPDISCAMT),0)-nvl(sum(SPACEDISC),0))),2) as "AgencyAddlTD(%)",
sum(GROSSAMT)  as "Grossamt",
sum(RETTDAMT)as "RetTDAmt",
round(((nvl(sum(RETTDAMT),0)*100)/nvl(sum(GROSSAMT),0) ),2) as "RetTD(%)",
sum(AGENCYTDAMT)as "AgencyTDAmt",
round(((nvl(sum(AGENCYTDAMT),0)*100)/(nvl(sum(CARDAMT),0)+nvl(sum(POSAMT),0)+nv

l(sum(SPECIALCHARGE),0)-nvl(sum(DEVIATIONAMT),0)-nvl(sum(DISCAMT),0)-nvl(sum(SP

DISCAMT),0)-nvl(sum(SPACEDISC),0))),2)as "AgencyTD(%)",
sum(BILLAMT )as "Billamt",
sum(RETCOMMAMT)as "RetCommAmt",
round(((nvl(sum(RETCOMMAMT),0)*100)/nvl(sum(GROSSAMT),0)),2) as "RetComm(%)",
minus_to_zero(sum(ACTUALBUSINESS))as "ActualBusiness"
from temp_ad_bills_report where sess_id='||userenv('sessionid');




IF(p_fromdate IS NOT NULL AND p_dateto IS NOT NULL )
THEN
query2:=query2||' and BILLDATE between  '''||p_fromdate ||''' and  

'''||p_dateto||''' ';
END IF;

IF(p_publication IS NOT NULL)
THEN
query2:=query2||' and PRIPUB='''||p_publication||'''';
END IF;

IF(p_pub_cent IS NOT NULL)
THEN
query2:=query2||'   and PUB_CENT_CODE='''||p_pub_cent||'''';
END IF;

IF(p_edition IS NOT NULL)
THEN
query2:=query2||'  and PEDITION='''||p_edition||'''';
END IF;

IF(p_branch IS NOT NULL)
THEN
query2:=query2||'  and  BRANCH_NAME ='''||p_branch||''' ';
END IF;

IF(p_region IS NOT NULL)
THEN
query2:=query2 ||' and REGION='''||p_region ||'''';
END IF;

IF(p_adtype IS NOT NULL)
THEN
query2:=query2 || ' and PADTYPE='''||p_adtype||'''';
END IF;

IF(p_agencytype IS NOT NULL)
THEN
query2:=query2 || ' and AGENCY_TYPE_CODE= '''||p_agencytype||'''';
END IF;

IF(p_adcat IS NOT NULL)
THEN
query2:=query2 || ' and PRIADCTG='''||p_adcat||'''';
END IF;

IF(p_adsubcat IS NOT NULL)
THEN
query2:=query2 || ' and SECADCTG ='''||p_adsubcat||'''';
END IF;

IF(p_adsubcat3 IS NOT NULL)
THEN
query2:=query2 || ' and AD_SUBCAT3 ='''||p_adsubcat3||'''';
END IF;

IF(p_adsubcat4 IS NOT NULL)
THEN
query2:=query2 || ' and AD_SUBCAT4 ='''||p_adsubcat4||'''';
END IF;

IF(p_adsubcat5 IS NOT NULL)
THEN
query2:=query2 || ' and AD_SUBCAT5 ='''||p_adsubcat5||'''';
END IF;

IF(p_package IS NOT NULL)
THEN
query2:=query2 || ' and PACKAGE_CODE='''||p_package||'''';
END IF;

IF(p_agency IS NOT NULL)
THEN
query2:=query2 || ' and AG_MAIN_CODE ='''||p_agency ||'''';
END IF;

IF(p_client IS NOT NULL)
THEN
query2:=query2 || ' and CLIENTCD='''||p_client ||'''';
END IF;

IF(p_executive IS NOT NULL)
THEN
query2:=query2 || ' and EXECUTIVE_NAME='''||p_executive||'''';
END IF;

IF(p_product IS NOT NULL)
THEN
query2:=query2 || ' and PRIPROCTG='''||p_product||'''';
END IF;

IF(p_brand IS NOT NULL)
THEN
query2:=query2 || ' and BRAND_CODE='''||p_brand||'''';
END IF;

IF(p_varient IS NOT NULL)
THEN
query2:=query2 || ' and   VARIENT_NAME='''||p_varient||'''';
END IF;

IF(p_pageprem IS NOT NULL)
THEN
query2:=query2 || ' and PAGE_PREM ='''||p_pageprem||'''';
END IF;

IF(p_postprem IS NOT NULL)
THEN
query2:=query2 || ' and PAGE_POST ='''||p_postprem||'''';
END IF;

IF(p_contractname  IS NOT NULL)
THEN
query2:=query2 || ' and CONTRACT_NAME ='''||p_contractname ||'''';
END IF;

IF(p_suppliment  IS NOT NULL)
THEN
query2:=query2 || ' and SUPP_CODE='''||p_suppliment||'''';
END IF;

IF(p_retainer IS NOT NULL)
THEN
query2:=query2 || ' and RETAINER_CODE='''||p_retainer||'''';
END IF;

IF(p_ratetype  IS NOT NULL)
THEN
query2:=query2 || ' and RATECD ='''||p_ratetype||'''';
END IF;

IF(p_scheme IS NOT NULL)
THEN
query2:=query2 || ' and PSCHEME='''||p_scheme||'''';
END IF;

IF(p_revcenter IS NOT NULL)
THEN
query2:=query2 ||' and REVENUE_CENTER='''||p_revcenter||'''';
END IF;

IF(p_rostatus IS NOT NULL)
THEN
query2:=query2 || ' and RO_STATUS='''||p_rostatus||'''';
END IF;

IF(p_pagetype IS NOT NULL)
THEN
query2:=query2 || ' and PAGE_TYPE ='''||p_pagetype||'''';
END IF;

IF(p_booktype IS NOT NULL)
THEN
query2:=query2 || ' and BOOKING_TYPE='''||p_booktype||'''';
END IF;



IF(p_city  IS NOT NULL)
THEN
query2:=query2 || ' and CITY_CODE ='''||p_city||'''';
END IF;

IF(p_zone  IS NOT NULL)
THEN
query2:=query2 || ' and ZONE_CODE ='''||p_zone||'''';
end if;

IF(p_district  IS NOT NULL)
THEN
query2:=query2 || ' and DIST_CODE ='''||p_district||'''';
end if;

IF(p_state  IS NOT NULL)
THEN
query2:=query2 || ' and STATE_CODE ='''||p_state||'''';
end if;

IF(p_taluka  IS NOT NULL)
THEN
query2:=query2 || ' and PTALUKA='''||p_taluka||'''  ';
end if;

if(p_base='2')then
query2:=query2 ||' and (EXECUTIVE_NAME   is not null and EXECUTIVE_NAME 

!=''0'')  ';
end if;

if(p_base='3')then
query2:=query2 ||' and (RETAINER_CODE  is not null  and RETAINER_CODE  !=''0'') 

 ';
end if;



query2:=query2 || ' group by BILLDATE   order by BILLDATE ';




OPEN p_recordset1 FOR
query2;

elsif(p_adcheck=3) then
query3:=query3 ||'SELECT  
to_char(b."Insert_Date" ,'''||p_dateformat||''') as "Date",
sum(a."No_of_insertion") as "noinsert",
sum(a."Paid_ins") as "Paidinsert",
sum(b."Size_Book") as "Area",
sum(a."Card_rate"*b."Size_Book") as "cardamt",
sum(a."Deviation") as "Deviationamt",
round(((sum(a."Deviation")*100)/sum(a."Card_rate"*b."Size_Book")),2) AS 

"Deviation(%)",
sum(b."Agreed_Rate")  as "aggamt",
(sum(a."Card_rate"*b."Size_Book")- 

DECODE(NVL(sum(b."Agreed_Rate"),0),0,sum(a."Card_rate"*b."Size_Book"),sum(b."Ag

reed_Rate"))) as "DiscAmt",
round((((sum(a."Card_rate"*b."Size_Book")- 

DECODE(NVL(sum(b."Agreed_Rate"),0),0,sum(a."Card_rate"*b."Size_Book"),sum(b."Ag

reed_Rate")))*100)/sum(a."Card_rate"*b."Size_Book")),2) as "Discper",
sum((select SUM(nvl(RAT,0)) from multipack_rat where cioid=a."cio_booking_id" 

and sess_id='||userenv('sessionid')||')) as  "posamt",
round(((sum((select SUM(nvl(RAT,0)) from multipack_rat where 

cioid=a."cio_booking_id" and 

sess_id='||userenv('sessionid')||'))*100)/sum(a."Card_rate"*b."Size_Book")),2)  

as "pos(%)",
sum(a."Special_disc_per" * b."Size_Book" * a."Card_rate"/100) as "Spdiscamt",
round(((sum(a."Special_disc_per" * b."Size_Book" * 

a."Card_rate"/100)*100)/sum(a."Card_rate"*b."Size_Book")),2) as "Spdiscper",
sum(a."Space_disc_per" * b."Size_Book" * a."Card_rate"/100) as "Spacedisc",
round(((sum(a."Space_disc_per" * b."Size_Book" * 

a."Card_rate"/100)*100)/sum(a."Card_rate"*b."Size_Book")),2) as "Spacediscper",
sum(a."Special_charges") as "Specialcharge",
round(((sum(nvl((nvl(b."Gross_Rate" 

,''0'')*nvl(a."ADD_AGENCY_COMM",''0'')/100),''0''))*100)/(sum(a."Card_rate"*b."

Size_Book")+sum((select SUM(nvl(RAT,0)) from multipack_rat where 

cioid=a."cio_booking_id" and 

sess_id='||userenv('sessionid')||'))+sum(a."Special_charges") 

-sum(a."Deviation")-(sum(a."Card_rate"*b."Size_Book")- 

DECODE(NVL(sum(b."Agreed_Rate"),0),0,sum(a."Card_rate"*b."Size_Book"),sum(b."Ag

reed_Rate")))-sum(a."Special_discount")-sum(a."Space_discount"))),2) as 

"AgencyAddlTD(%)",
sum(nvl((nvl(b."Gross_Rate" ,''0'')*nvl(a."ADD_AGENCY_COMM",''0'')/100),''0'')) 

as "AgencyAddlTDAmt",
ROUND(sum(nvl(b."Gross_Rate",''0'') ))as "Grossamt",
case sum(nvl(b."Gross_Rate",''0'') )
 when  0 then 0
   else  round(((sum(nvl(b."Gross_Rate",''0'')*(select DISTINCT 

TO_NUMBER(NVL("Comm_Rate",''0''))    from RET_COMM_DETAILS WHERE 

"Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(a."RETAINER",''0'') 

AND "Eff_from_Date"=(SELECT MAX("Eff_from_Date") FROM RET_COMM_DETAILS WHERE 

"Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(a."RETAINER",''0'')) 

AND ROWNUM<=1 )/100)*100)/sum(nvl(b."Gross_Rate",''0'') )),2)
 end  as "RetTD(%)",
sum(nvl(nvl(b."Gross_Rate",''0'')*(select DISTINCT 

TO_NUMBER(NVL("Comm_Rate",''0''))    from RET_COMM_DETAILS WHERE 

"Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(a."RETAINER",''0'') 

AND "Eff_from_Date"=(SELECT MAX("Eff_from_Date") FROM RET_COMM_DETAILS WHERE 

"Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(a."RETAINER",''0'')) 

AND ROWNUM<=1 )/100
,''0''))as "RetTDAmt",

round(((sum((nvl(b."Gross_Rate",''0'')* nvl(a."Trade_disc",''0'' )/100 

))*100)/(sum(a."Card_rate"*b."Size_Book")+sum((select SUM(nvl(RAT,0)) from 

multipack_rat where cioid=a."cio_booking_id" and 

sess_id='||userenv('sessionid')||'))+sum(a."Special_charges") 

-sum(a."Deviation")-(sum(a."Card_rate"*b."Size_Book")- 

DECODE(NVL(sum(b."Agreed_Rate"),0),0,sum(a."Card_rate"*b."Size_Book"),sum(b."Ag

reed_Rate")))-sum(a."Special_discount")-sum(a."Space_discount"))),2) as 

"AgencyTD(%)",

sum((nvl(b."Gross_Rate",''0'')* nvl(a."Trade_disc",''0'' )/100 ))as 

"AgencyTDAmt",
ROUND(sum(NVL(b."Bill_Amt",''0'')),2) as "Billamt",
 case sum(nvl(b."Gross_Rate",''0'') )
 when  0 then 0
 else  round(((sum(nvl(
case( '''||prefer||''' ) 
    when ''Y'' then
        ( CASE (select DISTINCT "Discount" from RET_COMM_DETAILS WHERE 

"Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(a."RETAINER",''0'') 

AND "Eff_from_Date"=(SELECT MAX("Eff_from_Date") FROM RET_COMM_DETAILS WHERE 

"Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(a."RETAINER",''0'')) 

AND ROWNUM<=1)
        when ''Gross'' then 
        
         (
                 CASE to_number(nvl(a.RETAINER_COMM,0))
                 WHEN 0 THEN 0
                 ELSE 

(to_number(nvl(a.RETAINER_COMM,''0''))-to_number(nvl(a."ADD_AGENCY_COMM",''0'' 

)))
               end   )
        
        
        
         when ''Net''   then  to_number(nvl(a.RETAINER_COMM,''0''))
          END )
        
          
       
       
    ELSE (select 0  from dual)
end
,''0'')) *100)/sum(nvl(b."Gross_Rate",''0'') )),2)
 
 end  as "RetComm(%)",

sum(nvl(
case( '''||prefer||''' ) 
    when ''Y'' then
        ( CASE (select DISTINCT "Discount" from RET_COMM_DETAILS WHERE 

"Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(a."RETAINER",''0'') 

AND "Eff_from_Date"=(SELECT MAX("Eff_from_Date") FROM RET_COMM_DETAILS WHERE 

"Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(a."RETAINER",''0'')) 

AND ROWNUM<=1)
       when ''Gross'' then 
       
       
              
                
                 (
                 CASE to_number(nvl(a.RETAINER_COMM_AMT,0))
                 WHEN 0 THEN 0
                 ELSE 

(to_number(nvl(a.RETAINER_COMM_AMT,''0''))-(nvl((nvl(b."Gross_Rate",''0'')*to_n

umber(nvl(a."ADD_AGENCY_COMM",''0''))/100),''0'')))
                 end )
       
       
        
         when ''Net''   then  

(nvl(b."Gross_Rate",''0'')*(to_number(nvl(a.RETAINER_COMM,''0'')) )/100)
        END )
       
       
    ELSE (select 0  from dual)
end
,''0''))as "RetCommAmt",


minus_to_zero(ROUND(sum(nvl((  NVL(b."Bill_Amt",''0'')-nvl(
case( '''||prefer||''' ) 
    when ''Y'' then
        ( CASE (select DISTINCT "Discount" from RET_COMM_DETAILS WHERE 

"Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(a."RETAINER",''0'') 

AND "Eff_from_Date"=(SELECT MAX("Eff_from_Date") FROM RET_COMM_DETAILS WHERE 

"Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(a."RETAINER",''0'')) 

AND ROWNUM<=1)
        when ''Gross'' then 
        (
                 CASE to_number(nvl(a.RETAINER_COMM_AMT,0))
                 WHEN 0 THEN 0
                 ELSE 

(to_number(nvl(a.RETAINER_COMM_AMT,''0''))-(nvl((nvl(b."Gross_Rate",''0'')*to_n

umber(nvl(a."ADD_AGENCY_COMM",''0''))/100),''0'')))
                 end )
        
         
         when ''Net''   then  

(nvl(b."Gross_Rate",''0'')*(to_number(nvl(a.RETAINER_COMM,''0'')) )/100)
        END )
       
    ELSE (select 0  from dual)
end
,''0'')  ),''0'')),2)) as "ActualBusiness"
FROM TBL_BOOKING_MAST a,AGENCY_MAST ,TBL_BOOKING_insert b
WHERE a."Comp_code"='''||p_compcode||''' AND
a."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
a."cio_booking_id"=b."Cio_Booking_Id"
and ((b."Pub_Cent_Code" in (select distinct pub_center from login_center where 

newuser_id='''||p_puserid||''') and '''||p_chk_access||'''=''1'')
or  ('''||p_chk_access||'''=''0'') )'; 


if(p_base='2')then
query3:=query3 ||' and (a."Executive_code" is not null and a."Executive_code" 

!=''0'')  ';
end if;

if(p_base='3')then
query3:=query3 ||' and (a.RETAINER is not null  and a.RETAINER !=''0'')  ';
end if;


if(p_drpstatus is null) then
query3:=query3||' and lower("Insert_Status")!='''||'cancel'||'''';
end if;


if(p_insertstatus is not null) then
query3:=query3||' and lower("Insert_Status")='''||p_insertstatus||'''';
end if;


IF(p_fromdate IS NOT NULL AND p_dateto IS NULL )
THEN
query3:=query3 ||' and b."Insert_Date" ='''||p_fromdate||'''';
END IF;

IF(p_fromdate IS NOT NULL AND p_dateto IS NOT NULL)
THEN
query3:=query3 ||' and b."Insert_Date" between  '''||p_fromdate ||''' and  

'''||p_dateto||''' ';
END IF;

IF(p_publication IS NOT NULL)
THEN
query3:=query3 ||' and b."Publication_Code"='''||p_publication||'''    ';
END IF;

--old version

IF(p_pub_cent IS NOT NULL)
THEN
query3:=query3||'  and a."branch" IN (SELECT "Branch_Name" FROM BRANCH_MST 

WHERE a."branch"="Branch_Name" and "pub_center" in (SELECT "Pub_cent_Code" FROM 

PUB_CENT_MAST WHERE  branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" and 

"Pub_cent_Code"='''||p_pub_cent||'''))';
END IF;

IF(p_branch IS NOT NULL)
THEN
query3:=query3 ||'  and a."branch" ='''||p_branch||'''';
END IF;

--new version
/*
IF(p_pub_cent IS NOT NULL)
THEN
query3:=query3||'  and a."branch" IN (SELECT "Branch_Code" FROM BRANCH_MST 

WHERE a."branch"="Branch_Code" and "pub_center" in (SELECT "Pub_cent_Code" FROM 

PUB_CENT_MAST WHERE  branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" and 

"Pub_cent_Code"='''||p_pub_cent||'''))';
END IF;


IF(p_branch IS NOT NULL)
THEN
query3:=query3||'  and a."branch" = (SELECT "Branch_Code" FROM BRANCH_MST where 

"Branch_Name" ='''||p_branch||''') ';
END IF;
*/
IF(p_edition IS NOT NULL)
THEN
query3:=query3 ||'  and b."Edition_Code"='''||p_edition||'''';
END IF;

IF(p_region IS NOT NULL)
THEN
query3:=query3 ||'  and agency_mast."region" ='''||p_region||'''';
END IF;

IF(p_revcenter IS NOT NULL)
THEN
query3:=query3  ||' and a."Revenue_center" ='''||p_revcenter||'''';
END IF;

IF(p_adtype IS NOT NULL)
THEN
query3:=query3  || ' and a."Ad_type_code"='''||p_adtype||'''';
END IF;

IF(p_agencytype IS NOT NULL)
THEN
query3:=query3  || ' and a."Agency_type" ='''||p_agencytype||'''';
END IF;

IF(p_adcat IS NOT NULL)
THEN
query3:=query3  || ' and b."Ad_Cat" ='''||p_adcat||'''';
END IF;

IF(p_adsubcat IS NOT NULL)
THEN
query3:=query3  || ' and a."Ad_sub_cat_code" ='''||p_adsubcat||'''';
END IF;

IF(p_adsubcat3 IS NOT NULL)
THEN
query3:=query3  || ' and a."Ad_Subcat3" ='''||p_adsubcat3||'''';
END IF;

IF(p_adsubcat4 IS NOT NULL)
THEN
query3:=query3  || ' and a."Ad_Subcat4" ='''||p_adsubcat4||'''';
END IF;

IF(p_adsubcat5 IS NOT NULL)
THEN
query3:=query3  || ' and a."Ad_subcat5" ='''||p_adsubcat5||'''';
END IF;

IF(p_package IS NOT NULL)
THEN
query3:=query3  || ' and a."Package_code" ='''||p_package||'''';
END IF;

IF(p_scheme IS NOT NULL)
THEN
query3:=query3  || ' and a."Scheme_type_code" ='''||p_scheme||'''';
END IF;

IF(p_agency IS NOT NULL)
THEN
query3:=query3  || ' and a."Agency_code" ='''||p_agency||'''';
END IF;

IF(p_client IS NOT NULL)
THEN
query3:=query3  || ' and a."Client_code" ='''||p_client||'''';
END IF;

IF(p_executive IS NOT NULL)
THEN
query3:=query3  || ' and a."Executive_code" ='''||p_executive||'''';
END IF;

IF(p_retainer IS NOT NULL)
THEN
query3:=query3  || ' and a.RETAINER ='''||p_retainer||'''';
END IF;

IF(p_product IS NOT NULL)
THEN
query3:=query3 || ' and a."Product_code" ='''||p_product||'''';
END IF;

IF(p_brand IS NOT NULL)
THEN
query3:=query3  || ' and a."Brand_code" ='''||p_brand||'''';
END IF;

IF(p_varient IS NOT NULL)
THEN
query3:=query3  || ' and a."Variant_code" ='''||p_varient||'''';
END IF;

IF(p_pagetype IS NOT NULL)
THEN
query3:=query3  || ' and a."Page_type_code" ='''||p_pagetype||'''';
END IF;

IF(p_pageprem IS NOT NULL)
THEN
query3:=query3 || ' and b."Premium1" ='''||p_pageprem||'''';
END IF;

IF(p_postprem IS NOT NULL)
THEN
query3:=query3 || ' and b."Page_Post"  ='''||p_postprem||'''';
END IF;

IF(p_rostatus IS NOT NULL)
THEN
query3:=query3 || ' and a."ro_status" ='''||p_rostatus||'''';
END IF;

IF(p_booktype IS NOT NULL)
THEN
query3:=query3 || ' and a."Booking_type" ='''||p_booktype||'''';
END IF;

IF(p_contractname  IS NOT NULL)
THEN
query3:=query3 || ' and a."Contract_name" ='''||p_contractname ||'''';
END IF;

IF(p_suppliment  IS NOT NULL)
THEN
query3:=query3 || ' and b."Supp_Code" ='''||p_suppliment||'''';
END IF;

IF(p_ratetype  IS NOT NULL)
THEN
query3:=query3 || ' and a."Rate_code" ='''||p_ratetype||'''';
END IF;

IF(p_city  IS NOT NULL)
THEN
if(p_base='1')then
query3:=query3 || ' and AGENCY_MAST."City_Code" ='''||p_city||'''';
end if;

if(p_base='2')then
query3:=query3 || ' and a."Executive_code" in(select exec_mast."Exe_no" from 

exec_mast where exec_mast."city_code" ='''||p_city||''' )';
end if;

if(p_base='3')then
query3:=query3 || ' and a.RETAINER in(select RETAINERMASTER."Retain_Code" from  

RETAINERMASTER where  RETAINERMASTER."City_Code"='''||p_city||''')';
end if;
END IF;

IF(p_zone  IS NOT NULL)
THEN
if(p_base='1')then
query3:=query3 || ' and AGENCY_MAST."zone_code" ='''||p_zone||'''';
end if;

if(p_base='2')then
query3:=query3 || ' and a."Executive_code" in(select exec_mast."Exe_no" from 

exec_mast where exec_mast."city_code" in (select city_mst."City_Code" from 

city_mst where city_mst."Zone_Code"= '''||p_zone||''') )';
end if;

if(p_base='3')then
query3:=query3 || ' and a.RETAINER in(select RETAINERMASTER."Retain_Code" from  

RETAINERMASTER where  RETAINERMASTER."Zone_Code"='''||p_zone||''')';
end if;
END IF;

IF(p_district  IS NOT NULL)
THEN
if(p_base='1')then
query3:=query3 || ' and AGENCY_MAST."Dist_Code" ='''||p_district||'''';
end if;

if(p_base='2')then
query3:=query3 || ' and a."Executive_code" in(select exec_mast."Exe_no" from 

exec_mast where exec_mast."dist_code" ='''||p_district||''' )';
end if;

if(p_base='3')then
query3:=query3 || ' and a.RETAINER in(select RETAINERMASTER."Retain_Code" from  

RETAINERMASTER where  RETAINERMASTER."Dist_Code"='''||p_district||''')';
end if;
END IF;

IF(p_state  IS NOT NULL)
THEN
if(p_base='1')then
query3:=query3 || ' and AGENCY_MAST."State_Code" ='''||p_state||'''';
end if;

if(p_base='2')then
query3:=query3 || ' and a."Executive_code" in(select exec_mast."Exe_no" from 

exec_mast where exec_mast."State_code" ='''||p_state||''' )';
end if;

if(p_base='3')then
query3:=query3 || ' and a.RETAINER in(select RETAINERMASTER."Retain_Code" from  

RETAINERMASTER where  RETAINERMASTER."State_Code"='''||p_state||''')';
end if;
END IF;

IF(p_taluka  IS NOT NULL)
THEN
if(p_base='1')then
query3:=query3 || ' and AGENCY_MAST.TALUKA='''||p_taluka||''' ';
end if;

if(p_base='2')then
query3:=query3 || ' and a."Executive_code" in(select exec_mast."Exe_no" from 

exec_mast where exec_mast.TALUKA ='''||p_taluka||''' )';
end if;

if(p_base='3')then
query3:=query3 || ' and a.RETAINER in(select RETAINERMASTER."Retain_Code" from  

RETAINERMASTER where  RETAINERMASTER.TALUKA='''||p_taluka||''')';
end if;
END IF;

query3:=query3 || ' group by b."Insert_Date" order by "Date" ';

OPEN p_recordset1 FOR
query3;

end if;
end if;




OPEN  p_accounts FOR
SELECT to_char( SYSDATE,p_dateformat) AS "Rundate",initcap("Comp_Name") AS 

"companyname" from comp_mst where "Comp_Code"=p_compcode;
delete from multipack_rep where sess_id=userenv('sessionid')  ;
delete from multipack_rat where sess_id=userenv('sessionid') ;
DELETE FROM multipack_ratnew where sess_id=userenv('sessionid')  ; commit;

END ;
/


/**************************prachi 5009 22-sep*******************************************************************/


/*******************************Anupama 24/sep/11 issue no. 4835**************************************/

CREATE OR REPLACE PACKAGE BODY Bind_PubName Is
Procedure Bind_PubName_P (
compcode in varchar2,
p_Accounts Out T_Accounts_Cursor)
 As
Begin
Open P_Accounts For
select "Pub_Name","Pub_Code" from pub_mast where "Comp_Code"=compcode  and  "publication_type"<>'CO0' order by "Pub_Code";
End Bind_PubName_P;

End Bind_PubName;
/

/*******************************Anupama 24/sep/11 issue no. 4835**************************************/

/******************************Mimoh 28/sep/11 issue no. 0005047*******************************************/


DROP PACKAGE HT18JULY.SUBCATEXE;

CREATE OR REPLACE PACKAGE HT18JULY.Subcatexe IS
TYPE T_ACCOUNTS_CURSOR IS REF CURSOR;
PROCEDURE subcatexe_p
(compcode IN VARCHAR2,catcode IN VARCHAR2,subcatcode IN VARCHAR2,
subcatname IN VARCHAR2,subcatalias IN VARCHAR2,userid IN VARCHAR2,P_ACCOUNTS OUT T_ACCOUNTS_CURSOR);
END Subcatexe;
/



DROP PACKAGE BODY HT18JULY.SUBCATEXE;

CREATE OR REPLACE PACKAGE BODY HT18JULY.Subcatexe IS
PROCEDURE subcatexe_p
(compcode IN VARCHAR2,catcode IN VARCHAR2,subcatcode IN VARCHAR2,
subcatname IN VARCHAR2,subcatalias IN VARCHAR2,userid IN VARCHAR2,P_ACCOUNTS OUT T_ACCOUNTS_CURSOR)AS
BEGIN

OPEN P_ACCOUNTS FOR
SELECT "Comp_Code", "Adv_Cat_Code", "Adv_Subcat_Code", "Adv_Subcat_Name", "Adv_Subcat_Alias", "UserId",
SYSDATE AS "Creation_DateTime", "Image_name" AS "Image_name",ADMINWEBXML AS "ADMINWEBXML",PRIORITY/*,STATUS*/  FROM ADV_SUBCAT_MAST
WHERE ("Comp_Code"=compcode OR compcode IS NULL)
AND ("Adv_Cat_Code" LIKE catcode || '%' OR catcode IS NULL)
AND ("Adv_Subcat_Code" LIKE subcatcode || '%' OR subcatcode IS NULL)
AND ("Adv_Subcat_Name" LIKE subcatname || '%' OR subcatname IS NULL)
AND ("Adv_Subcat_Alias" LIKE subcatalias || '%' OR subcatalias IS NULL);









 /*AND ("UserId"=userid OR userid IS NULL) AND ("Adv_Cat_Code"=catcode OR catcode IS NULL)AND
 "Adv_Subcat_Name" LIKE subcatname||'%';

ELSIF subcatalias IS NOT NULL THEN
OPEN P_ACCOUNTS FOR
SELECT "Comp_Code", "Adv_Cat_Code", "Adv_Subcat_Code", "Adv_Subcat_Name", "Adv_Subcat_Alias", "UserId",SYSDATE AS "Creation_DateTime"  FROM ADV_SUBCAT_MAST
WHERE ("Comp_Code"=compcode OR compcode IS NULL) AND ("UserId"=userid OR userid IS NULL)
AND ("Adv_Cat_Code"=catcode OR catcode IS NULL)AND "Adv_Subcat_Alias"  LIKE subcatalias||'%';

ELSIF catcode IS NOT NULL THEN
OPEN P_ACCOUNTS FOR
SELECT "Comp_Code", "Adv_Cat_Code", "Adv_Subcat_Code", "Adv_Subcat_Name", "Adv_Subcat_Alias", "UserId",SYSDATE AS "Creation_DateTime"  FROM ADV_SUBCAT_MAST
WHERE ("Comp_Code"=compcode OR compcode IS NULL) AND ("UserId"=userid OR userid IS NULL)AND ("Adv_Cat_Code"=catcode OR catcode IS NULL)AND
 "Adv_Subcat_Name"  LIKE subcatname||'%';

ELSE
OPEN P_ACCOUNTS FOR
SELECT "Comp_Code", "Adv_Cat_Code", "Adv_Subcat_Code", "Adv_Subcat_Name", "Adv_Subcat_Alias", "UserId",SYSDATE AS "Creation_DateTime"  FROM ADV_SUBCAT_MAST
WHERE ("Comp_Code"=compcode OR compcode IS NULL) AND ("UserId"=userid OR userid IS NULL)AND ("Adv_Cat_Code"=catcode OR catcode IS NULL);

END IF;
*/
END subcatexe_p;
END Subcatexe;
/


/******************************Mimoh 28/sep/11 issue no. 0005047*******************************************/

/*********************************issue no.5083 Anupama 29/sep/2011***************************/

CREATE OR REPLACE PACKAGE Bind_PubName IS
TYPE T_Accounts_Cursor IS REF CURSOR;
PROCEDURE Bind_PubName_p(
compcode in varchar2,
P_Accounts  OUT  T_accounts_cursor
);

PROCEDURE Bind_PubEdName_p(
compcode in varchar2,
P_Accounts  OUT  T_accounts_cursor
);
End Bind_PubName;
/


CREATE OR REPLACE PACKAGE BODY Bind_PubName Is
Procedure Bind_PubName_P (
compcode in varchar2,
p_Accounts Out T_Accounts_Cursor)
 As
Begin
Open P_Accounts For
select "Pub_Name","Pub_Code" from pub_mast where "Comp_Code"=compcode  and  "publication_type"<>'CO0' order by "Pub_Code";
End Bind_PubName_P;



Procedure Bind_PubEdName_P (
compcode in varchar2,
p_Accounts Out T_Accounts_Cursor)
 As
Begin
Open P_Accounts For
select "Pub_Name","Pub_Code" from pub_mast where "Comp_Code"=compcode order by "Pub_Code";
End Bind_PubEdName_P;

End Bind_PubName;
/


/*********************************end of issue no.5083 Anupama 29/sep/2011***************************/

/****************************4-oct-2011 Lata*************************/


CREATE OR REPLACE PROCEDURE saveLoginInfo
(
compcode_p in varchar2,
userid_p in varchar2,
ip_p    in varchar2,
filter_p    in varchar2,
session_p   in varchar2,
p_accounts   OUT   cur_type_new1.cursor_type
)
as
l_sessionid varchar2(20);
begin 
select USERENV('SESSIONID') into l_sessionid from dual;
if filter_p = 'INSERT' then
insert into logininfo(COMPCODE, USERID, STARTTIME, LASTUSED, IP, SESSIONID)
    values(compcode_p,userid_p,sysdate,sysdate,ip_p,l_sessionid);
elsif filter_p = 'UPDATE' then
    UPDATE LOGININFO SET LASTUSED=sysdate() WHERE COMPCODE=compcode_p and USERID=userid_p;
elsif filter_p = 'DELETE' then  
    INSERT INTO LOGININFO_LOG(COMPCODE, USERID, STARTTIME, ENDTIME, IP, SESSIONID)
        SELECT COMPCODE,USERID,STARTTIME,SYSDATE,IP, SESSIONID FROM LOGININFO;
    DELETE FROM LOGININFO WHERE    COMPCODE=compcode_p and USERID=userid_p and SESSIONID=session_p;
end if;    
commit;
OPEN p_accounts FOR
    SELECT l_sessionid AS "SESSION" FROM DUAL;
end;
/



CREATE OR REPLACE PROCEDURE fetchlicenseinfo (
   p_accounts   OUT   cur_type_new1.cursor_type
)
AS
BEGIN
   OPEN p_accounts FOR
      SELECT toolkit.decrypt (NVL (a.license_info, toolkit.encrypt ('X'))
                             ) AS licenseinfo,
             TO_CHAR (a.last_key_update, 'dd-mon-yyyy'),
             a.last_key_updated_by
        FROM comp_mst a, preferrences b
       WHERE a."Comp_Code" = b."comp_code";
END;
/



CREATE OR REPLACE PROCEDURE updatekey (
   compname_p         VARCHAR2,
   keyno_p            VARCHAR2,
   userid_p           VARCHAR2,
   p_accounts   OUT   cur_type_new1.cursor_type
)
AS
--error1 varchar2(100);
   keyno        VARCHAR2 (50);
   comp_name    VARCHAR2 (100);
   f_compname   VARCHAR2 (200);
BEGIN
   DECLARE
      CURSOR r_cursor
      IS
         SELECT "Comp_Name"
           FROM comp_mst
          WHERE "Comp_Code" IN (SELECT "comp_code"
                                  FROM preferrences);
   BEGIN
      OPEN r_cursor;

      LOOP
         FETCH r_cursor
          INTO comp_name;

         EXIT WHEN r_cursor%NOTFOUND;

         IF f_compname IS NULL OR f_compname = ''
         THEN
            f_compname := comp_name;
         ELSE
            f_compname := f_compname || ',' || comp_name;
         END IF;

         UPDATE comp_mst
            SET license_info = keyno_p,
                last_key_update = SYSDATE,
                last_key_updated_by = userid_p
          WHERE "Comp_Name" = compname_p;
      END LOOP;
   END;

   OPEN p_accounts FOR
      SELECT f_compname AS "COMPANY_NAME"
        FROM DUAL;
END updatekey;
/

CREATE OR REPLACE PROCEDURE fetchCompanyName
(
p_accounts   OUT   cur_type_new1.cursor_type
)
as  
f_compname varchar2(500);
comp_name varchar2(100);
BEGIN
 DECLARE CURSOR R_CURSOR
      IS
            SELECT "Comp_Name" from comp_mst where "Comp_Code" in(select "comp_code"  FROM PREFERRENCES);
      BEGIN
       OPEN R_CURSOR;

         LOOP
            FETCH R_CURSOR
             INTO comp_name;

            EXIT WHEN R_CURSOR%NOTFOUND;
            if f_compname is null or f_compname = '' then
                f_compname:=comp_name;
            else
                f_compname:=f_compname || ',' || comp_name;    
            end if;
           
        END LOOP;
        END;
OPEN p_accounts FOR
   
select f_compname as "COMPANY_NAME" from dual;

end;
/


CREATE OR REPLACE PROCEDURE fetchLicenseKeyDate 
(
   compcode IN VARCHAR2,
   p_accounts   OUT   cur_type_new1.cursor_type
)
AS
dstr varchar2(100); 
diff date;
BEGIN
select toolkit.decrypt (NVL (license_info, toolkit.encrypt ('X'))
                             )  into dstr from comp_mst where "Comp_Code"=compcode;
--select substr('1000~01-sep-2020~HINDUSTAN TIMES',instr('1000~01-sep-2020~HINDUSTAN TIMES','~')+1,11) from dual
if dstr!='X' then
dstr:=substr(dstr,instr(dstr,'~')+1,11);
diff:=dstr;
   OPEN p_accounts FOR
      select to_date(diff) - to_date(sysdate) as "DIFF",dstr as "DATE",'' as "MSG" from dual ;
else
OPEN p_accounts FOR
select 'X' as "DIFF",'X' as "DATE",'' as "MSG" from dual;
end if;
exception when others then
open  p_accounts FOR
    select 'X' as "DIFF",'X' as "DATE",'Invalid License Key' as "MSG" from dual;
END;
/



/**************************5-oct-2011Kuldeep Bhati  Issue 0004807 ***************************/
CREATE OR REPLACE PACKAGE          receiptsave_booking IS
  PROCEDURE receiptsave_booking_P(
  pcompcode         in varchar2,
    puserid             in varchar2,
    punit                 in varchar2,
    ptype                 in varchar2,
    precpt                 in varchar2,
    prdate              in date,
    ppaymodres         in varchar2,
  preceivedreg     in varchar2,
  pvouno            in varchar2,
  pamount             in number,
  pagency             in varchar2,
    pothercd          in number,
  pchno                 in varchar2,
  pchedate          in date,
    pbank                 in varchar2,
    pnarration         in varchar2,
    prep              in varchar2,
    pvdate                 in date,
    pag_main_code in varchar2,
    pag_sub_code in varchar2,
    ourbank in varchar2,
    cioid in varchar2,
    execname in varchar2,
    retainer in varchar2,
    prevcioid in varchar2,
    prcptno         out varchar2,
     p_error out varchar2
    );
END receiptsave_booking;
/



CREATE OR REPLACE PACKAGE BODY          receiptsave_booking IS
  PROCEDURE receiptsave_booking_P(
    pcompcode       in varchar2,
    puserid         in varchar2,
    punit           in varchar2,
    ptype           in varchar2,
    precpt          in varchar2,
    prdate          in date,
    ppaymodres      in varchar2,
    preceivedreg    in varchar2,
    pvouno          in varchar2,
    pamount         in number,
    pagency         in varchar2,
    pothercd        in number,
    pchno           in varchar2,
    pchedate        in date,
    pbank           in varchar2,
    pnarration      in varchar2,
    prep            in varchar2,
    pvdate          in date,
    pag_main_code   in varchar2,
    pag_sub_code    in varchar2,
    ourbank         in varchar2,
    cioid           in varchar2,
    execname        in varchar2,
    retainer        in varchar2,
    prevcioid       in varchar2,
    prcptno         out varchar2,
    p_error         out varchar2
    )
    as
    countnum    number:=0;
    vquery   number:=0;
    vamount  number:=0;
    vGamount  number:=0;
    agencyreg varchar2(50);
    branchcode varchar2(50);
    rcptgeninp		varchar2(50);
    rcptusernam	varchar2(50);
    
    v_rcpno         varchar2(50);
    v_prefix_recpt  varchar2(30);
    v_sufix_recpt   varchar2(30);
    vcond_flag      varchar2(30):='F'; 
    v_branch_alias  varchar2(30);
    
    
    rec_count number(5):=0;rec_count1 number(5):=0;rec_amount number:=0;rem_amount number:=0;
    /*cursor c1 is
        select * from ad_outstand where comp_code=pcompcode and unit=punit and doctype=prefdoctype and recptno=prefrecnum and
            ag_main_code=pag_main_code and ag_sub_code=pag_sub_code and amount<>0
        order by recptdt,recptno,billdt,billno;
    v1 c1%rowtype;
    vbillamt number(15,2);*/
begin

    select "Receipt_no" into rcptgeninp from preferrences where "comp_code"=pcompcode;
    select "username" into rcptusernam from login where COM_CODE=pcompcode and "userid"=puserid;

    Begin
        select "Branch_Code","Branch_Alias" into branchcode,v_branch_alias from branch_mst where "Comp_Code"=pcompcode and "Branch_Code"=punit;
    Exception When no_data_found then
        branchcode      :='';
        v_branch_alias  :='';
    End;
    
    IF ptype = 'RCP' THEN
            if rcptgeninp='7' then
                    v_prefix_recpt:='R/'||substr(rcptusernam,1,3)||'/'||to_char(prdate,'YY')||'-'||to_char(prdate,'MM')||'/';
            else
                    v_prefix_recpt:='R/'||substr(v_branch_alias,1,3)||'/'||to_char(prdate,'YY')||'-'||to_char(prdate,'MM')||'/';
            end if;
    ELSE
        v_prefix_recpt:='CA/'||substr(v_branch_alias,1,3)||'/'||to_char(prdate,'YY')||'-'||to_char(prdate,'MM')||'/';
    END IF;    
    v_sufix_recpt:='';
   
        chkreceiptno_advt(pcompcode,v_prefix_recpt,v_sufix_recpt,ptype,prdate,'',vcond_flag,v_rcpno);
   
    prcptno:=v_rcpno;
    
    Begin
        select "Dsign" into vquery from fa_Docmst where "Comp_code"=pcompcode and "doc_type"=ptype;
    Exception When no_data_found then
        vquery:=0;
    End;

    Begin
        select "region" into agencyreg from agency_mast where "Comp_Code"=pcompcode and "code_subcode"=pagency;
    Exception When no_data_found then
        agencyreg:='OT0';
    End;
    
    If agencyreg is null then
        agencyreg:='OT0';
    End If;    
    
    
      
    if(vquery=-1) then
         vamount:=pamount*vquery;
    else
         vamount:=pamount*vquery;
    end if;
    vGamount:=pothercd;
     IF ptype = 'CA' THEN
         vamount:=pamount* -1;
         vGamount:=vGamount * -1;
     end if;
    select count(*) into countnum from ad_rcpthdr where "comp_code"=pcompcode and "doctype"=ptype and "recptno"=prcptno;
    if countnum=0 then
    insert into ad_rcpthdr("comp_code","userid","unit","doctype","recptno","recptdt","reason","received_region","voucherno","amount","agcode",
                                                 "oth_amount","chno","chdt","bank","remark","repcode","voucherdate","ag_main_code","ag_sub_code","cashbank","roidnum")
                                    values(pcompcode,puserid,branchcode,ptype,prcptno,prdate ,ppaymodres,agencyreg ,pvouno,vamount,pagency,
                                                 vGamount,pchno ,pchedate ,pbank,pnarration,prep,pvdate,pag_main_code,pag_sub_code,ourbank,substr(cioid,1,20));
    end if;
      select count(*) into countnum from ad_outstand where comp_code=pcompcode and doctype=ptype and recptno=prcptno;
    if countnum=0 then
        insert into ad_outstand(COMP_CODE,USERID,UNIT,DOCTYPE,RECPTNO,RECPTDT,REASON,RECEIVED_REGION,
                                                  VOUCHERNO,AMOUNT,AGCODE,CHNO,CHDT,BANK,VOUCHERDATE,AG_MAIN_CODE,AG_SUB_CODE,REMARK,RECEIPT_NO,REF_AMOUNT,EXEC_CODE,RETAINER_CODE,ROIDNUM,PREV_CIOID)
                                     values(pcompcode,puserid,branchcode,ptype,prcptno,prdate,ppaymodres,agencyreg,
                                                     pvouno,vamount,pagency,pchno,pchedate ,pbank,pvdate,pag_main_code,pag_sub_code,pnarration,cioid,vamount,execname,retainer,substr(cioid,1,20),prevcioid);
    end if;
    select count(*) into countnum from ad_RCPTDET where "comp_code"=pcompcode and "doctype"=ptype and "recptno"=prcptno;
    if countnum=0 then
      INSERT INTO AD_RCPTDET("comp_code","userid","unit","doctype","recptno","recptdt","reason","received_region",
                           "voucherno","amount","agcode",/*"chno","chdt","bank","remark","repcode",*/"voucherdate","ag_main_code","ag_sub_code")
                     VALUES(pcompcode,puserid,branchcode,ptype,prcptno,prdate,ppaymodres,agencyreg,
                            pvouno,vamount,pagency,/*pchno ,pchedate ,pbank,pnarrationprep,*/pvdate,pag_main_code,pag_sub_code);
     end if;

    if nvl(vamount,0)>0 and ptype = 'CA' then
        select count(*) into rec_count from ad_outstand where comp_code=pcompcode and unit=branchcode and doctype=ptype and
        recptno=prcptno and ag_main_code=pag_main_code and ag_sub_code=pag_sub_code and billno is null and amount>0;
        
        if nvl(rec_count,0)>0 then
            insert into ad_outstand (unit,agcode,doctype,reason , bkfor , billno , billdt , recptno , recptdt ,
                                     chno , chdt , bank , voucherno , voucherdate , amount , comp_code , userid ,
                                     pripub , tds , received_region,st,ag_main_code,ag_sub_code,remark,
                                     ref_recptdt,ref_recptno,ref_doctyp,ref_amount)
                              values(branchcode,pagency,ptype,ppaymodres,branchcode,prcptno,prdate,prcptno,prdate,
                                     pchno , pchedate ,decode(pbank,'0',''),pvouno, pvdate , vamount,pcompcode,puserid,
                                     null,null,agencyreg,'',pag_main_code,pag_sub_code,null,
                                     null,null,null,null);

            update ad_outstand set amount=nvl(amount,0)-nvl(vamount,0)
                where comp_code=pcompcode and unit=branchcode and doctype=ptype and recptno=prcptno and recptdt=prdate and
                      ag_main_code=pag_main_code and ag_sub_code=pag_sub_code and billno is null;
        end if;
    end if;--end ad_outstand inserting

 commit;
 EXCEPTION
      WHEN OTHERS
      THEN
         p_error := 'Error:' || SQLERRM;
         insert into log_new(ERR_DESCRIPTION, OBJECT_PROCESS_ID,DATE1) values(p_error,cioid || ' - ' || prcptno || ' CASH RECEIPT',sysdate);
End receiptsave_booking_P;
END receiptsave_booking;
/


/*******************************end of issue no. 0004807  Kuldeep Bhati   5-oct-2011**************************************/















CREATE OR REPLACE PACKAGE toolkit AS

  FUNCTION encrypt (p_text  IN  VARCHAR2) RETURN RAW;

  FUNCTION decrypt (p_raw  IN  RAW) RETURN VARCHAR2;

END toolkit;
/

CREATE OR REPLACE PACKAGE BODY toolkit AS

  g_key     RAW(32767)  := UTL_RAW.cast_to_raw('12345678');
  g_pad_chr VARCHAR2(1) := '~';

  PROCEDURE padstring (p_text  IN OUT  VARCHAR2);


  -- --------------------------------------------------
  FUNCTION encrypt (p_text  IN  VARCHAR2) RETURN RAW IS
  -- --------------------------------------------------
    l_text       VARCHAR2(32767) := p_text;
    l_encrypted  RAW(32767);
  BEGIN
    padstring(l_text);
    SYS.DBMS_OBFUSCATION_TOOLKIT.desencrypt(input          => UTL_RAW.cast_to_raw(l_text),
                                        key            => g_key,
                                        encrypted_data => l_encrypted);
    RETURN l_encrypted;
  END;
  -- --------------------------------------------------



  -- --------------------------------------------------
  FUNCTION decrypt (p_raw  IN  RAW) RETURN VARCHAR2 IS
  -- --------------------------------------------------
    l_decrypted  VARCHAR2(32767);
  BEGIN
    SYS.DBMS_OBFUSCATION_TOOLKIT.desdecrypt(input => p_raw,
                                        key   => g_key,
                                        decrypted_data => l_decrypted);

    RETURN RTrim(UTL_RAW.cast_to_varchar2(l_decrypted), g_pad_chr);
  END;
  -- --------------------------------------------------


  -- --------------------------------------------------
  PROCEDURE padstring (p_text  IN OUT  VARCHAR2) IS
  -- --------------------------------------------------
    l_units  NUMBER;
  BEGIN
    IF LENGTH(p_text) MOD 8 > 0 THEN
      l_units := TRUNC(LENGTH(p_text)/8) + 1;
      p_text  := RPAD(p_text, l_units * 8, g_pad_chr);
    END IF;
  END;
  -- --------------------------------------------------

END toolkit;
/


CREATE OR REPLACE PACKAGE get_validdate_qbc Is
    Type T_Accounts_Cursor Is Ref Cursor;
    Procedure get_validdate_qbc_P
    (
        dateformat  in  varchar2,
        datetoadd   in  date,
        pkgname     in  varchar2,
        adcat1      in  varchar2,
        adtype1     in  varchar2,
        center      in  varchar2,
        pkgid       in varchar2,
        pkgalias    in varchar2,
        p_Accounts  Out T_Accounts_Cursor,
        p_Accounts1 Out T_Accounts_Cursor
    );
end get_validdate_qbc;
/

CREATE OR REPLACE PACKAGE BODY get_validdate_qbc
IS
   PROCEDURE get_validdate_qbc_p (
      DATEFORMAT    IN      VARCHAR2,
      datetoadd     IN      DATE,
      pkgname       IN      VARCHAR2,
      adcat1        IN      VARCHAR2,
      adtype1       IN      VARCHAR2,
      center      in  varchar2,
       pkgid       in varchar2,
       pkgalias    in varchar2,
      p_accounts    OUT      t_accounts_cursor,
      p_accounts1   OUT      t_accounts_cursor
   )
   AS
      fixdate      DATE;
      --validdate     date;
     validdate      date;
      validdays     VARCHAR2 (100);
      dateofday     VARCHAR2 (20);
      day1          VARCHAR2 (18);
      flag          NUMBER;
      count1        NUMBER;
      count2        NUMBER;
      editioncode   VARCHAR2 (12);
      sun           VARCHAR2 (5);
      mon           VARCHAR2 (5);
      tue           VARCHAR2 (5);
      wed           VARCHAR2 (5);
      thu           VARCHAR2 (5);
      fri           VARCHAR2 (5);
      sat           VARCHAR2 (5);
      
       sun1           VARCHAR2 (5);
      mon1           VARCHAR2 (5);
      tue1           VARCHAR2 (5);
      wed1           VARCHAR2 (5);
      thu1           VARCHAR2 (5);
      fri1           VARCHAR2 (5);
      sat1           VARCHAR2 (5);
      i             NUMBER;
      end1          NUMBER;
      noisscode     VARCHAR (8);
      a             NUMBER;
      datetoadd1    DATE;
   BEGIN
      DELETE FROM temp6;

      COMMIT;

      DELETE FROM RESULTS_TMP;

      COMMIT;

      a := fn_splitfield (pkgid, '+');
      
if pkgalias is not null then
      INSERT INTO temp6

SELECT  (select "Edition_Code" from edition_mast where "Edition_Alias" IN
(SELECT "Combin_Desc" from combin_mast where "Combin_Desc" ="EDITION_COMBIN_CODE" and rownum<=1) and  rownum<=1) "EDITION", "SUN", "MON",
                          "TUE", "WED", "THU", "FRI", "SAT"
                    FROM combin_days where combin_code IN ( SELECT LTRIM (RTRIM (edition_name))
                                            FROM RESULT) and "EDITION_COMBIN_CODE"=pkgalias;
else     
  a := fn_splitfield (pkgname, '+');
INSERT INTO temp6 
/*SELECT  (select "Edition_Code" from edition_mast where "Edition_Alias" IN
(SELECT "Combin_Desc" from combin_mast where "Package_Name" ="EDITION_COMBIN_CODE")) "EDITION", "SUN", "MON",
                          "TUE", "WED", "THU", "FRI", "SAT"
                    FROM combin_days where combin_code IN ( SELECT LTRIM (RTRIM (edition_name))
                                            FROM RESULT);*/

 SELECT DISTINCT select_edition_day."edition_code", "sun", "mon",
                         "tue", "wed", "thu", "fri", "sat"
                    FROM select_edition_day
                   WHERE select_edition_day."edition_code" IN (
                            SELECT edition_mast."Edition_Code"
                              FROM edition_mast
                             WHERE "Edition_Alias" IN (
                                          SELECT LTRIM (RTRIM (edition_name))
                                            FROM RESULT));
end if; 
SELECT COUNT(*) INTO count1 FROM TEMP6;
if count1 is null or count1=0 then
      a := fn_splitfield (pkgname, '+');
INSERT INTO temp6 
/*SELECT  (select "Edition_Code" from edition_mast where "Edition_Alias" IN
(SELECT "Combin_Desc" from combin_mast where "Package_Name" ="EDITION_COMBIN_CODE")) "EDITION", "SUN", "MON",
                          "TUE", "WED", "THU", "FRI", "SAT"
                    FROM combin_days where combin_code IN ( SELECT LTRIM (RTRIM (edition_name))
                                            FROM RESULT);*/

 SELECT DISTINCT select_edition_day."edition_code", "sun", "mon",
                         "tue", "wed", "thu", "fri", "sat"
                    FROM select_edition_day
                   WHERE select_edition_day."edition_code" IN (
                            SELECT edition_mast."Edition_Code"
                              FROM edition_mast
                             WHERE "Edition_Alias" IN (
                                          SELECT LTRIM (RTRIM (edition_name))
                                            FROM RESULT));
end if;
count1:=0;
       /*  SELECT DISTINCT select_edition_day."edition_code", "sun", "mon",
                         "tue", "wed", "thu", "fri", "sat"
                    FROM select_edition_day
                   WHERE select_edition_day."edition_code" IN (
                            SELECT edition_mast."Edition_Code"
                              FROM edition_mast
                             WHERE "Edition_Alias" IN (SELECT "Combin_Desc" from combin_mast where "Package_Name" in(
                                          SELECT LTRIM (RTRIM (edition_name))
                                            FROM RESULT)));*/

      fixdate := datetoadd;
      datetoadd1 :=datetoadd;
      DBMS_OUTPUT.put_line (' fixdate' || fixdate);
      DECLARE
         CURSOR subedition
         IS
            SELECT  edition_code, sun, mon, tue, wed, thu, fri, sat
                       FROM temp6;
      BEGIN
         OPEN subedition;

         LOOP
            FETCH subedition
            INTO editioncode, sun, mon, tue, wed, thu, fri, sat;

            EXIT WHEN subedition%NOTFOUND;
                BEGIN
                    select "sun" ,"mon" ,"tue","wed","thu","fri","sat" into sun1,mon1,tue1,wed1,thu1,fri1,sat1 from categorywiseedition where "Edition_code"=editioncode and "Adv_Cat_Code"=adcat1;
                EXCEPTION
                    WHEN NO_DATA_FOUND
                     THEN
                     NULL;
                END;
                validdate:=null;
                datetoadd1 :=datetoadd;
           
            DBMS_OUTPUT.PUT_LINE(day1);
            
            DBMS_OUTPUT.PUT_LINE('sun1--' || sun1);
          DBMS_OUTPUT.PUT_LINE('MON1--' || mon1);
          DBMS_OUTPUT.PUT_LINE('tue1--' || tue1);
          DBMS_OUTPUT.PUT_LINE('wed1--' || wed1);
          DBMS_OUTPUT.PUT_LINE('thu1--' || thu1);
          DBMS_OUTPUT.PUT_LINE('fri1--' || fri1);
          DBMS_OUTPUT.PUT_LINE('sat1--' || sat1);
          DBMS_OUTPUT.PUT_LINE('editioncode--' || editioncode);
            
             noisscode := '0';
             BEGIN
               DBMS_OUTPUT.put_line (' AAAA');

               SELECT "No_Iss_Code"
                 INTO noisscode
                 FROM no_iss_mast
                WHERE "Edition_Code" = editioncode and rownum <=1;
            EXCEPTION
               WHEN NO_DATA_FOUND
               THEN
                  NULL;
            END;

            SELECT COUNT (*)
              INTO count1
              FROM no_iss_grid
             WHERE "No_Iss_Code" = noisscode AND "no_issue_date" = datetoadd1;

              IF (count1 > 0)
            THEN
               --print('11')
               datetoadd1 := datetoadd1 + 1;
               -- convert(varchar(15),dateadd(dd, 1, @fixdate),101)
               DBMS_OUTPUT.put_line (' IFdatetoadd1' || datetoadd1);
            ELSE
               datetoadd1 := datetoadd1;
               DBMS_OUTPUT.put_line (' ELSEdatetoadd1' || datetoadd1);
            END IF;
              day1 := TO_CHAR (datetoadd1, 'dy');
            i := 0;
            end1 := 1;
             DBMS_OUTPUT.put_line (' day1***' || day1);
            WHILE (i <= end1)
           LOOP
             IF (upper(day1) = upper('Sun'))
               THEN

                  IF (sun != 'Y')
                  THEN
                     IF (mon = 'Y')
                     THEN
                        validdate := datetoadd1 + 1;
                     ELSIF (tue = 'Y')
                     THEN
                        validdate := datetoadd1 + 2;
                     ELSIF (wed = 'Y')
                     THEN
                        validdate := datetoadd1 + 3;
                     ELSIF (thu = 'Y')
                     THEN
                        validdate := datetoadd1 + 4;
                     ELSIF (fri = 'Y')
                     THEN
                        validdate :=datetoadd1 + 5;
                     ELSIF (sat = 'Y')
                     THEN
                        validdate := datetoadd1 + 6;
                     END IF;
                  ELSE
                    IF(validdate IS NULL) THEN
                        validdate :=datetoadd1 ;
                    END IF;
                  END IF;
                  
                   IF (sun1 != 'Y')
                  THEN
                     IF (mon1 = 'Y')
                     THEN
                        validdate := datetoadd1 + 1;
                     ELSIF (tue1 = 'Y')
                     THEN
                        validdate := datetoadd1 + 2;
                     ELSIF (wed1 = 'Y')
                     THEN
                        validdate := datetoadd1 + 3;
                     ELSIF (thu1 = 'Y')
                     THEN
                        validdate := datetoadd1 + 4;
                     ELSIF (fri1 = 'Y')
                     THEN
                        validdate :=datetoadd1 + 5;
                     ELSIF (sat1 = 'Y')
                     THEN
                        validdate := datetoadd1 + 6;
                     END IF;
                  ELSE
                    IF(validdate IS NULL) THEN
                        validdate :=datetoadd1 ;
                    END IF;
                  END IF;
                  
             ELSIF (upper(day1) = upper('Mon'))
               THEN
                DBMS_OUTPUT.put_line (' MON*****' || mon);
                DBMS_OUTPUT.put_line (' MON*****' || validdate);
                  IF (mon != 'Y')
                  THEN
                     IF (tue = 'Y')
                     THEN
                        validdate := datetoadd1 + 1;
                     ELSIF (wed = 'Y')
                     THEN
                        validdate :=datetoadd1 + 2;
                     ELSIF (thu = 'Y')
                     THEN
                        validdate := datetoadd1 + 3;
                     ELSIF (fri = 'Y')
                     THEN
                        validdate := datetoadd1 + 4;
                     ELSIF (sat = 'Y')
                     THEN
                        validdate := datetoadd1 + 5;
                     ELSIF (sun = 'Y')
                     THEN
                        validdate :=datetoadd1 + 6;
                     END IF;
                  ELSE
                    IF(validdate IS NULL) THEN
                        validdate :=datetoadd1 ;
                    END IF;
                  END IF;
                   DBMS_OUTPUT.put_line (' MON*****' || validdate);
                   IF (mon1 != 'Y')
                  THEN
                  DBMS_OUTPUT.PUT_LINE('NEW--');
                  DBMS_OUTPUT.PUT_LINE('tue1--'||tue1);
                   
                     IF (tue1 = 'Y')
                     THEN
                        
                        validdate := datetoadd1 + 1;
                        DBMS_OUTPUT.PUT_LINE('---validdate--'||validdate);
                     ELSIF (wed1 = 'Y')
                     THEN
                        validdate :=datetoadd1 + 2;
                     ELSIF (thu1 = 'Y')
                     THEN
                        validdate := datetoadd1 + 3;
                     ELSIF (fri1 = 'Y')
                     THEN
                        validdate := datetoadd1 + 4;
                     ELSIF (sat1 = 'Y')
                     THEN
                        validdate := datetoadd1 + 5;
                     ELSIF (sun1 = 'Y')
                     THEN
                        validdate :=datetoadd1 + 6;
                     END IF;
                  ELSE
                    IF(validdate IS NULL) THEN
                        validdate :=datetoadd1 ;
                    END IF;
                  END IF;
                  
             ELSIF (upper(day1) = upper('Tue'))
               THEN
                  IF (tue != 'Y')
                  THEN
                     IF (wed = 'Y')
                     THEN
                        validdate := datetoadd1 + 1;
                     ELSIF (thu = 'Y')
                     THEN
                        validdate := datetoadd1 + 2;
                     ELSIF (fri = 'Y')
                     THEN
                        validdate :=datetoadd1 + 3;
                     ELSIF (sat = 'Y')
                     THEN
                        validdate := datetoadd1 + 4;
                     ELSIF (sun = 'Y')
                     THEN
                        validdate := datetoadd1 + 5;
                     ELSIF (mon = 'Y')
                     THEN
                        validdate :=datetoadd1 + 6;
                     END IF;
                  ELSE
                    IF(validdate IS NULL) THEN
                        validdate :=datetoadd1 ;
                    END IF;
                  END IF;
                  
                    IF (tue1 != 'Y')
                  THEN
                     IF (wed1 = 'Y')
                     THEN
                        validdate := datetoadd1 + 1;
                     ELSIF (thu1 = 'Y')
                     THEN
                        validdate := datetoadd1 + 2;
                     ELSIF (fri1 = 'Y')
                     THEN
                        validdate :=datetoadd1 + 3;
                     ELSIF (sat1 = 'Y')
                     THEN
                        validdate := datetoadd1 + 4;
                     ELSIF (sun1 = 'Y')
                     THEN
                        validdate := datetoadd1 + 5;
                     ELSIF (mon1 = 'Y')
                     THEN
                        validdate :=datetoadd1 + 6;
                     END IF;
                  ELSE
                    IF(validdate IS NULL) THEN
                        validdate :=datetoadd1 ;
                    END IF;
                  END IF;
                  
               ------for wednaesday
               ELSIF (upper(day1) = upper('Wed'))
               THEN
                    dbms_output.put_line('wed1==================='||wed1);
                  IF (wed != 'Y')
                  THEN
                     IF (thu = 'Y')
                     THEN
                        validdate :=datetoadd1 + 1;
                     --convert(varchar(15),dateadd(dd, 1, datetoadd1),101)
                     ELSIF (fri = 'Y')
                     THEN
                        validdate :=datetoadd1 + 2;
                     --select validdate=convert(varchar(15),dateadd(dd, 2, datetoadd1),101)
                     ELSIF (sat = 'Y')
                     THEN
                        --select validdate=convert(varchar(15),dateadd(dd, 3, datetoadd1),101)
                        validdate := datetoadd1 + 3;
                     ELSIF (sun = 'Y')
                     THEN
                        --select validdate=convert(varchar(15),dateadd(dd, 4, datetoadd1),101)
                        validdate := datetoadd1 + 4;
                     ELSIF (mon = 'Y')
                     THEN
                        --select validdate=convert(varchar(15),dateadd(dd, 5, datetoadd1),101)
                        validdate := datetoadd1 + 5;
                     ELSIF (tue = 'Y')
                     THEN
                        --select validdate=convert(varchar(15),dateadd(dd, 6, datetoadd1),101)
                        validdate :=datetoadd1 + 6;
                     END IF;
                  ELSE
                    IF(validdate IS NULL) THEN
                        validdate :=datetoadd1 ;
                    END IF;
                  END IF;
                  
                   IF (wed1 != 'Y')
                  THEN
                     IF (thu1 = 'Y')
                     THEN
                        validdate :=datetoadd1 + 1;
                     --convert(varchar(15),dateadd(dd, 1, datetoadd1),101)
                     ELSIF (fri1 = 'Y')
                     THEN
                        validdate :=datetoadd1 + 2;
                     --select validdate=convert(varchar(15),dateadd(dd, 2, datetoadd1),101)
                     ELSIF (sat1 = 'Y')
                     THEN
                        --select validdate=convert(varchar(15),dateadd(dd, 3, datetoadd1),101)
                        validdate := datetoadd1 + 3;
                     ELSIF (sun1 = 'Y')
                     THEN
                        --select validdate=convert(varchar(15),dateadd(dd, 4, datetoadd1),101)
                        validdate := datetoadd1 + 4;
                     ELSIF (mon1 = 'Y')
                     THEN
                        --select validdate=convert(varchar(15),dateadd(dd, 5, datetoadd1),101)
                        validdate := datetoadd1 + 5;
                     ELSIF (tue1 = 'Y')
                     THEN
                        --select validdate=convert(varchar(15),dateadd(dd, 6, datetoadd1),101)
                        validdate :=datetoadd1 + 6;
                     END IF;
                  ELSE
                    IF(validdate IS NULL) THEN
                        validdate :=datetoadd1 ;
                    END IF;
                  END IF;
                  
             ELSIF (upper(day1) = upper('Thu'))
               THEN
                  IF (thu != 'Y')
                  THEN
                     IF (fri = 'Y')
                     THEN
                        validdate := datetoadd1 + 1;
                     --select validdate=convert(varchar(15),dateadd(dd, 1, datetoadd1),101)
                     ELSIF (sat = 'Y')
                     THEN
                        validdate :=datetoadd1 + 2;
                     --select validdate=convert(varchar(15),dateadd(dd, 2, datetoadd1),101)
                     ELSIF (sun = 'Y')
                     THEN
                        validdate := datetoadd1 + 3;
                     --select validdate=convert(varchar(15),dateadd(dd, 3, datetoadd1),101)
                     ELSIF (mon = 'Y')
                     THEN
                        validdate := datetoadd1 + 4;
                     --select validdate=convert(varchar(15),dateadd(dd, 4, datetoadd1),101)
                     ELSIF (tue = 'Y')
                     THEN
                        validdate := datetoadd1 + 5;
                     --select validdate=convert(varchar(15),dateadd(dd, 5, datetoadd1),101)
                     ELSIF (wed = 'Y')
                     THEN
                        validdate := datetoadd1 + 6;
                     --select validdate=convert(varchar(15),dateadd(dd, 6, datetoadd1),101)
                     END IF;
                  ELSE
                  dbms_output.put_line('kkkkkkkkkkkkkkkkkk');
                    IF(validdate IS NULL) THEN
                        validdate :=datetoadd1 ;
                    END IF;
                  END IF;
                  
                   IF (thu1 != 'Y')
                  THEN
                     IF (fri1 = 'Y')
                     THEN
                        validdate := datetoadd1 + 1;
                     --select validdate=convert(varchar(15),dateadd(dd, 1, datetoadd1),101)
                     ELSIF (sat1 = 'Y')
                     THEN
                        validdate :=datetoadd1 + 2;
                     --select validdate=convert(varchar(15),dateadd(dd, 2, datetoadd1),101)
                     ELSIF (sun1 = 'Y')
                     THEN
                        validdate := datetoadd1 + 3;
                     --select validdate=convert(varchar(15),dateadd(dd, 3, datetoadd1),101)
                     ELSIF (mon1 = 'Y')
                     THEN
                        validdate := datetoadd1 + 4;
                     --select validdate=convert(varchar(15),dateadd(dd, 4, datetoadd1),101)
                     ELSIF (tue1 = 'Y')
                     THEN
                        validdate := datetoadd1 + 5;
                     --select validdate=convert(varchar(15),dateadd(dd, 5, datetoadd1),101)
                     ELSIF (wed1 = 'Y')
                     THEN
                        validdate := datetoadd1 + 6;
                     --select validdate=convert(varchar(15),dateadd(dd, 6, datetoadd1),101)
                     END IF;
                  ELSE
                  dbms_output.put_line('kkkkkkkkkkkkkkkkkk');
                    IF(validdate IS NULL) THEN
                        validdate :=datetoadd1 ;
                    END IF;
                  END IF;
                  
               ------------------------for friday
               ELSIF (upper(day1) = upper('Fri'))
               THEN
               DBMS_OUTPUT.PUT_LINE('LATA2 '||fri);
                  IF (fri != 'Y')
                  THEN
                     IF (sat = 'Y')
                     THEN
                        validdate :=datetoadd1 + 1;
                     --select validdate=convert(varchar(15),dateadd(dd, 1, datetoadd1),101)
                     ELSIF (sun = 'Y')
                     THEN
                        validdate :=datetoadd1 + 2;
                     --select validdate=convert(varchar(15),dateadd(dd, 2, datetoadd1),101)
                     ELSIF (mon = 'Y')
                     THEN
                        validdate :=datetoadd1 + 3;
                     --select validdate=convert(varchar(15),dateadd(dd, 3, datetoadd1),101)
                     ELSIF (tue = 'Y')
                     THEN
                        validdate := datetoadd1 + 4;
                     --select validdate=convert(varchar(15),dateadd(dd, 4, datetoadd1),101)
                     ELSIF (wed = 'Y')
                     THEN
                        validdate := datetoadd1 +5;
                     --select validdate=convert(varchar(15),dateadd(dd, 5, datetoadd1),101)
                     ELSIF (thu = 'Y')
                     THEN
                        validdate :=datetoadd1 + 6;
                     --select validdate=convert(varchar(15),dateadd(dd, 6, datetoadd1),101)
                     END IF;
                  ELSE
                    IF(validdate IS NULL) THEN
                        validdate :=datetoadd1;
                    END IF;
                  END IF;
                  
                   IF (fri1 != 'Y')
                  THEN
                     IF (sat1 = 'Y')
                     THEN
                        validdate :=datetoadd1 + 1;
                     --select validdate=convert(varchar(15),dateadd(dd, 1, datetoadd1),101)
                     ELSIF (sun1 = 'Y')
                     THEN
                        validdate :=datetoadd1 + 2;
                     --select validdate=convert(varchar(15),dateadd(dd, 2, datetoadd1),101)
                     ELSIF (mon1 = 'Y')
                     THEN
                        validdate :=datetoadd1 + 3;
                     --select validdate=convert(varchar(15),dateadd(dd, 3, datetoadd1),101)
                     ELSIF (tue1 = 'Y')
                     THEN
                        validdate := datetoadd1 + 4;
                     --select validdate=convert(varchar(15),dateadd(dd, 4, datetoadd1),101)
                     ELSIF (wed1 = 'Y')
                     THEN
                        validdate := datetoadd1 +5;
                     --select validdate=convert(varchar(15),dateadd(dd, 5, datetoadd1),101)
                     ELSIF (thu1 = 'Y')
                     THEN
                        validdate :=datetoadd1 + 6;
                     --select validdate=convert(varchar(15),dateadd(dd, 6, datetoadd1),101)
                     END IF;
                  ELSE
                    IF(validdate IS NULL) THEN
                        validdate :=datetoadd1;
                    END IF;
                  END IF;
               ------------------------------------fror saturday
               ELSIF (upper(day1) = upper('Sat'))
               THEN
                  IF (sat != 'Y')
                  THEN
                     IF (sun = 'Y')
                     THEN
                        validdate := datetoadd1 + 1;
                     --select validdate=convert(varchar(15),dateadd(dd, 1, datetoadd1),101)
                     ELSIF (mon = 'Y')
                     THEN
                        validdate := datetoadd1 + 2;
                     --select validdate=convert(varchar(15),dateadd(dd, 2, datetoadd1),101)
                     ELSIF (tue = 'Y')
                     THEN
                        validdate := datetoadd1 + 3;
                     --select validdate=convert(varchar(15),dateadd(dd, 3, datetoadd1),101)
                     ELSIF (wed = 'Y')
                     THEN
                        validdate := datetoadd1 + 4;
                     --select validdate=convert(varchar(15),dateadd(dd, 4, datetoadd1),101)
                     ELSIF (thu = 'Y')
                     THEN
                        validdate := datetoadd1 + 5;
                     --select validdate=convert(varchar(15),dateadd(dd, 5, datetoadd1),101)
                     ELSIF (fri = 'Y')
                     THEN
                        validdate := datetoadd1 + 6;
                     --select validdate=convert(varchar(15),dateadd(dd, 6, datetoadd1),101)
                     ELSE
                       validdate := datetoadd1;
                     --set validdate=convert(varchar(15),datetoadd1,101)
                     END IF;
                  ELSE
                    IF(validdate IS NULL) THEN
                        validdate :=datetoadd1;
                    END IF;
                  END IF;

                  IF (sat1 != 'Y')
                  THEN
                     IF (sun1 = 'Y')
                     THEN
                        validdate := datetoadd1 + 1;
                     --select validdate=convert(varchar(15),dateadd(dd, 1, datetoadd1),101)
                     ELSIF (mon1 = 'Y')
                     THEN
                        validdate := datetoadd1 + 2;
                     --select validdate=convert(varchar(15),dateadd(dd, 2, datetoadd1),101)
                     ELSIF (tue1= 'Y')
                     THEN
                        validdate := datetoadd1 + 3;
                     --select validdate=convert(varchar(15),dateadd(dd, 3, datetoadd1),101)
                     ELSIF (wed1 = 'Y')
                     THEN
                        validdate := datetoadd1 + 4;
                     --select validdate=convert(varchar(15),dateadd(dd, 4, datetoadd1),101)
                     ELSIF (thu1 = 'Y')
                     THEN
                        validdate := datetoadd1 + 5;
                     --select validdate=convert(varchar(15),dateadd(dd, 5, datetoadd1),101)
                     ELSIF (fri1 = 'Y')
                     THEN
                        validdate := datetoadd1 + 6;
                     --select validdate=convert(varchar(15),dateadd(dd, 6, datetoadd1),101)
                     ELSE
                       validdate := datetoadd1;
                     --set validdate=convert(varchar(15),datetoadd1,101)
                     END IF;
                  ELSE
                    IF(validdate IS NULL) THEN
                        validdate :=datetoadd1;
                    END IF;
                  END IF;


               End if;
               begin
               SELECT "No_Iss_Code"
                    INTO noisscode
                    FROM no_iss_mast
                   WHERE "Edition_Code" = editioncode and rownum <=1;

                  exception when no_data_found then
                    null;
                    end;
                    count1:=0;
                  SELECT COUNT (*)
                    INTO count1
                    FROM no_iss_grid
                   WHERE "No_Iss_Code" = noisscode
                   AND "no_issue_date" = validdate;
                     --AND "no_issue_date" = datetoadd1;
               DBMS_OUTPUT.put_line ('datetoadd1 '|| datetoadd1);
               DBMS_OUTPUT.put_line ('validdate---- '|| validdate);
                DBMS_OUTPUT.put_line ('count1---- '|| count1);
                IF (count1 > 0)
                THEN
                   --print('11')
                   validdate := validdate + 1;
                   datetoadd1:=validdate;
                   day1 := TO_CHAR (datetoadd1, 'dy');
                   -- convert(varchar(15),dateadd(dd, 1, @fixdate),101)
                   DBMS_OUTPUT.put_line (' IFdatetoadd1' || datetoadd1);
                ELSE
                   validdate := validdate;
                   DBMS_OUTPUT.put_line (' ELSEdatetoadd1' || datetoadd1);
                   i:=1;
                   exit;
                END IF;
           END LOOP;
             IF (DATEFORMAT = 'dd/mm/yyyy')
            THEN
            DBMS_OUTPUT.put_line ('ankur');
            DBMS_OUTPUT.put_line (validdate);
               INSERT INTO RESULTS_TMP
                SELECT (SELECT "Edition_Alias"
                FROM edition_mast
                WHERE "Edition_Code" =
                LTRIM (RTRIM (editioncode)))
                edition_alias,validdate
              --  to_char(to_date(TO_CHAR (validdate,'dd-mon-rrrr'),'dd/mm/yyyy'),'dd/mm/yyyy')
                FROM DUAL;
            END IF;

             IF (DATEFORMAT = 'mm/dd/yyyy')
            THEN
               INSERT INTO RESULTS_TMP
                SELECT (SELECT "Edition_Alias"
                FROM edition_mast
                WHERE "Edition_Code" =
                LTRIM (RTRIM (editioncode)))
                edition_alias,validdate
               --to_char(to_date(TO_CHAR (validdate,'dd-mon-rrrr'),'dd/mm/yyyy'),'mm/dd/yyyy')
                FROM DUAL;
            END IF;

             IF (DATEFORMAT = 'yyyy/mm/dd')
            THEN
               INSERT INTO RESULTS_TMP
                SELECT (SELECT "Edition_Alias"
                FROM edition_mast
                WHERE "Edition_Code" =
                LTRIM (RTRIM (editioncode)))
                edition_alias,validdate
              --  to_char(to_date(TO_CHAR (validdate,'dd-mon-rrrr'),'dd/mm/yyyy'),'dd/mm/yyyy')
                FROM DUAL;
            END IF;


            END LOOP;

            CLOSE subedition;

      END;
 SELECT COUNT (*)
        INTO count2
        FROM RESULTS_TMP;
        
       SELECT COUNT (*)
        INTO count1
        FROM RESULTS_TMP
       WHERE date_noissue = fixdate;
DBMS_OUTPUT.put_line ('fixdate--'||fixdate);
DBMS_OUTPUT.put_line ('count1--'||count1);
        IF (count1 = count2) THEN
        IF (DATEFORMAT = 'mm/dd/yyyy')
         THEN
            --select convert(varchar(15),fixdate,101)
            OPEN p_accounts FOR
               SELECT TO_CHAR (fixdate, 'mm/dd/yyyy') as "date_noissue"
                 FROM DUAL;

            OPEN p_accounts1 FOR
            SELECT EDITION_CODE as "Edition_code",TO_CHAR (DATE_NOISSUE,'mm/dd/yyyy') as "date_noissue"
                FROM RESULTS_TMP;

        ELSIF (DATEFORMAT = 'dd/mm/yyyy')
         THEN
            OPEN p_accounts FOR
               SELECT TO_CHAR (fixdate, 'dd/mm/yyyy') as "date_noissue"
                 FROM DUAL;

         OPEN p_accounts1 FOR
            SELECT EDITION_CODE as "Edition_code",TO_CHAR (DATE_NOISSUE,'dd/mm/yyyy') as "date_noissue"
                FROM RESULTS_TMP;

        ELSIF (DATEFORMAT = 'yyyy/mm/dd')
         THEN
            OPEN p_accounts FOR
               SELECT TO_CHAR (fixdate, 'yyyy/mm/dd') as "date_noissue"
                 FROM DUAL;

         OPEN p_accounts1 FOR
            SELECT EDITION_CODE as "Edition_code",TO_CHAR (DATE_NOISSUE,'yyyy/mm/dd') as "date_noissue"
                FROM RESULTS_TMP;


         END IF;
      ELSE
        IF (DATEFORMAT = 'mm/dd/yyyy')
         THEN
         OPEN p_accounts FOR
            SELECT to_char(date_noissue,'mm/dd/yyyy') as "date_noissue"
              FROM RESULTS_TMP
             WHERE ROWNUM <= 1;

         OPEN p_accounts1 FOR
            SELECT EDITION_CODE as "Edition_code",to_char(DATE_NOISSUE,'mm/dd/yyyy') as "date_noissue"
                FROM RESULTS_TMP;

        ELSIF (DATEFORMAT = 'dd/mm/yyyy')
         THEN
         
             OPEN p_accounts FOR
                SELECT to_char(date_noissue,'dd/mm/yyyy') as "date_noissue"
              FROM RESULTS_TMP
             WHERE ROWNUM <= 1;

         OPEN p_accounts1 FOR
            SELECT EDITION_CODE as "Edition_code",to_char(DATE_NOISSUE,'dd/mm/yyyy') as "date_noissue"
                FROM RESULTS_TMP;
        ELSIF (DATEFORMAT = 'yyyy/mm/dd')
        then
             OPEN p_accounts FOR
                SELECT to_char(date_noissue,'yyyy/mm/dd') as "date_noissue"
              FROM RESULTS_TMP
             WHERE ROWNUM <= 1;

            OPEN p_accounts1 FOR
            SELECT EDITION_CODE as "Edition_code",to_char(DATE_NOISSUE,'yyyy/mm/dd') as "date_noissue"
                FROM RESULTS_TMP;
        end if;

      END IF;



       END get_validdate_qbc_p;
END get_validdate_qbc;
/
**************************************************************start*mimoh//10/10/2011***************issue-0005269***************************
DROP PACKAGE HT18JULY.WESP_UPDATEDATE;

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
genrate_agency_code IN VARCHAR2

);
END      Wesp_Updatedate;
/



DROP PACKAGE BODY HT18JULY.WESP_UPDATEDATE;

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
genrate_agency_code IN VARCHAR2


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

BILL_SCHEME=P_SCHEME_BILLING,ALLOWED_PDC_DAYS_RECEIPT=P_ALLOW_PDC ,AD_TYPE_MANUL_BILL=PAD_TYPE_FOR_MANUL_BILL,OUTSTANDING_AMT_CRITERIA=RO_OUTSTAND_P,GENRATE_CIR_AGCD=genrate_agency_code
  
   WHERE "comp_code"=compcode;
COMMIT;
END      Wesp_Updatedate_p;
END      Wesp_Updatedate;
/


**********************************************************************************************

DROP PACKAGE HT18JULY.CURRBINDPREFERPGLD;

CREATE OR REPLACE PACKAGE HT18JULY.Currbindpreferpgld
IS
   TYPE t_account_cursor IS REF CURSOR;

   PROCEDURE currbindpreferpgld_p (
      compcode     IN       VARCHAR2,
      p_accounts   OUT      t_account_cursor
   );
END Currbindpreferpgld;
/



DROP PACKAGE BODY HT18JULY.CURRBINDPREFERPGLD;

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
           AD_TYPE_MANUL_BILL,OUTSTANDING_AMT_CRITERIA as RO_OUTSTAND,GENRATE_CIR_AGCD
           
            FROM PREFERRENCES
          WHERE "comp_code" = compcode;
          
         
   END currbindpreferpgld_p;
END Currbindpreferpgld;
/



**************************************************************************************endof**issue-0005269******mimoh//10/10/2011******************************************



****************************issue no 4797********Prachi//11/10/2011********************************************
create or replace PROCEDURE report
(
agname IN VARCHAR2:=NULL,
clientname IN VARCHAR2:=NULL,
adtype IN VARCHAR2,
adcategory IN VARCHAR2,
fromdate IN VARCHAR2,
dateto IN VARCHAR2,
compcode IN VARCHAR2,
pub_name IN VARCHAR2,
pub_cent IN VARCHAR2,
status IN VARCHAR2:=null,
edition IN VARCHAR2,
dateformat IN VARCHAR2,
hold IN VARCHAR2:=null,
descid IN VARCHAR2:=null,
ascdesc IN VARCHAR2:=null,
p_report OUT Cur_Type_New1.cursor_type

)
IS
 str   varchar2(3000);
 center   varchar2(50);



 BEGIN
str:='
select TBL_BOOKING_MAST."cio_booking_id" as "CIOID",AGENCY_MAST."Agency_Name" as "Agency",
nvl((select "Cust_Name" from CUST_MAST where "Cust_Code"="Client_code"),"Client_code")  as "Client",
PUB_CENT_MAST."Pub_Cent_name" as "City",
PUB_MAST."Pub_Name" as "Pub",COMBIN_MAST."Combin_Desc" as "Package","Ad_size_height" as "Depth",
"Ad_size_width" as "Width",TBL_BOOKING_MAST."Total_area" as "Area", COL_MAST."Col_Alias" as "Hue",
(select ADVPOS_TYPE_MAST."Pos_Type_Alias" from ADVPOS_TYPE_MAST where TBL_BOOKING_INSERT."Page_Post"=ADVPOS_TYPE_MAST."Pos_Type_Code") as "Page",
"No_Insert" as "Ins.No.",
 
   TO_CHAR(tbl_booking_insert."Insert_Date" ,'''||dateformat||''')  
 as "Ins.date" ,

 
  TO_CHAR(TBL_BOOKING_MAST."date_time" ,'''||dateformat||''')  
 as "BookDate"
  
  ,"RO_No" as "RoNo.",
case "ro_status"
when ''1'' then ''Reservation''
when ''2'' then ''Confirm''
end as "RoStatus",
 ADV_TYPE_MAST."Adv_Type_Name" as "AdType" 
,"Rate_code" as "RateCode",TBL_BOOKING_INSERT."Card_Rate" as "CardRate",
nvl(TBL_BOOKING_MAST."Card_amount",TBL_BOOKING_MAST."Gross_amount") as "Amt",
TBL_BOOKING_INSERT."Disc_Rate" as "Disc",  TBL_BOOKING_INSERT."Insert_Status" as "Status",TBL_BOOKING_INSERT."Status_Material" as "MatStatus","Caption" as "Cap","Key_no" as "Key","Agreed_Rate" as "AgreedRate",(select  AGENCY_MAST."SUB_Agency_Code" from agency_mast where  AGENCY_MAST."Type" <> ''P'' and TBL_BOOKING_MAST."Agency_code"=AGENCY_MAST."code_subcode" )as "SubAg",(select adv_cat_mast."Adv_Cat_Name" from adv_cat_mast where ADV_CAT_MAST."Adv_Cat_Code"=TBL_BOOKING_MAST."Ad_cat_code") as "AdCat",SAPID

from TBL_BOOKING_MAST,TBL_BOOKING_INSERT,AGENCY_MAST ,PUB_MAST,PUB_CENT_MAST,ADV_TYPE_MAST ,COMBIN_MAST, COL_MAST 
 where TBL_BOOKING_MAST."Comp_code"='''||compcode||''' and TBL_BOOKING_MAST."cio_booking_id"=TBL_BOOKING_INSERT."Cio_Booking_Id"
 and TBL_BOOKING_MAST."Agency_code"=AGENCY_MAST."Agency_Code" and TBL_BOOKING_MAST."Ad_type_code"=ADV_TYPE_MAST ."Adv_Type_Code"
 and tbl_booking_mast."Color_code"=col_mast."Col_Code"  and 
TBL_BOOKING_MAST."Package_code"=COMBIN_MAST."Combin_Code" and TBL_BOOKING_MAST."Agency_sub_code"=AGENCY_MAST."code_subcode" and TBL_BOOKING_INSERT."Publication_Code" = PUB_MAST."Pub_Code" and TBL_BOOKING_INSERT."Pub_Cent_Code"=PUB_CENT_MAST."Pub_cent_Code"  ';

--select adv_cat_mast.adv_cat_name from adv_cat_mast where ADV_CAT_MAST.adv_cat_code=TBL_BOOKING_MAST.ad_cat_code



IF(hold IS NOT NULL)
THEN
str:=str||' and TBL_BOOKING_INSERT."insert_status"!=''Cancel''';
END IF;

IF(agname IS NOT NULL)
THEN
str:=str||' and TBL_BOOKING_MAST."agency_code" ='''||agname ||'''';
END IF;

IF(clientname IS NOT NULL)
THEN
str:=str||' and TBL_BOOKING_MAST."client_code" ='''||clientname ||'''';
END IF;
if(status IS NOT NULL)
THEN
str:=str||' and TBL_BOOKING_INSERT."insert_status"  ='''||status||'''';
END IF;


IF(adtype IS NOT NULL)
THEN

str:=str|| 'and TBL_BOOKING_MAST."ad_type_code" ='''||adtype||'''';
END IF;

IF(adcategory IS NOT NULL)
THEN
str:=str||' and TBL_BOOKING_MAST."ad_cat_code" in('''||adcategory||''' )';
END IF;


--if(@pub_cent<>null )
--begin
--select @center=substring(pub_cent_alias,1,3) from pub_cent_mast where pub_cent_code=@pub_cent

--print(@center)
--set @str=@str+'  and tbl_booking_insert.pub_cent_code='''+ @center +''''
--print(@str)
--end
IF(pub_cent IS NOT NULL)
THEN
str:=str||'  and tbl_booking_insert."pub_cent_code" ='''||pub_cent||'''';
END IF;




IF(fromdate IS NOT NULL AND dateto IS NULL )
THEN
str:=str||' and tbl_booking_insert."Insert_Date" ='''||fromdate ||'''';

END IF;


IF(fromdate IS NOT NULL AND dateto IS NULL )
THEN
str:=str||' and tbl_booking_insert."Insert_Date" between  '''||fromdate ||''' and  '''||dateto ||''' ';
END IF;

IF(edition IS NOT NULL)
THEN
str:=str||'  and tbl_booking_insert."edition_code"='''|| edition ||'''';
END IF;

IF(pub_name IS NOT NULL)
THEN
str:=str||' and  TBL_BOOKING_INSERT."publication_code"='''||pub_name ||'''';
END IF;

 
 
IF(descid IS NOT  NULL)
THEN
str:=str||'  order by "'||descid||'"';
str:=str||''||ascdesc||'';

END IF;


delete from searchtbl;
insert into searchtbl values('pk'||str);
commit;
OPEN p_report FOR str;

END;
/
**************************************end of  issue- 4797********************************

/***************************Kuldeep Bhati 12/10/2011***0005318 ****************************/
CREATE OR REPLACE PACKAGE          Wesp_Updatedate
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
p_dispauditbk IN VARCHAR2

);
END      Wesp_Updatedate;
/



CREATE OR REPLACE PACKAGE BODY          Wesp_Updatedate IS
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
p_dispauditbk IN VARCHAR2

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

BILL_SCHEME=P_SCHEME_BILLING,ALLOWED_PDC_DAYS_RECEIPT=P_ALLOW_PDC ,AD_TYPE_MANUL_BILL=PAD_TYPE_FOR_MANUL_BILL,OUTSTANDING_AMT_CRITERIA=RO_OUTSTAND_P,GENRATE_CIR_AGCD=genrate_agency_code,DISP_AUDITBKG=p_dispauditbk
  
   WHERE "comp_code"=compcode;
COMMIT;
END      Wesp_Updatedate_p;
END      Wesp_Updatedate;
/


===========================================================================================================
CREATE OR REPLACE PACKAGE           Currbindpreferpgld
IS
   TYPE t_account_cursor IS REF CURSOR;

   PROCEDURE currbindpreferpgld_p (
      compcode     IN       VARCHAR2,
      p_accounts   OUT      t_account_cursor
   );
END Currbindpreferpgld;
/



CREATE OR REPLACE PACKAGE BODY          Currbindpreferpgld
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
           AD_TYPE_MANUL_BILL,OUTSTANDING_AMT_CRITERIA as RO_OUTSTAND,GENRATE_CIR_AGCD,DISP_AUDITBKG
           
            FROM PREFERRENCES
          WHERE "comp_code" = compcode;
          
         
   END currbindpreferpgld_p;
END Currbindpreferpgld;
/


================================================================================================================
CREATE OR REPLACE PACKAGE          Websp_Loginemployee IS

TYPE T_Accounts_Cursor IS REF CURSOR;
PROCEDURE Websp_Loginemployee_P (Vusername IN VARCHAR2 ,vpassword IN VARCHAR2 ,vqbc IN VARCHAR2, P_Accounts OUT T_Accounts_Cursor,
P_Accounts1 OUT T_Accounts_Cursor,
P_Accounts2 OUT T_Accounts_Cursor);


END Websp_Loginemployee;
/



CREATE OR REPLACE PACKAGE BODY          Websp_Loginemployee
IS

--var a refcursor;
--var b refcursor;
--var c refcursor;
--exec websp_loginemployee.websp_loginemployee_p('bh01','123','',:a,:b,:c);
    PROCEDURE Websp_Loginemployee_P (Vusername IN VARCHAR2 ,vpassword IN VARCHAR2 ,vqbc IN VARCHAR2,
        P_Accounts OUT T_Accounts_Cursor,
        P_Accounts1 OUT T_Accounts_Cursor,
        P_Accounts2 OUT T_Accounts_Cursor)
    AS
        vuserid VARCHAR2(100);
        v_nm varchar2(100);
        COUNT VARCHAR2(100);
    BEGIN
        IF Vqbc IS NULL THEN
        OPEN P_Accounts FOR
        SELECT "username","password","userid","date_format","COM_CODE","Autogenerate","curr_code","comp_name",
        to_date(sysdate)-to_date(CREATION_DATETIME) as "diff",DISCOUNT,FILTER,ROLEID,"retainer_code" AS RETAINER FROM LOGIN
        WHERE "userid"=Vusername  AND "password"=Vpassword;

        OPEN P_Accounts1 FOR SELECT "rate_gr_code","autogenerated","currency_code","date_format","solo","No_of_Decimal",
        "breakup","blackwhitecode","uom_code","rostatus","Tfn","Insert_breakup","Premium_type","Deal_type"     ,
        "prefix","suffix","financestatus","voucherst","Ad_category","Ro_datetime","Space_area","Vat","Booking_status","Cio_id","Receipt_no","Bgcolor_publication", "chkfor_valid_pubdates","Agency_ratecode","audit","copy_booking","RATE_COMPANY_AGENCY","SUBEDITIONRATE","ADDITIONAL_AGENCY_COMM","AGENCY_RETAINER_COMM",

        "invoice_no","rate_audit",CLS_BILLTYPE,DIS_BILLTYPE,BILLING_FORMAT, RATE_CHECK, ALL_PACKAGE,DAYRATE,SCHEME_TYPE,DISP_CLSBILL,RECEIPT_FORMAT,CASH_RECEIPT_BILL, BILL_ORDERWSLAST, FLOOR_CHK,ROKEYCHECK,
		DISP_CASHBILL, CLA_CASHBILL,RATE_AUDIT_PREF,        
        FA_LEDGER_ALLOW,CLEARANCE_TYPE_ALLOW,DISP_AUDITBKG
        FROM PREFERRENCES WHERE "comp_code"=(SELECT "COM_CODE" FROM LOGIN WHERE "userid"=Vusername AND "password"=Vpassword);
        
        BEGIN
              SELECT "COM_CODE","username" INTO COUNT,v_nm FROM LOGIN WHERE "userid"=vusername AND "password"=vpassword;
              EXCEPTION WHEN NO_DATA_FOUND THEN NULL;
        END;
      
      -- Using Userid,UserNAme & User MAchine ID For Log Purpose
          sec_user.set_userid(vusername);
          sec_user.set_username(v_nm);
          sec_user.set_userip('');
      -- Using Userid,UserNAme & User MAchine ID For Log Purpose     

    OPEN P_Accounts2 FOR
    SELECT "Company_user","Admin" FROM LOGIN WHERE "userid"=Vusername;

ELSE
    OPEN P_Accounts FOR SELECT "username","password","userid","date_format","COM_CODE","Autogenerate","curr_code","comp_name",to_date(sysdate)-to_date(CREATION_DATETIME) as "diff", DISCOUNT,FILTER,ROLEID,"retainer_code" AS RETAINER FROM LOGIN
    WHERE "userid"=Vusername AND "password"=Vpassword AND ("retainer_code"=Vqbc)/* or "retainer_code" in(select BRANCH_CODE from login_branch_mast where BRANCH_CODE =Vqbc and USER_CODE=Vusername and USER_FLAG='Y') )*/ and "Company_user" is null;

OPEN P_Accounts1 FOR SELECT "rate_gr_code","autogenerated","currency_code","date_format","solo","No_of_Decimal",
"breakup","blackwhitecode","uom_code","rostatus","Tfn","Insert_breakup","Premium_type","Deal_type"     ,
"prefix","suffix","financestatus","voucherst","Ad_category","Ro_datetime","Space_area","Vat","Booking_status","Cio_id","Receipt_no","Bgcolor_publication", "chkfor_valid_pubdates","Agency_ratecode","audit","copy_booking","RATE_COMPANY_AGENCY","SUBEDITIONRATE","ADDITIONAL_AGENCY_COMM","AGENCY_RETAINER_COMM",
"invoice_no","rate_audit",CLS_BILLTYPE,DIS_BILLTYPE,BILLING_FORMAT, RATE_CHECK, ALL_PACKAGE, DAYRATE,SCHEME_TYPE,DISP_CLSBILL,RECEIPT_FORMAT,CASH_RECEIPT_BILL, BILL_ORDERWSLAST, FLOOR_CHK,ROKEYCHECK,

DISP_CASHBILL, CLA_CASHBILL,RATE_AUDIT_PREF ,FA_LEDGER_ALLOW,CLEARANCE_TYPE_ALLOW,DISP_AUDITBKG
FROM PREFERRENCES WHERE "comp_code"=(SELECT "COM_CODE" FROM LOGIN WHERE "userid"=Vusername AND "password"=Vpassword);
BEGIN
SELECT "COM_CODE","username" INTO COUNT,v_nm FROM LOGIN WHERE "userid"=vusername AND "password"=vpassword AND "retainer_code"=vqbc;
EXCEPTION WHEN NO_DATA_FOUND THEN NULL;
END;

      -- Using Userid,UserNAme & User MAchine ID For Log Purpose
          sec_user.set_userid(vusername);
          sec_user.set_username(v_nm);
          sec_user.set_userip('');
      -- Using Userid,UserNAme & User MAchine ID For Log Purpose 

OPEN P_Accounts2 FOR
SELECT "Company_user","Admin" FROM LOGIN WHERE "userid"=Vusername;
END IF;



END Websp_Loginemployee_P;

END Websp_Loginemployee;
/


===========================================================================================================
CREATE OR REPLACE PACKAGE Bindaudit_grid
IS
  TYPE T_ACCOUNT_CURSOR IS REF CURSOR;

  PROCEDURE Bindaudit_grid_p(
  pdate1 IN VARCHAR2,
  pAdtype IN VARCHAR2,
  pbranch2 IN VARCHAR2,
  v_userid in varchar2,
  v_comp_code IN VARCHAR2,
  P_ACCOUNT OUT T_ACCOUNT_CURSOR);
END Bindaudit_grid;
/



CREATE OR REPLACE PACKAGE BODY Bindaudit_grid IS
PROCEDURE Bindaudit_grid_p(
  pdate1        IN VARCHAR2,
  pAdtype       IN VARCHAR2,
  pbranch2      IN VARCHAR2,
  v_userid      in varchar2,
  v_comp_code   IN VARCHAR2,
  P_ACCOUNT OUT T_ACCOUNT_CURSOR)
AS
     BEGIN
         -- Insert into test1(vstring) values(' date1 '||date1||' BRANCH1 '||BRANCH2||' Adtype '||Adtype||' branch2 '||branch2||' v_userid '||v_userid);commit;

    OPEN P_ACCOUNT FOR
    SELECT "cio_booking_id",
    nvl((select "Cust_Name" from cust_mast where "Cust_Code"="Client_code"),"Client_code") as "Client_code",AUDIT_COMMENT
    FROM TBL_BOOKING_MAST WHERE  TBL_BOOKING_MAST."Comp_code" =v_comp_code and "branch" IN
    (SELECT "Branch_Code" FROM BRANCH_MST WHERE branch_mst."Branch_Code" in
    (select lb.branch_code from login_branch_mast lb where  lb.user_code=v_userid and nvl(lb.user_flag,'N')='Y') AND "pub_center"=pBRANCH2)
    AND "Ad_type_code"=padtype AND "audit" IS   NULL  and AUDIT_COMMENT is not null;
END Bindaudit_grid_p;
END Bindaudit_grid;
/



//**************************************************end of issue 0005318*************************************************



/***************************Kuldeep Bhati 12/10/2011***0005330 ****************************/

CREATE OR REPLACE procedure ad_getuomfvalue
(p_compcode in VARCHAR2,
p_uomcode in  VARCHAR2,
P_Accounts OUT CUR_TYPE_NEW1.CURSOR_TYPE)
AS
BEGIN
OPEN P_Accounts FOR
SELECT "Uom_Name" AS "Uom_Name",FLAG FROM UOM_MAST WHERE "Comp_Code"=p_compcode AND "Uom_Code"=p_uomcode;  

END;
/
========================================================================================
CREATE OR REPLACE PACKAGE getuomdesc
IS
   TYPE t_accounts_cursor IS REF CURSOR;

   PROCEDURE  getuomdesc_p (


   compcode in varchar2,
value in  varchar2,

      p_accounts   OUT      t_accounts_cursor
   );
END  getuomdesc;
/

CREATE OR REPLACE PACKAGE BODY getuomdesc
IS
   PROCEDURE  getuomdesc_p (
       compcode in varchar2,
       value in  varchar2,
      p_accounts   OUT      t_accounts_cursor
   )
   AS
   BEGIN
      OPEN p_accounts FOR
   select "UOM_DESC" AS "uom_desc","Logo" AS "Logo","Logo_Uom"  AS "Logo_Uom","Stylesheetname"  as "stylesheetname",FLAG,"Uom_Name" AS "Uom_Name" from uom_mast where "Uom_Code"=value;
   END getuomdesc_p;
END getuomdesc;
/


/***************************Kuldeep Bhati 12/10/2011******0005330 ************************/

/***************************Kuldeep Bhati 13/10/2011***0004884   ****************************/
CREATE OR REPLACE PACKAGE Logininsert
IS


   PROCEDURE  loginInsert_p (  username IN VARCHAR2,
password IN VARCHAR2,
userid1 IN VARCHAR2,
date_format IN VARCHAR2,
comp_name IN VARCHAR2,
com_code IN VARCHAR2,
curr_code IN VARCHAR2,
retainer_code IN VARCHAR2,

agencycode IN VARCHAR2,
USER IN  VARCHAR2,
ADMIN1 IN VARCHAR2,
comp_user IN VARCHAR2,
compnamelist in varchar2,
emailid  in varchar2,
disc in varchar2,
fil in varchar2,
role in varchar2,
editlines in varchar2,
firstname in varchar2,
lastname in varchar2,
pstatus  in varchar2
);
END   Logininsert;
/

CREATE OR REPLACE PACKAGE BODY Logininsert
IS


   PROCEDURE  loginInsert_p (
username IN VARCHAR2,
password IN VARCHAR2,
userid1 IN VARCHAR2,
date_format IN VARCHAR2,
comp_name IN VARCHAR2,
com_code IN VARCHAR2,
curr_code IN VARCHAR2,
retainer_code IN VARCHAR2,
agencycode IN VARCHAR2,
USER IN  VARCHAR2,
ADMIN1 IN VARCHAR2,
comp_user IN VARCHAR2,
compnamelist in varchar2,
emailid  in varchar2,
disc in varchar2,
fil in varchar2,
role in varchar2,
editlines in varchar2,
firstname in varchar2,
lastname in varchar2,
pstatus  in varchar2
) AS

BEGIN


INSERT INTO LOGIN("username","password","userid","date_format","comp_name","COM_CODE","curr_code","retainer_code","Agency_code","User_status","Admin","Company_user",USER_COMPANY,EMAIL,DISCOUNT,FILTER,ROLEID,BOOKING_EDITLINES,FIRSTNAME,LASTNAME,STATUS)

VALUES(username,password,userid1,date_format,comp_name,com_code,curr_code,retainer_code,agencycode,USER,ADMIN1,comp_user,compnamelist,emailid,disc,fil,role,editlines,firstname,lastname,pstatus);
DELETE FROM MODULE_DETAIBUTTONL WHERE MODULE_DETAIBUTTONL."userid"=userid1;
COMMIT;
dbms_output.put_line(userid1);
INSERT INTO MODULE_DETAIBUTTONL("Button_id", "Form_Name", "comp_code", "userid", "Module_No", "Form_id", "Paid_permission", "Backdate_booking", "Ro_date_perm", "Confirm_qbc", BACK_DAYS) SELECT BUTTONID, FORM_NAME,COMPCODE,userid1,'',FORM_ID,'','','','',''  FROM ROLE_PERMISSION WHERE ROLEID=role;
update MODULE_DETAIBUTTONL set modulecode=(select modulecode from formmast where "Form_Name"= MODULE_DETAIBUTTONL."Form_Name" and rownum<=1) where "userid"=userid1;
COMMIT;

END   loginInsert_p;
END   Logininsert;
/
===============================================================================================================

CREATE OR REPLACE PACKAGE Loginmodify
IS


   PROCEDURE   loginModify_p (username IN VARCHAR2,
password IN VARCHAR2,
userid1 IN VARCHAR2,
date_format IN VARCHAR2,
comp_name IN VARCHAR2,
compcode IN VARCHAR2,
curr_code IN VARCHAR2,
retainer_code IN VARCHAR2,

agencycode IN VARCHAR2,
USER IN  VARCHAR2,
ADMIN1 IN VARCHAR2,
comp_user IN VARCHAR2,
companylist in varchar2,
emailid  in varchar2,
disc in varchar2,
fil in varchar2,
role in varchar2,
editlines in varchar2,
fname in varchar2,
lname in varchar2,
pstatus  in varchar2
 );
END    Loginmodify ;
/


CREATE OR REPLACE PACKAGE BODY Loginmodify
IS


   PROCEDURE   loginModify_p (username IN VARCHAR2,
password IN VARCHAR2,
userid1 IN VARCHAR2,
date_format IN VARCHAR2,
comp_name IN VARCHAR2,
compcode IN VARCHAR2,
curr_code IN VARCHAR2,
retainer_code IN VARCHAR2,

agencycode IN VARCHAR2,
USER IN  VARCHAR2,
ADMIN1 IN VARCHAR2,
comp_user IN VARCHAR2,
companylist in varchar2,
emailid  in varchar2,
disc in varchar2,
fil in varchar2,
role in varchar2,
editlines in varchar2,
fname in varchar2,
lname in varchar2,
pstatus  in varchar2

) AS


BEGIN

UPDATE LOGIN SET FIRSTNAME=fname,LASTNAME=lname , BOOKING_EDITLINES=editlines, ROLEID=role,FILTER=fil, DISCOUNT=disc, "username"=username, "password"=password, "date_format"=date_format, "comp_name"=comp_name, "COM_CODE"=com_code, "curr_code"=curr_code,

"retainer_code"=retainer_code,"Agency_code"=agencycode,"User_status"=USER,"Admin"=ADMIN1,"Company_user"=comp_user,USER_COMPANY=companylist,EMAIL=emailid,STATUS=pstatus WHERE "userid"=userid1;
/*
if(role!='0' or  role is not null)
then
DELETE FROM MODULE_DETAIBUTTONL WHERE MODULE_DETAIBUTTONL."userid"=userid1;
COMMIT;
INSERT INTO MODULE_DETAIBUTTONL SELECT BUTTONID, FORM_NAME,COMPCODE,userid1,'',FORM_ID,'','','',''  FROM ROLE_PERMISSION WHERE ROLEID=role;
COMMIT;
end if;*/

END    loginModify_p ;
END    Loginmodify ;
/
==================================================================================================================
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
         SELECT * FROM LOGIN
          WHERE "Admin"is null
            and ("COM_CODE" = com_code OR com_code IS NULL)
            AND ("username" LIKE username || '%' OR username IS NULL)
            AND ("userid" LIKE userid || '%' OR userid IS NULL);
  else
     OPEN p_accounts FOR
         SELECT * FROM LOGIN
          WHERE  "Admin"='yes'
          and ("COM_CODE" = com_code OR com_code IS NULL)
            AND ("username" LIKE username || '%' OR username IS NULL)
            AND ("userid" LIKE userid || '%' OR userid IS NULL);       
end if;

END Loginexecute_p;
END Loginexecute;
/
=====================================================================================================
CREATE OR REPLACE PACKAGE Websp_Loginemployee IS

TYPE T_Accounts_Cursor IS REF CURSOR;
PROCEDURE Websp_Loginemployee_P (Vusername IN VARCHAR2 ,vpassword IN VARCHAR2 ,vqbc IN VARCHAR2, P_Accounts OUT T_Accounts_Cursor,
P_Accounts1 OUT T_Accounts_Cursor,
P_Accounts2 OUT T_Accounts_Cursor);


END Websp_Loginemployee;
/
CREATE OR REPLACE PACKAGE BODY Websp_Loginemployee
IS

--var a refcursor;
--var b refcursor;
--var c refcursor;
--exec websp_loginemployee.websp_loginemployee_p('bh01','123','',:a,:b,:c);
    PROCEDURE Websp_Loginemployee_P (Vusername IN VARCHAR2 ,vpassword IN VARCHAR2 ,vqbc IN VARCHAR2,
        P_Accounts OUT T_Accounts_Cursor,
        P_Accounts1 OUT T_Accounts_Cursor,
        P_Accounts2 OUT T_Accounts_Cursor)
    AS
        vuserid VARCHAR2(100);
        v_nm varchar2(100);
        COUNT VARCHAR2(100);
    BEGIN
        IF Vqbc IS NULL THEN
        OPEN P_Accounts FOR
        SELECT "username","password","userid","date_format","COM_CODE","Autogenerate","curr_code","comp_name",
        to_date(sysdate)-to_date(CREATION_DATETIME) as "diff",DISCOUNT,FILTER,ROLEID,"retainer_code" AS RETAINER FROM LOGIN
        WHERE "userid"=Vusername  AND "password"=Vpassword and STATUS !='I';

        OPEN P_Accounts1 FOR SELECT "rate_gr_code","autogenerated","currency_code","date_format","solo","No_of_Decimal",
        "breakup","blackwhitecode","uom_code","rostatus","Tfn","Insert_breakup","Premium_type","Deal_type"     ,
        "prefix","suffix","financestatus","voucherst","Ad_category","Ro_datetime","Space_area","Vat","Booking_status","Cio_id","Receipt_no","Bgcolor_publication", "chkfor_valid_pubdates","Agency_ratecode","audit","copy_booking","RATE_COMPANY_AGENCY","SUBEDITIONRATE","ADDITIONAL_AGENCY_COMM","AGENCY_RETAINER_COMM",

        "invoice_no","rate_audit",CLS_BILLTYPE,DIS_BILLTYPE,BILLING_FORMAT, RATE_CHECK, ALL_PACKAGE,DAYRATE,SCHEME_TYPE,DISP_CLSBILL,RECEIPT_FORMAT,CASH_RECEIPT_BILL, BILL_ORDERWSLAST, FLOOR_CHK,ROKEYCHECK,
		DISP_CASHBILL, CLA_CASHBILL,RATE_AUDIT_PREF,        
        FA_LEDGER_ALLOW,CLEARANCE_TYPE_ALLOW,DISP_AUDITBKG
        FROM PREFERRENCES WHERE "comp_code"=(SELECT "COM_CODE" FROM LOGIN WHERE "userid"=Vusername AND "password"=Vpassword);
        
        BEGIN
              SELECT "COM_CODE","username" INTO COUNT,v_nm FROM LOGIN WHERE "userid"=vusername AND "password"=vpassword;
              EXCEPTION WHEN NO_DATA_FOUND THEN NULL;
        END;
      
      -- Using Userid,UserNAme & User MAchine ID For Log Purpose
          sec_user.set_userid(vusername);
          sec_user.set_username(v_nm);
          sec_user.set_userip('');
      -- Using Userid,UserNAme & User MAchine ID For Log Purpose     

    OPEN P_Accounts2 FOR
    SELECT "Company_user","Admin" FROM LOGIN WHERE "userid"=Vusername;

ELSE
    OPEN P_Accounts FOR SELECT "username","password","userid","date_format","COM_CODE","Autogenerate","curr_code","comp_name",to_date(sysdate)-to_date(CREATION_DATETIME) as "diff", DISCOUNT,FILTER,ROLEID,"retainer_code" AS RETAINER FROM LOGIN
    WHERE "userid"=Vusername AND "password"=Vpassword AND ("retainer_code"=Vqbc) and STATUS !='I'/* or "retainer_code" in(select BRANCH_CODE from login_branch_mast where BRANCH_CODE =Vqbc and USER_CODE=Vusername and USER_FLAG='Y') )*/ and "Company_user" is null;

OPEN P_Accounts1 FOR SELECT "rate_gr_code","autogenerated","currency_code","date_format","solo","No_of_Decimal",
"breakup","blackwhitecode","uom_code","rostatus","Tfn","Insert_breakup","Premium_type","Deal_type"     ,
"prefix","suffix","financestatus","voucherst","Ad_category","Ro_datetime","Space_area","Vat","Booking_status","Cio_id","Receipt_no","Bgcolor_publication", "chkfor_valid_pubdates","Agency_ratecode","audit","copy_booking","RATE_COMPANY_AGENCY","SUBEDITIONRATE","ADDITIONAL_AGENCY_COMM","AGENCY_RETAINER_COMM",
"invoice_no","rate_audit",CLS_BILLTYPE,DIS_BILLTYPE,BILLING_FORMAT, RATE_CHECK, ALL_PACKAGE, DAYRATE,SCHEME_TYPE,DISP_CLSBILL,RECEIPT_FORMAT,CASH_RECEIPT_BILL, BILL_ORDERWSLAST, FLOOR_CHK,ROKEYCHECK,

DISP_CASHBILL, CLA_CASHBILL,RATE_AUDIT_PREF ,FA_LEDGER_ALLOW,CLEARANCE_TYPE_ALLOW,DISP_AUDITBKG
FROM PREFERRENCES WHERE "comp_code"=(SELECT "COM_CODE" FROM LOGIN WHERE "userid"=Vusername AND "password"=Vpassword);
BEGIN
SELECT "COM_CODE","username" INTO COUNT,v_nm FROM LOGIN WHERE "userid"=vusername AND "password"=vpassword AND "retainer_code"=vqbc;
EXCEPTION WHEN NO_DATA_FOUND THEN NULL;
END;

      -- Using Userid,UserNAme & User MAchine ID For Log Purpose
          sec_user.set_userid(vusername);
          sec_user.set_username(v_nm);
          sec_user.set_userip('');
      -- Using Userid,UserNAme & User MAchine ID For Log Purpose 

OPEN P_Accounts2 FOR
SELECT "Company_user","Admin" FROM LOGIN WHERE "userid"=Vusername;
END IF;



END Websp_Loginemployee_P;

END Websp_Loginemployee;
/
==========================================================================================================
                                                                     
                                                                     
                                                                     
                                             
CREATE OR REPLACE Package FA_RPT_accountmast1 is
   TYPE T_Accounts_Cursor is ref cursor;
  Procedure FA_RPT_accountmast1_p(
    pcompcode           in varchar2,
    pmaingrpcode           in varchar2,
    pprmgrpcode           in varchar2,
    psecgrpcode           in varchar2,
    pthirdgrpcode           in varchar2,
    P_Accounts          out T_Accounts_Cursor);  
End FA_RPT_accountmast1;
/
CREATE OR REPLACE PACKAGE BODY FA_RPT_accountmast1
IS
   PROCEDURE FA_RPT_accountmast1_p (

    pcompcode           in varchar2,
    pmaingrpcode           in varchar2,
    pprmgrpcode           in varchar2,
    psecgrpcode           in varchar2,
    pthirdgrpcode           in varchar2,
    P_Accounts          out T_Accounts_Cursor
   )
   AS
   BEGIN
      OPEN p_accounts FOR
      
        select 
         MAIN_GROUP  as "MAIN_GRP_CODE", fa_main_group_name( pcompcode  , FA_ACC_MAST.MAIN_GROUP ) as "MAIN_GRP_NAME",
         PSUB_GROUP as "PSUB_GRP_CODE",  fa_psub_group_name( pcompcode , FA_ACC_MAST.MAIN_GROUP,FA_ACC_MAST.PSUB_GROUP ) as "PSUB_GRP_CODE",
         SSUB_GROUP as "SSUB_GRP_CODE",  fa_ssub_group_name( pcompcode , FA_ACC_MAST.MAIN_GROUP,FA_ACC_MAST.PSUB_GROUP,FA_ACC_MAST.SSUB_GROUP) as "SSUB_GRP_NAME",
         TSUB_GROUP as "TSUB_GRP_CODE",  fa_tsub_group_name( pcompcode  , FA_ACC_MAST.MAIN_GROUP,FA_ACC_MAST.PSUB_GROUP,FA_ACC_MAST.SSUB_GROUP,FA_ACC_MAST.TSUB_GROUP) as "TSUB_GRP_NAME",
         ACC_TY  as "ACC_TYPE_CODE",    (select AC_TYPE_DESC from FA_ACCOUNT_TYPE_MAST where FA_ACCOUNT_TYPE_MAST.COMP_CODE=FA_ACC_MAST.COMP_CODE AND FA_ACCOUNT_TYPE_MAST.AC_TYPE_CODE = FA_ACC_MAST.ACC_TY ) as "ACC_TYPE_NAME",
         CDP, ACC_NAME ,ACC_NATURE from FA_ACC_MAST
                         where (COMP_CODE = pcompcode ) and 
                               (MAIN_GROUP = pmaingrpcode  or  pmaingrpcode IS NULL) and 
                               (PSUB_GROUP = pprmgrpcode  or  pprmgrpcode IS NULL) and 
                               (SSUB_GROUP = psecgrpcode  or  psecgrpcode IS NULL) and 
                               (TSUB_GROUP = pthirdgrpcode  or  pthirdgrpcode IS NULL)
                         order by MAIN_GROUP,PSUB_GROUP,SSUB_GROUP,TSUB_GROUP,CDP;
   END FA_RPT_accountmast1_p;
END FA_RPT_accountmast1;
/


/***************************Kuldeep Bhati 13/10/2011******0004884  ************************/


/****************start***********Mimoh mahajan 14/10/2011******0005264 ************************/

DROP PROCEDURE HT18JULY.ADD_CHKEDITCODE;

CREATE OR REPLACE PROCEDURE HT18JULY.ADD_CHKEDITCODE
(
pcompcode  in varchar2,
pedit_code  in varchar2,
pextra  in varchar2,
p_accounts   OUT   cur_type_new1.cursor_type
)
as
BEGIN
OPEN p_accounts FOR
Select * from EDITION_MAST where "Comp_Code"= pcompcode and "Edition_Code"=pedit_code;

END;
/

/****************end***********Mimoh mahajan 14/10/2011******0005264 ************************/




*****************************0005143********mimoh mahajan 16/oct/2011***************************
DROP PACKAGE HT18JULY.SP_CLIENTCONTACTUPDATE;

CREATE OR REPLACE PACKAGE HT18JULY.sp_clientcontactupdate is
procedure sp_clientcontactupdate_p(
custcode in varchar2,
contactperson in varchar2,
dob1 in date,
phone in varchar2,
ext in varchar2,
fax in varchar2,
mail in varchar2,
userid in varchar2,
compcode in varchar2,

contcode in varchar2,
mobile in varchar2,
anniversary1 in date);

end sp_clientcontactupdate;
/



DROP PACKAGE BODY HT18JULY.SP_CLIENTCONTACTUPDATE;

CREATE OR REPLACE PACKAGE BODY HT18JULY.sp_clientcontactupdate is
procedure sp_clientcontactupdate_p(
custcode in varchar2,
contactperson in varchar2,
dob1 in DATE,
phone in varchar2,
ext in varchar2,
fax in varchar2,
mail in varchar2,
userid in varchar2,
compcode in varchar2,

contcode in varchar2,
mobile in varchar2,
anniversary1 in date) as
begin
	 update Client_Cont_details set "Cont_Person"=contactperson,"DOB"=dob1,"Phone"=phone,"Extension"=ext,"Fax"=fax,"EmailId"=mail,MOBILENO=mobile,ANNIVERSARY=anniversary1
	 where  "UserId"=userid and "Cust_Code"=custcode and "Comp_Code"=compcode  and "Cont_Code"=contcode;
commit;
end sp_clientcontactupdate_p;
end sp_clientcontactupdate;
/

**************************************************************************************************************************************************************************************************
DROP PACKAGE HT18JULY.SP_CLIENTCONTACTDETAILS;

CREATE OR REPLACE PACKAGE HT18JULY.sp_clientcontactdetails IS
PROCEDURE sp_clientcontactdetails_P(
custcode in varchar2,
contact in varchar2,
dob in DATE,
phone in varchar2,
ext in varchar2,
fax in varchar2,
mail in varchar2,
userid in varchar2,
compcode in varchar2,
mobile in varchar2,
anniversary1 in date
);
End sp_clientcontactdetails;
/



DROP PACKAGE BODY HT18JULY.SP_CLIENTCONTACTDETAILS;

CREATE OR REPLACE PACKAGE BODY HT18JULY.sp_clientcontactdetails IS
PROCEDURE sp_clientcontactdetails_P(
custcode in varchar2,
contact in varchar2,
dob in DATE,
phone in varchar2,
ext in varchar2,
fax in varchar2,
mail in varchar2,
userid in varchar2,
compcode in varchar2,
mobile in varchar2,
anniversary1 in date
)As
Begin
insert into Client_Cont_details("Cont_Code","Cont_Person","DOB","Phone","Extension","Fax","EmailId","UserId","Creation_Datetime","Cust_Code","Comp_Code",MOBILENO,ANNIVERSARY) values(Cont_Code.nextval,contact,dob,phone,ext,fax,mail,userid,sysdate,custcode,compcode,mobile,anniversary1);
Commit;
end sp_clientcontactdetails_P;
End sp_clientcontactdetails;
/

****************************************************************************************************************************************************************************************************************************************
DROP PACKAGE HT18JULY.SP_CLIENTCONTACTBIND;

CREATE OR REPLACE PACKAGE HT18JULY.sp_clientcontactbind IS
TYPE T_Accounts_Cursor IS REF CURSOR;
PROCEDURE sp_clientcontactbind_p(
userid in varchar2,
custcode in varchar2,
compcode in varchar2,
P_Accounts  OUT  T_accounts_cursor
);
End sp_clientcontactbind;
/



DROP PACKAGE BODY HT18JULY.SP_CLIENTCONTACTBIND;

CREATE OR REPLACE PACKAGE BODY HT18JULY.sp_clientcontactbind IS

PROCEDURE sp_clientcontactbind_p(
userid in varchar2,
custcode in varchar2,
compcode in varchar2,
P_Accounts  OUT  T_accounts_cursor
)as
begin
Open P_Accounts for
select "Cont_Code" as "cont_code","Cont_Person" as "cont_person","DOB" as "dob","Phone" as "phone","Extension" as "extension","Fax" as "fax","EmailId" as "emailid","Cust_Code",MOBILENO,ANNIVERSARY from  Client_CONT_DETAILS where "Comp_Code"=compcode and "Cont_Code"=custcode;
end sp_clientcontactbind_p;
End sp_clientcontactbind;
/

******************************************************************************************************************************************************************
DROP PACKAGE HT18JULY.SP_CLIENTCONTACTBIND12;

CREATE OR REPLACE PACKAGE HT18JULY.sp_clientcontactbind12 IS
TYPE T_Accounts_Cursor IS REF CURSOR;
PROCEDURE sp_clientcontactbind12_p(
userid in varchar2,
custcode in varchar2,
compcode in varchar2,
date1 in varchar2,
P_Accounts  OUT  T_accounts_cursor
);
End sp_clientcontactbind12;
/



DROP PACKAGE BODY HT18JULY.SP_CLIENTCONTACTBIND12;

CREATE OR REPLACE PACKAGE BODY HT18JULY.sp_clientcontactbind12 IS

PROCEDURE sp_clientcontactbind12_p(
userid in varchar2,
custcode in varchar2,
compcode in varchar2,
date1 in varchar2,
P_Accounts  OUT  T_accounts_cursor
)as
Begin

if(date1='mm/dd/yyyy') then
OPEN P_Accounts  FOR
select "Cont_Person",to_char("DOB",'mm/dd/yyyy') as "dob","Phone","Extension","Fax","EmailId","Cust_Code","Cont_Code",MOBILENO,to_char(ANNIVERSARY,'mm/dd/yyyy') as ANNIVERSARY from  Client_CONT_DETAILS where "Comp_Code"=compcode and "Cust_Code"=custcode;-- and "UserId"=userid;
end if;

if(date1='dd/mm/yyyy') then
OPEN P_Accounts  FOR
select "Cont_Person",to_char("DOB",'dd/mm/yyyy') as "dob","Phone","Extension","Fax","EmailId","Cust_Code","Cont_Code",MOBILENO,to_char(ANNIVERSARY,'dd/mm/yyyy') as ANNIVERSARY from  Client_CONT_DETAILS where "Comp_Code"=compcode and "Cust_Code"=custcode;-- and "UserId"=userid;
end if;

if(date1='yyyy/mm/dd') then
OPEN P_Accounts  FOR
select "Cont_Person",to_char("DOB",'yyyy/mm/dd') as "dob","Phone","Extension","Fax","EmailId","Cust_Code","Cont_Code",MOBILENO,to_char(ANNIVERSARY,'yyyy/mm/dd') as ANNIVERSARY from  Client_CONT_DETAILS where "Comp_Code"=compcode and "Cust_Code"=custcode;-- and "UserId"=userid;
end if;


if(date1= null) then
OPEN P_Accounts  FOR
select "Cont_Person",to_char("DOB",'mm/dd/yyyy') as "dob","Phone","Extension","Fax","EmailId","Cust_Code","Cont_Code",MOBILENO,to_char(ANNIVERSARY,'mm/dd/yyyy') as ANNIVERSARY from  Client_CONT_DETAILS where "Comp_Code"=compcode and "Cust_Code"=custcode;-- and "UserId"=userid;
end if;
End sp_clientcontactbind12_p;
End sp_clientcontactbind12;
/
****************************************end 0005143 *******************************mimoh mahajan 16/oct/2011***************************************************
*********************************************garima ***********************issue number4666
CREATE OR REPLACE PACKAGE BODY websp_bindaudit
IS
   PROCEDURE websp_bindaudit_p (
fromdate IN varchar2,
todate IN varchar2,
date1 IN varchar2,
branch IN varchar2,
adtype IN varchar2,
publication in varchar2,
pub_cent in varchar2,
edition in varchar2,
agency in varchar2,
client in varchar2,
branchnew in varchar,
v_retainer in varchar,
v_executive in varchar,
v_supplement in varchar,
v_insert_status in varchar,
p_accounts   OUT      t_accounts_cursor
   )




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






if(v_insert_status is not null)
then
query1:=query1 ||' AND TBL_BOOKING_insert. "Insert_Status" ='''||v_insert_status||''' ';
end if;





if(v_insert_status is  null)
then
query1:=query1 ||' AND TBL_BOOKING_insert. "Insert_Status" in (''publish'',''audit by rate'') ';
end if;



IF(v_retainer   IS NOT NULL)
THEN
query1:=query1||'  and tbl_booking_mast ."RETAINER"='''||v_retainer ||'''';
END IF;


IF(v_executive  IS NOT NULL)
THEN
query1:=query1||'  and tbl_booking_mast ."Executive_code"='''||v_executive||'''';
END IF;











IF(v_supplement  IS NOT NULL)
THEN
query1:=query1||'  and TBL_BOOKING_insert ."Supp_Code"='''||v_supplement||'''';
END IF;





IF(branchnew  IS NOT NULL)
THEN
query1:=query1||'  and tbl_booking_mast ."branch"='''||branchnew||'''';
END IF;



IF(client IS NOT NULL)
THEN
query1:=query1||'  and tbl_booking_mast ."Client_code"='''||client||'''';
END IF;



IF(pub_cent IS NOT NULL)
THEN
query1:=query1||'  and tbl_booking_insert."Pub_Cent_Code"='''||pub_cent||'''';
END IF;



IF(agency IS NOT NULL)
THEN
query1:=query1 ||' and TBL_BOOKING_MAST."Agency_code" ='''||agency ||'''';
END IF;







IF(publication IS NOT NULL)
THEN
query1:=query1||' and  TBL_BOOKING_insert."Publication_Code"='''||publication||'''';
END IF;




IF(adtype IS NOT NULL)
THEN
query1:=query1 || '   and TBL_BOOKING_MAST. "Ad_type_code" ='''||adtype||'''';
END IF;

IF(fromdate IS NOT NULL AND todate IS NOT NULL )
THEN
    query1:=query1||' and "Insert_Date" between  '''||fromdate ||''' and  '''||todate||''' ';
END IF;

IF(edition IS NOT NULL)
THEN
query1:=query1||'  and tbl_booking_insert."Edition_Code"='''||edition||'''';
END IF;









OPEN p_accounts  FOR

query1;





--delete from ANK_SEARCH ;
--iNSERT INTO ANK_SEARCH VALUES(query1);



  --and "branch"=branch






   END websp_bindaudit_p;
END websp_bindaudit;
/
//////////////////////////////////////////end of issue numbner 4666**************







//==============================ISSUE NO.4887 19/10/2011============================================================

===========================================BODY==============================================================

CREATE OR REPLACE PACKAGE BODY HT18JULY.bindadcat345 Is
Procedure bindadcat345_P (adcat in varchar2,
adsubcat in varchar2:=null,
adssubcat in varchar2:=null,
compcode in varchar2,
P_Accounts Out T_Accounts_Cursor,
P_Accounts1 Out T_Accounts_Cursor,
P_Accounts2 Out T_Accounts_Cursor
)As

Begin



Open P_Accounts For
   select "catname","catcode" from ad_cat3 where "compcode"=compcode and "subcatname"=adcat order by "catname";

Open P_Accounts1 For
 select "Cat_Name","Cat_Code" from tbl_cat4 where "Comp_Code"=compcode and "Sub_Cat_Name"=adsubcat order by "Cat_Name";

Open P_Accounts2 For
 select "Cat_Name","Cat_Code" from tbl_cat5 where "Comp_Code"=compcode and "Sub_Cat_Name"=adssubcat order by "Cat_Name";





End bindadcat345_P;

End bindadcat345;
/

============================================DESCRIPTION=====================================================
CREATE OR REPLACE PACKAGE HT18JULY.bindadcat345 Is



Type T_Accounts_Cursor Is Ref Cursor;
Procedure bindadcat345_P (adcat in varchar2,
adsubcat in varchar2:=null,
adssubcat in varchar2:=null,
compcode in varchar2,
P_Accounts Out T_Accounts_Cursor,
P_Accounts1 Out T_Accounts_Cursor,
P_Accounts2 Out T_Accounts_Cursor
);

End bindadcat345;
/

/////////////////////////////////////////////////END OF ISSUE NO. 4887////////////////////////////////////////////



************************************************mimoh 19/oct*2011******************0005373************************************


DROP PACKAGE HT18JULY.WESP_UPDATEDATE;

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
p_aotosupply  IN VARCHAR2

);
END      Wesp_Updatedate;
/



DROP PACKAGE BODY HT18JULY.WESP_UPDATEDATE;

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
p_aotosupply  IN VARCHAR2

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

BILL_SCHEME=P_SCHEME_BILLING,ALLOWED_PDC_DAYS_RECEIPT=P_ALLOW_PDC ,AD_TYPE_MANUL_BILL=PAD_TYPE_FOR_MANUL_BILL,OUTSTANDING_AMT_CRITERIA=RO_OUTSTAND_P,GENRATE_CIR_AGCD=genrate_agency_code,DISP_AUDITBKG=p_dispauditbk,CIR_DIS_AUTO_POSTING=p_aotosupply
  
   WHERE "comp_code"=compcode;
COMMIT;
END      Wesp_Updatedate_p;
END      Wesp_Updatedate;
/

***********************************************************************************************************************
DROP PACKAGE HT18JULY.CURRBINDPREFERPGLD;

CREATE OR REPLACE PACKAGE HT18JULY.Currbindpreferpgld
IS
   TYPE t_account_cursor IS REF CURSOR;

   PROCEDURE currbindpreferpgld_p (
      compcode     IN       VARCHAR2,
      p_accounts   OUT      t_account_cursor
   );
END Currbindpreferpgld;
/



DROP PACKAGE BODY HT18JULY.CURRBINDPREFERPGLD;

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
           AD_TYPE_MANUL_BILL,OUTSTANDING_AMT_CRITERIA as RO_OUTSTAND,GENRATE_CIR_AGCD,DISP_AUDITBKG,CIR_DIS_AUTO_POSTING
           
            FROM PREFERRENCES
          WHERE "comp_code" = compcode;
          
         
   END currbindpreferpgld_p;
END Currbindpreferpgld;
/

******************************************************mimoh 19/oct/2011****************0005373****



/************* LATA 24 oct11***********/
CREATE OR REPLACE PROCEDURE InsertCashDetailExternalSource
(
cioid in varchar2,
receipt in varchar2,
compcode_p in varchar2,
userid_p in varchar2,
ip in varchar2,
p_Accounts     OUT      cur_type_new1.cursor_type
)
as
billpay varchar2(20);
rostatus varchar2(20);
receiptno varchar2(20);

begin 
select "Bill_pay","ro_status","Receipt_no" into billpay,rostatus,receiptno from  tbl_booking_mast where "cio_booking_id"=cioid;
 if billpay = 'CA0'  and (receiptno is null or receiptno = '') then
    update tbl_booking_mast set "Receipt_no"=receipt, "Receipt_date" = sysdate,
                "ro_status" = 1 where "cio_booking_id"=cioid;
    INSERT INTO TBL_EXT_BOOKING_RPT_DET(BOOKINGID, RECEIPTNO, COMPCODE, USERID, IP_USER, DATE_TIME)
        VALUES(cioid,receipt,compcode_p,userid_p,ip,sysdate);
        commit;
 end if;
 open p_Accounts for
 select  receipt  as RECPTNO from dual;
end;
/


*****************************mimoh 24 oct 2011***********0005367***********************************
DROP PROCEDURE HT18JULY.ADBARTER_CHECKDUPLICACY;

CREATE OR REPLACE PROCEDURE HT18JULY.Adbarter_checkduplicacy
(
compcode in varchar2,
unitcode in varchar2,
branchcode in varchar2,
bartercode in varchar2,
barterdesc in varchar2,
agencycode in varchar2,
agencysubcode in varchar2,
p_accounts   OUT   cur_type_new1.cursor_type,
p_accounts1   OUT   cur_type_new1.cursor_type
)

as
begin
 open p_accounts for
 select * from ad_barter where COMP_CODE=compcode and UNIT_CODE=unitcode and BRAN_CODE=branchcode and BARTER_CODE =bartercode and AG_CODE=agencycode and AG_SUBCODE=agencysubcode;
 
  open p_accounts1 for
 select * from ad_barter where COMP_CODE=compcode and UNIT_CODE=unitcode and BRAN_CODE=branchcode and BARTE_DESC =barterdesc  and AG_CODE=agencycode and AG_SUBCODE=agencysubcode;
end;
/

***************************************mimoh 24 oct 2011*******0005367********************************************



//*****************************orcl mimoh 31oct 2011**********start-0005464/**********************



DROP PACKAGE HT18JULY.RETAINEREXEC;

CREATE OR REPLACE PACKAGE HT18JULY.Retainerexec IS

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



DROP PACKAGE BODY HT18JULY.RETAINEREXEC;

CREATE OR REPLACE PACKAGE BODY HT18JULY.Retainerexec IS

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
(SELECT  "Status_Name" FROM TBLSTATUS WHERE "Status_Code" =(select STATUS_NAME from ret_status_detail where "Retain_Code"=RETAINERMASTER."Retain_Code" and rownum <=1 AND sysdate between "FROM_DATE" and "TO_DATE")) as "Retain_status",SYSDATE,SYSDATE,"pubcent_code","BOXMATTER","PUBLICATION","EDITION","SUPPLEMENT","TALUKA",REPRESENTATIVE as "repname","Branch_code",CREDIT_LIMIT,MOBILENO,"SIGN" FROM  RETAINERMASTER
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

//***********************************************************************************************************************
DROP PACKAGE HT18JULY.RETAINERINSERTDETAIL;

CREATE OR REPLACE PACKAGE HT18JULY.RetainerInsertDetail Is



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
signature in varchar2
);

End RetainerInsertDetail;
/



DROP PACKAGE BODY HT18JULY.RETAINERINSERTDETAIL;

CREATE OR REPLACE PACKAGE BODY HT18JULY.RetainerInsertDetail Is

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
signature in varchar2
) As

  Begin
    if flag = '0' then
   insert into RetainerMaster("Comp_Code" ,"Retain_Code" ,"userid" ,"Retain_Name" ,"Retain_Alias" ,"Add1" ,"Street" ,"City_Code" ,"Zip" ,"Dist_Code" ,"State_Code" ,"Zone_Code","Region_Code","Country_Code" ,"Phone1" ,"Phone2" ,"Fax" ,"EmailID" ,"PAN_No" ,"Credit_Days","Remarks" , "pubcent_code","Creation_Datetime", "Retain_status", "To_date","BOXMATTER","PUBLICATION","EDITION","SUPPLEMENT","TALUKA",REPRESENTATIVE,"Branch_code",CREDIT_LIMIT,MOBILENO,"SIGN")values (Comp_Code1,Retain_Code1,userid1,Retain_Name1,Retain_Alias1,Add11,Street1,City_Code1,Zip1,Dist_Code1,State_Code1,zone_code1,region_code1,Country_Code1,phone11,Phone21,Fax1,EmailID1,PAN_No1,Credit_Days1,Remarks1,pubcent,sysdate,'','',Box,Publication1,Edition1,Supplement1,taluka1,repname,branchcode,creditlimit,mobile1,signature) ;
   else
   update RetainerMaster set "Retain_Name" = Retain_Name1  ,"Retain_Alias" =Retain_Alias1 ,"Add1" = Add11,"Street" = Street1,"City_Code" =City_Code1 ,"Zip" = Zip1,  "Dist_Code" = Dist_Code1 ,"State_Code" = State_Code1 ,"Zone_Code" = zone_code1,"Region_Code" = region_code1,"Country_Code" = Country_Code1,"Phone1" = phone11,"Phone2" =Phone21,"Fax" =Fax1 ,"EmailID" =EmailID1 ,"PAN_No" = PAN_No1,"Credit_Days" = Credit_Days1,"Remarks" =Remarks1, "pubcent_code"=pubcent, "BOXMATTER"=Box,"PUBLICATION"=Publication1,"EDITION"=Edition1,"SUPPLEMENT"=Supplement1,"TALUKA"=taluka1,REPRESENTATIVE=repname,"Branch_code"=branchcode,CREDIT_LIMIT=creditlimit,MOBILENO=mobile1,"SIGN"=signature where "Comp_Code" = Comp_Code1 and "Retain_Code" = Retain_Code1;
   end if;
    commit;
   End RetainerInsertDetail_P;
 End RetainerInsertDetail;
/

/*************************************************************************************************
DROP PACKAGE HT18JULY.ADVTEAMDETAIL;

CREATE OR REPLACE PACKAGE HT18JULY.AdvTeamDetail
is
Type T_Accounts_Cursor is Ref Cursor;

procedure AdvTeamDetail_p
(
Comp_Code in varchar2,
Team_Code in varchar2,
Team_Name in varchar2,
userid in varchar2,
zone in varchar2,
Flag in varchar2,
signature in varchar2,
P_Accounts out T_Accounts_Cursor,
P_Accounts1 out T_Accounts_Cursor
);

end  AdvTeamDetail;
/



DROP PACKAGE BODY HT18JULY.ADVTEAMDETAIL;

CREATE OR REPLACE PACKAGE BODY HT18JULY.y                                              AdvTeamDetail
is
procedure AdvTeamDetail_p
(
Comp_Code in varchar2,
Team_Code in varchar2,
Team_Name in varchar2,
userid in varchar2,
zone in varchar2,
Flag in varchar2,
signature in varchar2,
P_Accounts out T_Accounts_Cursor,
P_Accounts1 out T_Accounts_Cursor

) as

countnum number;

--set "Team_Code"=replace("Team_Code",'','''')
begin

if(Flag='0')then
open P_Accounts for
select  "Comp_Code","Team_Code","Team_Name","Userid","Creation_Datetime","ad_cat","branch_code","SIGN"  from Adv_Exec_Master
 where "Comp_Code"=Comp_Code /*and "Userid"=userid*/
AND ("Team_Code" LIKE Team_Code||'%' OR Team_code IS NULL)
AND ("Team_Name" LIKE Team_Name||'%' OR Team_Name IS NULL)
AND ("branch_code" LIKE zone||'%' OR zone IS NULL);

end if;

open P_Accounts1 for
select * from Adv_Exec_Master where  "Comp_Code" = Comp_Code; -- and "Userid"=userid;

if(Flag='1')then
insert into Adv_Exec_Master("Comp_Code","Team_Code","Team_Name","Userid","Creation_Datetime","branch_code","SIGN") values(Comp_Code,Team_Code,Team_Name,userid,sysdate,zone,signature);
 commit;
end if;

if(Flag=2)then
update Adv_Exec_Master set "Team_Name"=Team_Name , "branch_code"=zone,"SIGN"=signature where "Team_Code"=Team_Code and "Comp_Code"=Comp_Code;
-- update exec_mast set "Branch_code"=zone where "Team_code"=Team_Code and "comp_code"=Comp_Code;
commit;
end if;

if(Flag=3)then
select count(*) into countnum from tbl_booking_mast where "Executive_code" in(select "Exe_no" from exec_mast where "Team_code" = Team_Code);
if countnum=0 then
delete from Adv_Exec_Master where "Comp_Code"=Comp_Code and "Team_Code" = Team_Code and "Team_Name"= Team_Name and "branch_code"=zone;
delete from Exec_mast where "comp_code" = Comp_Code and "Team_code" = Team_Code;
delete from exec_adcat where TEAMCODE=Team_Code;
end if;
end if;


if(Flag=5)then
open P_Accounts for
select * from exec_mast where  "comp_code" = Comp_Code and "Team_code" = Team_Code;
end if;


if(Flag=6)then
open P_Accounts for
select * from adv_exec_master where "Comp_Code" = Comp_Code and "Team_Code" = Team_Code;
end if;

end AdvTeamDetail_p;
end AdvTeamDetail;
/

//*********************************************************************************************************************************************
DROP PACKAGE HT18JULY.ADVTEAMDETAILSAVE;

CREATE OR REPLACE PACKAGE HT18JULY.AdvTeamDetailSave is

procedure AdvTeamDetailSave_p(
Comp_Code in varchar2,
Team_Code in varchar2,
Team_Name in varchar2,
userid in varchar2,
zone in varchar2,
signature in varchar2
);
end AdvTeamDetailSave;
/



DROP PACKAGE BODY HT18JULY.ADVTEAMDETAILSAVE;

CREATE OR REPLACE PACKAGE BODY HT18JULY.AdvTeamDetailSave is

procedure AdvTeamDetailSave_p(Comp_Code in varchar2,
Team_Code in varchar2,
Team_Name in varchar2,
userid in varchar2,
zone in varchar2,
signature in varchar2)as
begin

 insert into Adv_Exec_Master("Comp_Code","Team_Code","Team_Name","Userid","Creation_Datetime","branch_code","SIGN") values(Comp_Code,Team_Code,Team_Name,userid,sysdate,zone,signature);

commit;

end  AdvTeamDetailSave_p;
end AdvTeamDetailSave;
/




//*****************************orcl mimoh 31oct 2011**********end*******-0005464/**********************
//*****************************orcl mimoh 31oct 2011**********start*******-0005467 /**********************//

DROP PACKAGE CURRBINDPREFERPGLD;

CREATE OR REPLACE PACKAGE Currbindpreferpgld
IS
   TYPE t_account_cursor IS REF CURSOR;

   PROCEDURE currbindpreferpgld_p (
      compcode     IN       VARCHAR2,
      p_accounts   OUT      t_account_cursor
   );
END Currbindpreferpgld;
/



DROP PACKAGE BODY CURRBINDPREFERPGLD;

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
           AD_TYPE_MANUL_BILL,OUTSTANDING_AMT_CRITERIA as RO_OUTSTAND,GENRATE_CIR_AGCD,DISP_AUDITBKG,CIR_DIS_AUTO_POSTING,RELAUTHREQON
           
            FROM PREFERRENCES
          WHERE "comp_code" = compcode;
          
         
   END currbindpreferpgld_p;
END Currbindpreferpgld;
/



//***************************************************************************************************//
DROP PACKAGE WESP_UPDATEDATE;

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
p_Authorization IN VARCHAR2

);
END      Wesp_Updatedate;
/



DROP PACKAGE BODY WESP_UPDATEDATE;

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
p_Authorization IN VARCHAR2

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

BILL_SCHEME=P_SCHEME_BILLING,ALLOWED_PDC_DAYS_RECEIPT=P_ALLOW_PDC ,AD_TYPE_MANUL_BILL=PAD_TYPE_FOR_MANUL_BILL,OUTSTANDING_AMT_CRITERIA=RO_OUTSTAND_P,GENRATE_CIR_AGCD=genrate_agency_code,DISP_AUDITBKG=p_dispauditbk,CIR_DIS_AUTO_POSTING=p_aotosupply,RELAUTHREQON=p_Authorization
  
   WHERE "comp_code"=compcode;
COMMIT;
END      Wesp_Updatedate_p;
END      Wesp_Updatedate;
/






//*****************************orcl mimoh 31oct 2011**********end*******-0005467 /**********************//




//////////////issue no 7947///////////////////////


CREATE OR REPLACE PACKAGE HT18JULY.execcontactupdate is
procedure execcontactupdate_p(
exename varchar2,
teamcode  varchar2,
designation  varchar2,
address  varchar2,
street  varchar2,
city  varchar2,
district  varchar2,
state  varchar2,
country  varchar2,
pin  varchar2,
phone  varchar2,
status  varchar2,
compcode  varchar2,
userid  varchar2,
code  varchar2,
report  varchar2,
TALUKA1  varchar2,
repname in varchar2,
adtype1 in varchar2,
branchcode in varchar2,
craditlimit varchar2,
mobile in varchar2,
email in varchar2,
mailto in varchar2,
p_empcode in varchar2,
pattachment in varchar2
);
end  execcontactupdate;
/
////////////////////////////////////////////////


CREATE OR REPLACE PACKAGE BODY HT18JULY.execcontactupdate is
procedure execcontactupdate_p(
exename varchar2,
teamcode  varchar2,
designation  varchar2,
address  varchar2,
street  varchar2,
city  varchar2,
district  varchar2,
state  varchar2,
country  varchar2,
pin  varchar2,
phone  varchar2,
status  varchar2,
compcode  varchar2,
userid  varchar2,
code  varchar2,
report  varchar2,
TALUKA1  varchar2,
repname in varchar2,
adtype1 in varchar2,
branchcode in varchar2,
craditlimit in varchar2,
mobile in varchar2,
email in varchar2,
mailto in varchar2,
p_empcode in varchar2,
pattachment in varchar2
)as

cityname varchar2(10);
countryname varchar2(10);

begin

update  Exec_mast set  "Exec_name"=exename,"Designation"=designation,"Add1"=address,"Street"=street,"Country_code"=country,"State_code"=state,"dist_code"=district,"city_code"=city,"phone"=phone,"exe_status"=status,"pin_code"=pin, "report_to"=report ,"TALUKA" = TALUKA1, REPRESENTATIVE=repname,ADTYPE=adtype1,"Branch_code"=branchcode,CREDIT_LIMIT=craditlimit,MOBILENO=mobile,EMAILID=email,HR_CODE =p_empcode,EMAIL_ID=mailto ,"ATTACHMENT"=pattachment where "comp_code"=compcode and "Exe_no"=code;


update Exec_mast set "CIty_Name"=(select "City_Code" from city_mst where "City_Code"=city) where "city_code"=city;

--update Exec_mast set "CIty_Name"=(select "CIty_Name" from city_mst where "city_code"=city) where "city_code"=city;
--update EXEC_ADCAT set catcode=adcategory;
commit;

end execcontactupdate_p;

end  execcontactupdate;
/



/////////////////////////////////////////////////////////////


CREATE OR REPLACE PACKAGE HT18JULY.execcontactinsert is
Type T_Accounts_Cursor is Ref Cursor;
procedure execcontactinsert_p(
exename in varchar2,
teamcode in varchar2,
designation in varchar2,
address in varchar2,
street in varchar2,
city in varchar2,
district in varchar2,
state in varchar2,
country in varchar2,
pin in varchar2,
phone in varchar2,
status in varchar2,
compcode in varchar2,
userid in varchar2,
report in varchar2,
taluka1 in varchar2,
repname in varchar2,
adtype1 in varchar2,
branchcode in varchar2,
craditlimit in varchar2,
mobile in varchar2,
email in varchar2,
mailto in varchar2,
p_empcode in varchar2,
attachment in varchar2,
P_Accounts out T_Accounts_Cursor
);
end execcontactinsert;
/




/////////////////////////////////////////////////////



CREATE OR REPLACE PACKAGE BODY HT18JULY.execcontactinsert is
procedure execcontactinsert_p(
exename in varchar2,
teamcode in varchar2,
designation in varchar2,
address in varchar2,
street in varchar2,
city in varchar2,
district in varchar2,
state in varchar2,
country in varchar2,
pin in varchar2,
phone in varchar2,
status in varchar2,
compcode in varchar2,
userid in varchar2,
report in varchar2,
taluka1 in varchar2,
repname in varchar2,
adtype1 in varchar2,
branchcode in varchar2,
craditlimit in varchar2,
mobile in varchar2,
email in varchar2,
mailto in varchar2,
p_empcode in varchar2,
attachment in varchar2,
P_Accounts out T_Accounts_Cursor
)as
exeno int;
begin
select Exe_no_ident1.nextval into exeno from dual;
insert into Exec_mast("Exe_no","Team_code","Exec_name","Designation","Add1","Street","Country_code","State_code","dist_code","city_code","phone","exe_status","userid","comp_code","pin_code","report_to","TALUKA","creation_datetime",REPRESENTATIVE,ADTYPE,"Branch_code",CREDIT_LIMIT,MOBILENO,EMAILID,HR_CODE,EMAIL_ID,ATTACHMENT )
values(exeno,teamcode,exename,designation,address,street,country,state,district,city,phone,status,userid,compcode,pin,report,taluka1,sysdate,repname,adtype1,branchcode,craditlimit,mobile,email,p_empcode,mailto,attachment);



update Exec_mast set "CIty_Name"=(select "City_Name" from city_mst where "City_Code"=city) where "city_code"=city;
commit;
open P_Accounts for
select exeno as "exeno" from dual;
end execcontactinsert_p;
end execcontactinsert;
/
///////////////////////////////////////////////////////////////


CREATE OR REPLACE PACKAGE HT18JULY.execcontactbind_grid is
Type T_Accounts_Cursor is Ref Cursor;
procedure execcontactbind_grid_p(
teamcode in varchar2,
compcode in varchar2,
userid in varchar2,
P_Accounts out T_Accounts_Cursor);

end  execcontactbind_grid;
/



//////////////////////////////////////////////



CREATE OR REPLACE PACKAGE BODY HT18JULY.execcontactbind_grid is
procedure execcontactbind_grid_p(
teamcode in varchar2,
compcode in varchar2,
userid in varchar2,
P_Accounts out T_Accounts_Cursor)

as


--variables declaration

Designation1 varchar2(350);
Country_code1 varchar2(520);
city_code1 varchar2(250);
report_to1 varchar2(250);
Exec_name  varchar2(350);
Designation varchar2(350);
Add1 varchar2(505);
Street varchar2(505);
city_code varchar2(458);
dist_code varchar2(158);
State_code varchar2(158);
Country_code  varchar2(485);
pin_code varchar2(205);
phone varchar2(350);
exe_status varchar2(520);
Exe_no varchar2(205);
city_name varchar2(250);
Team_code varchar2(358);
zip varchar2(105);
comp_code varchar2(58);
report_to varchar2(385);
creation_datetime varchar2(105);
TALUKA_V VARCHAR2(100);
REPRESENTATIVE_V VARCHAR2(100);
 TALUKA_V_NEW VARCHAR2(100);
 ATTACHMENT varchar(100);

 REPRESENTATIVE_V_NEW VARCHAR2(100);
Branch_code_v varchar(50);
Branch_Name varchar(100);


--variables ended



--SELECT * FROM TAB WHERE UPPER(TNAME) LIKE '%ADV%'




begin

	DECLARE CURSOR sss is

	select distinct  "Designation","city_code","Country_code","report_to","Exe_no",TALUKA, REPRESENTATIVE,"Branch_code",ATTACHMENT from Exec_mast
	where "comp_code"=compcode  and "Team_code"=teamcode;


	begin
		OPEN sss;
			loop
				FETCH sss into Designation,city_code,Country_code,report_to,Exe_no,TALUKA_V, REPRESENTATIVE_V,Branch_code_v,ATTACHMENT;
				exit when sss%notfound;


				begin
					select "Agency_Role_Name" into Designation1 from Agency_Role_Master
					where "Agency_Role_Code"=Designation;
					EXCEPTION
					WHEN NO_DATA_FOUND THEN
					  NULL;
				end;

				begin
					select "City_Name" into city_code1 from city_mst where "City_Code"=city_code;
					EXCEPTION
					WHEN NO_DATA_FOUND THEN
					  NULL;
				end;
                
                begin
					select "Branch_Name" into Branch_Name from branch_mst where "Branch_Code"=Branch_code_v;
					EXCEPTION
					WHEN NO_DATA_FOUND THEN
					  NULL;
				end;


				begin
					select "Country_Name" into Country_code1 from count_mst where "Country_Code"=Country_code;
					EXCEPTION
					WHEN NO_DATA_FOUND THEN
					   NULL;
				end;
				if(report_to<>'0') then
					begin
						select "Name_all" into report_to1 from all_module_master where "All_module_code"=report_to;
   						EXCEPTION
						WHEN NO_DATA_FOUND THEN
						NULL;
					end;
					else
    					report_to1:=null;
 			    end if;



				begin

					select TALU_NAME into TALUKA_V_NEW from taluka_mast where TALU_CODE=TALUKA_V;
					EXCEPTION
					WHEN NO_DATA_FOUND THEN
					   NULL;
				end;


				begin

					select "Rep_Name" into REPRESENTATIVE_V_NEW from REP_MAST where "Rep_code"=REPRESENTATIVE_V;
					EXCEPTION
					WHEN NO_DATA_FOUND THEN
					   NULL;
				end;







BEGIN

					insert into temp_adv_NEW1 select distinct "Exe_no","Team_code","Exec_name",Designation1,"Add1","Street"
					,Country_code1,"State_code","dist_code",city_code1,"zip","phone","exe_status","userid","comp_code",
					"pin_code","CIty_Name",report_to1, TALUKA_V_NEW, REPRESENTATIVE_V_NEW,Branch_Name,ATTACHMENT from Exec_mast where "comp_code"=compcode  and "Team_code" =teamcode
					and "Exe_no"=Exe_no;

				exception
				when no_data_found then
					 null;


			     end;
				/*open P_Accounts for
			select *  from temp_adv;*/



			end loop;





		CLOSE sss;
		  open P_Accounts for
			--select EXE_NO, TEAM_CODE, EXEC_NAME, DESIGNATION, ADD1, STREET, COUNTRY_CODE, STATE_CODE, DIST_CODE, CITY_CODE, ZIP, PHONE, EXE_STATUS, USERID, COMP_CODE, PIN_CODE, CITY_NAME, BRANCH_CODE, REPORT_TO, TALUKA, REPNAME  from temp_adv_NEW1;
            select distinct EXE_NO,EXEC_NAME, DESIGNATION,ADD1,STREET, CITY_CODE,DIST_CODE,STATE_CODE, COUNTRY_CODE,PIN_CODE,PHONE,EXE_STATUS,EXE_NO,CITY_NAME,BRANCH_CODE,REPORT_TO ,TALUKA ,REPNAME,ATTACHMENT  from temp_adv_NEW1;
			delete  temp_adv_NEW1;
	end;

end execcontactbind_grid_p;
end execcontactbind_grid;
/
//////////////////////////////////


////////////////////issue of 8461///////////////////////////////

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
p_Credit_Account_Bank IN VARCHAR2,
P_BAR_CODE IN VARCHAR2,
P_GEN_RCT_TYP IN VARCHAR2,
P_WEIGHT_CAL IN VARCHAR2,
P_misdata IN VARCHAR2,
P_allowpremium IN VARCHAR2,
p_financecode in varchar2,
p_exepub in varchar2,
p_executivecreditlimit in varchar2
);
END      Wesp_Updatedate;
/


////////////////////////////////////////////

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
p_Credit_Account_Bank IN VARCHAR2,
P_BAR_CODE IN VARCHAR2,
P_GEN_RCT_TYP IN VARCHAR2,
P_WEIGHT_CAL IN VARCHAR2,
P_misdata IN VARCHAR2,
P_allowpremium IN VARCHAR2,
p_financecode in varchar2,
p_exepub in varchar2,
p_executivecreditlimit in varchar2

)AS
BEGIN
UPDATE LOGIN SET "date_format"=dateformat,
"Autogenerate"=code,"curr_code"=curr WHERE "COM_CODE"=compcode;
COMMIT;
       UPDATE PREFERRENCES SET  "autogenerated"=code,
"currency_code"=curr ,
"rate_gr_code"=RATECODE11,
"date_format"=dateformat,"solo"=solo,"breakup"=breakup,
"blackwhitecode"=bwcode,"rostatus"=rostatus,"File_name"=filename,"Tfn"=tfn,
"Insert_breakup"=insertbreak,"Premium_type"=prem,"Deal_type"=dealtype  ,
 "prefix"=pre, "suffix"=suff, "financestatus"=financestatus ,
"voucherst"=voucherst,
 "Ad_category"=adcode ,"Ro_datetime"=rodatetime
,"Space_area"=spacearea,"Vat"=vat,
 "Booking_status"=bookstat,"Cio_id"=cio_id,"Receipt_no"=receipt_no,"uom_code"=uom,
 "Bgcolor_publication"=bgcolor ,"chkfor_valid_pubdates"=validdate,
"Agency_ratecode"=agencyratecode,
 "audit"=AUDIT1,"book_insert_date"=book_insert_date,"agencycomm"=agencycomm,
 "rate_audit"=rateaudit,"bill_audit"=billaudit,"billtype"=bill_type,"invoice_no"=invoice_no1,
 "copy_booking"=copybooking,"RATE_COMPANY_AGENCY"=ratecompany,
"ADDITIONAL_AGENCY_COMM"=addagenycomm ,
 "AGENCY_RETAINER_COMM"=agencycommlinkretainer,"SUBEDITIONRATE"=subeditionr,
 "CLS_BILLTYPE"=classifiedbilltype,"DIS_BILLTYPE"=displaybilltype,"BILLING_FORMAT"=billformat,
 "RATE_CHECK"=ratechk,"ALL_PACKAGE"=allpkg,"DAYRATE"=dayrate1,"SCHEME_TYPE"=schemetype,"DISP_CLSBILL"=PIncludeclassi
 ,
 "CASH_RECEIPT_BILL"=v_cash_receipt,
"BILL_ORDERWSLAST"=v_bill_orderwiselast, "FLOOR_CHK"=v_floor_chk ,
 "UNSOLD_ENTRY_FLAG"=Unsoldflag
,"SUPPLY_STOP_PERCENTAGE"=Supplystopper,"ROKEYCHECK"=drpRokeychk ,
 "AGENCYCOMM_SEQ_COM"=Agencycomm_seq
,"CREDIT_RECIPT"=creditreciept,"DISP_CASHBILL"=cashindisplay,
 "CLA_CASHBILL"=cashinclassified,"RATE_AUDIT_PREF"=v_rate_audit_pref,"BARCODING_ALLOWED"=v_barcoding_allow_pref,
 "FMG_BILL_DIS" =v_fmgbills, "BILL_DISP_CASHBILL"=v_billed_cashdis ,
"BILL_CLA_CASHBILL"=v_billed_cashcls,"BACKDATERECEIPT"=v_drpbackdate,"DOCKIT_BOOKING"=dockitbooking,"Allowed_old_date"=allowprevbooking,"ROWISE_CASHBOOKING"=ro_wisecashbill,"CUTOFFTIME"=chkval,"APPROVAL"=approval1,"BACK_DAYS"=pckstatus
,CASH_DISCOUNT=cash_amt,CASH_DISCOUNTTYPE=cash_disc,SEPRATE_CASHIER=seperate_cashier1,
  CIR_MANY_TIME_POSTING=mantimepost, CIR_BACKDAYS_POSTING=bkdaypost,
CIR_MAX_RETURN_ALLOW=maxterutn, CIR_RETURN_LIMIT_ALLOW=cir_return,
CIR_NO_OF_CHQBOUNCE=noofchkbounc, CIR_DAYS_CHQBOUNCE=noofdaychkrec,
CIR_RETURN_DAYS=retday, CIR_SUP_ORDER_LIMIT=chngsuppord,
DISP_BILLING_CRITERIA=disp_bill,
CLSD_BILLING_CRITERIA=clas_bill,MAX_PUBLISHDAYS=max_publishday,BILLNO_PERIODICITY=p_billno_period,
  SPECIALDISC_TRANS_EDIT=spl_trans_edit,
SHARING_TRANS=spl_dis_trans_editable,
MULTIPACKAGE_SEL_TRANS=mul_pac_sel_trans,SCHEME_MINWORD=shmon_minword,
TRADE_SPLCHARGE=tradon_spcrg,RATE_AUTHORIZATION=rateauth
 ,F2_RECORD=f2day,PUBLISHAD_EDIT_RATEAUDIT=rateauditmodify,BINDREVENUE_CENTER=bindrevenuecenter,
 FA_LEDGER_ALLOW=p_led_allow
,CLEARANCE_TYPE_ALLOW=p_clear_allow,REPEAT_DAY_TYPE=repeatday,PREMIUM_EDIT=premiumedit,
BILL_GENERATION_PRIOR=P_BILL_GENERATION,PUBLICATION_HO=P_PUBLICATION_CENTER,SPLDISC_ALLOWPREM=P_allow_discount_prem,

BILL_SCHEME=P_SCHEME_BILLING,ALLOWED_PDC_DAYS_RECEIPT=P_ALLOW_PDC
,AD_TYPE_MANUL_BILL=PAD_TYPE_FOR_MANUL_BILL,OUTSTANDING_AMT_CRITERIA=RO_OUTSTAND_P,GENRATE_CIR_AGCD=genrate_agency_code,DISP_AUDITBKG=p_dispauditbk,CIR_DIS_AUTO_POSTING=p_aotosupply,RELAUTHREQON=p_Authorization,
CIR_AUTO_APPROVAL_UNSOLD=p_CIR_AUTO_APPROVAL_UNSOLD,CIR_AUTO_PHYSICAL_UNSOLD=p_CIR_AUTO_PHYSICAL_UNSOLD,CIR_UNSOLD_INCLUDE_INCT=p_CIR_UNSOLD_INCLUDE_INCT,
CIR_UNSOLD_INCLUDE_INSFEE=p_CIR_UNSOLD_INCLUDE_INSFEE,CIR_UNSOLD_ON_RECEIVED_DT=p_CIR_UNSOLD_ON_RECEIVED_DT,
AGENCY_UNBLOCK_APPROVAL=p_AGENCY_UNBLOCK_APROV,UNBLOCK_APPROVAL_OUTSIDE_LIMIT=p_UNBLOCK_APROV_OUT_LMT,CIR_BILL_PUBLWISE=p_CIR_BILL_PUBLWISE,
RECORDS_ON_PAGE = p_paging,RECORDS_ON_PRINT = p_print,HEADER_ON_PAGE =
p_allowpage,AGENCY_REQUIRED = p_agency_req,REGION_REQUIRED =
p_region_req,
ALLOW_FOLLOW_DT_BOOOK=p_ALLOW_FOLLOW_DT_BOOOK,CRM_SUPPLY_TYPE_PAID=p_CRM_SUPPLY_TYPE_PAID,CRM_SUPPLY_TYPE_FREE=p_CRM_SUPPLY_TYPE_FREE,
CURRENCY_MEASUREMENT=p_CURRENCY_MEASUREMENT,EDITABLE_AGENCY_COMM=p_EDITABLE_AGENCY_COMM,CANCELLATION_CHARGE=p_CANCELLATION_CHARGE,taxi_entry_type=P_taxi_entry_type,APPROVAL_WITH
=P_ApprovalWith , TDS_AUTO_CN=p_Auto_TDS_Credit_Note,
TDS_AUTO_REASON=p_TDS_Reason
,TDS_DB_CDP=p_Debit_Account_Head,TDS_CR_CDP=p_credit_Account_Head,SER_TAX_AUTO_CN=p_service_tax_credit_note,SER_TAX_AUTO_REASON=p_Tax_Reason,SER_TAX_DB_CDP=p_Debit_Account_Service_Tax,SER_TAX_CR_CDP=p_Credit_Account_Service_Tax,PKK_AUTO_CN=p_Auto_Patrakar_Credit_Note,PKK_AUTO_REASON=p_Patrakar_Reason
,PKK_DB_CDP=p_Debit_Account_Patrakar,PKK_CR_CDP=p_Credit_Account_Patrakar
,BANK_CHG_AUTO_CN=p_Auto_Bank_Credit_Note ,
BANK_CHG_AUTO_REASON=p_Bank_Reason
,BANK_CHG_DB_CDP=p_Debit_Account_Bank
,BANK_CHG_CR_CDP=p_Credit_Account_Bank ,


CIR_BARCODE=P_BAR_CODE, CIR_WIEGHT_CALC_REQ =P_WEIGHT_CAL, GEN_RCT_TYP
=P_GEN_RCT_TYP,PRODUCT_BRAND_REQ=P_misdata,ALLOWPREM_CARD_DISC_RATE=P_allowpremium,FINANCE_CADE=p_financecode,EXECUTIVE_PUBLICATION_VISE=p_exepub,EXECUTIVECREDITLIMIT=p_executivecreditlimit


  WHERE "comp_code"=compcode;
COMMIT;
END      Wesp_Updatedate_p;
END      Wesp_Updatedate;
/


///////////////////////////////

CREATE OR REPLACE PACKAGE HT18JULY.Currbindpreferpgld
IS
   TYPE t_account_cursor IS REF CURSOR;

   PROCEDURE currbindpreferpgld_p (
      compcode     IN       VARCHAR2,
      p_accounts   OUT      t_account_cursor
   );
END Currbindpreferpgld;
/
\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\


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
                cir_wieght_calc_req, gen_rct_typ, product_brand_req, ALLOWPREM_CARD_DISC_RATE,FINANCE_CADE,EXECUTIVE_PUBLICATION_VISE,EXECUTIVECREDITLIMIT,
                CIR_POST_DIS,
    CIR_VAT_ALLOW,
    CIR_SUP_ALT_ROUTE,
    SHOW_REC_ALL_AGENCY,
    CIR_SUP_ORDER_DEC_LIMIT,
    CIR_ALLOW_HOLIDAY_SUN,
    CIR_ALLOW_HOLIDAY_MON,
    CIR_ALLOW_HOLIDAY_TUE,
    CIR_ALLOW_HOLIDAY_WED,
    CIR_ALLOW_HOLIDAY_THU,
    CIR_ALLOW_HOLIDAY_FRI,
    CIR_ALLOW_HOLIDAY_SAT
           FROM preferrences
          WHERE "comp_code" = compcode;
   END currbindpreferpgld_p;
END currbindpreferpgld;
/
\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\end of 8461////////////////////////
