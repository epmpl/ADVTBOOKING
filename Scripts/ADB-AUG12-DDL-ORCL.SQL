=============start========avinash===============07-1ug-2012=============================
CREATE OR REPLACE PACKAGE HT18JULY.Cir_Dynamic_DML IS
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


CREATE OR REPLACE PACKAGE BODY HT18JULY.Cir_Dynamic_DML IS
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
    vcol_name     varchar2(400);
    vno         number(5);
    vrec         varchar2(4000);
    vrec_upd     varchar2(4000);
    vformat     varchar2(20);
    v_col_exists number(5);
Begin
    --insert into test1(vstring) values (pcolname||'33333'||pcolvalue);commit;
    dbg('vrec:');
   -- delete from
   -- insert into searchtbl(search) values ('neha');commit;

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

      --  insert into searchtbl(search) values ('neha_1');commit;
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
       --  insert into searchtbl(search) values ('neha_2');commit;
        vrec:='insert into '||ptable_name||'('||replace(pcolname,pdelimiter,',')||') values ( ';

       -- insert into searchtbl(search) values (vrec);commit;

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
--insert into searchtbl values('tblname-'|| ptable_name||'colname-'|| pcolname||'colvalue-'|| pcolvalue|| 'condname-' || pcond_colname|| 'delimeter-'|| pdelimiter || 'dateformat-'|| pdateformat || 'pextra1-'||pextra1||'pextra2-'|| pextra2);commit;






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
delete from temp_col_ins where session_id=userenv('sessionid');
	 insert into temp_col_ins1 (sqno,col_name,upd_str,session_id) values (9999,'',sysdate||pcond_colname||'#'||pcond_colval||'#'||vrec,userenv('sessionid'));
    Begin
		--delete from temp_col_ins where session_id=userenv('sessionid');
       -- delete from temp_col_ins1 where session_id=userenv('sessionid');
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
    --delete from searchtbl;
   -- insert into searchtbl values(pextra1);commit;
    
    if pextra1 is not null then
       vrec:=vrec||' order by '||pextra1;
       insert into temp_col_ins1 (sqno,col_name,upd_str,session_id) values (1234,'',pcond_colname||'#'||pcond_colval||'#'||vrec,userenv('sessionid'));
    else
       vrec:=vrec||' order by rowid ';
    end if;
   -- insert into searchtbl values(vrec);commit;
    
   -- insert into temp_col_ins1 values (vrec);
   delete from searchtbl;
   insert into searchtbl(search,search1,search2) values(vrec,'','');commit;
    insert into temp_col_ins1 (sqno,col_name,upd_str,session_id) values (9999,'',pcond_colname||'#'||pcond_colval||'#'||vrec,userenv('sessionid'));
	open p_accounts for vrec;
	delete from temp_col_ins where session_id=userenv('sessionid');
   -- delete from temp_col_ins1 where session_id=userenv('sessionid');
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






=============end========avinash===============07-1ug-2012=============================
CREATE OR REPLACE procedure rpt_ratecard(
    pfromdate        in varchar2,
    pdateto          in varchar2,
    padtyp           in varchar2,
    padcatg          in varchar2,
    ppackagecode     in varchar2,
    pcenter          in varchar2,
    pratecode        in varchar2,
    pcompcode        in varchar2,
    p_uom            in varchar2,
    dateformat       in varchar2,
    puserid          in varchar2:=null,
    extra1           in varchar2,
    extra2           in varchar2,
    extra3           in varchar2,
    extra4           in varchar2,
    extra5           in varchar2,
    p_accounts      OUT Cur_Type_New1.cursor_type
    ) IS

query1      VARCHAR2(20000);
Begin

query1:='select distinct r."Comp_code" as "COMP_CODE",r."Rate_Mast_Code" as "RATECODE",u."Uom_Name" as "UOM",
    (select "Pub_Cent_name" from pub_cent_mast where pub_cent_mast."Comp_Code" = r."Comp_code" and pub_cent_mast."Pub_cent_Code" =r."pub_center" ) as "Pub_Cent_name",
    (select "Adv_Cat_Name" from adv_cat_mast where adv_cat_mast."Comp_Code"= r."Comp_code" and adv_cat_mast."Adv_Cat_Code"=r."Adv_Cat_Code") as "Adv_Cat_Name",
    (select "Adv_Subcat_Name" from adv_subcat_mast where adv_subcat_mast."Comp_Code" = r."Comp_code" and adv_subcat_mast."Adv_Subcat_Code" =r."Adv_subcat_code" ) as "Adv_Subcat_Name",
    (select "Package_Name" from combin_mast where combin_mast."Comp_Code" = r."Comp_code" and combin_mast."Combin_Code" =r."Combin_Code" ) as "PACKAGE",
    (select "Scheme_Name" from scheme_master where scheme_master."Comp_code" = r."Comp_code" and scheme_master."Scheme_Code" =r."Scheme_Name" ) as "Scheme_Name",
    (select initcap("Comp_Name") from comp_mst where comp_mst."Comp_Code"='''||pcompcode||''') as "COMP_NAME",
    r."Size_From" as "Size_From",r."Size_To" as "Size_To",r."Max_Area" as "MaxSize",
    case '''||dateformat||'''
    when ''mm/dd/yyyy'' then to_char(r."Valid_From" ,''MM-DD-YY'')
    when ''dd/mm/yyyy'' then to_char(r."Valid_From",''DD-MM-YY'')
    when ''yyyy/mm/dd'' then to_char(r."Valid_From",''YY-MM-DD'') end
    as "Valid_From" ,
     case '''||dateformat||'''
    when ''mm/dd/yyyy'' then to_char(r."Valid_To" ,''MM-DD-YY'')
    when ''dd/mm/yyyy'' then to_char(r."Valid_To",''DD-MM-YY'')
    when ''yyyy/mm/dd'' then to_char(r."Valid_To",''YY-MM-DD'') end
    as "Valid_To" ,
    c."Col_Name",r."Week_Day_Rate",r."Week_Extra_Rate"
    from rate_mast r,col_mast c,uom_mast u
    where r."Comp_code"='''||pcompcode||''' and r."Comp_code"= c."Comp_Code" and r."Comp_code"=u."Comp_Code"
    and r."Color"=c."Col_Code" and r."Uom"=u."Uom_Code"
    and '''||pfromdate||''' between r."Valid_From" and r."Valid_To"
    and '''||pdateto||''' between r."Valid_From" and r."Valid_To"';


    IF(padtyp IS NOT NULL )THEN
        query1:=query1||' AND r."Adv_Type_Code" ='''||padtyp||'''';
    END IF;

    IF(padcatg IS NOT NULL) THEN
        query1:=query1|| ' AND r."Adv_Cat_Code" in ('''||padcatg||''' )';
    END IF;

    IF(ppackagecode IS NOT NULL ) THEN
        query1:=query1||' AND r."Combin_Code" in ('''||ppackagecode||''' )';
    END IF;

    IF(pcenter IS NOT NULL )THEN
        query1:=query1||' AND r."pub_center" ='''||pcenter||'''';
    END IF;

    IF(pratecode IS NOT NULL) THEN
        query1:=query1|| ' AND r."Rate_Mast_Code" ='''||pratecode||''' ';
    END IF;

    IF(p_uom IS NOT NULL) THEN
        query1:=query1|| ' AND r."Uom" ='''||p_uom||''' ';
    END IF;


    query1:=query1|| ' order by "RATECODE","Adv_Cat_Name"';


    --query2:=query2||' AND m."cio_booking_id" not in(select distinct "Cio_Booking_Id" from tbl_booking_mast m,tbl_booking_insert i
    --where m."cio_booking_id"=i."Cio_Booking_Id" and "Insert_Date"<''1-may-2012'' and m."Uom_code"=''RO0'') ' ;

    delete from searchtbl;insert into searchtbl values(query1,'',''); commit;

    OPEN p_accounts FOR query1;

End rpt_ratecard;
/

=============start========avinash===by jaipur============08-1ug-2012=============================



=============end========avinash======by jaipur=========08-1ug-2012=============================


=============start===8199=====avinash===============20-aug-2012=============================
CREATE OR REPLACE PROCEDURE HT18JULY.completereport(
    p_compcode      IN VARCHAR2:= NULL,
    p_fromdate      IN VARCHAR2:= NULL,
    p_dateto        IN VARCHAR2:= NULL,
    p_dateformat    IN VARCHAR2:= NULL,
    p_publication   IN VARCHAR2:= NULL,
    p_pub_cent      IN VARCHAR2:= NULL,
    p_edition       IN VARCHAR2:= NULL,
    p_suppliment    IN VARCHAR2:= NULL,
    p_zone          IN VARCHAR2:= NULL,
    p_branch        IN VARCHAR2:= NULL,
    p_district      IN VARCHAR2:= NULL,
    p_region        IN VARCHAR2:= NULL,
    p_city          IN VARCHAR2:= NULL,
    p_revcenter     IN VARCHAR2:= NULL,
    p_adtype        IN VARCHAR2:= NULL,
    p_agencytype    IN VARCHAR2:= NULL,
    p_ratetype      IN VARCHAR2:= NULL,
    p_adcat         IN VARCHAR2:= NULL,
    p_adsubcat      IN VARCHAR2:= NULL,
    p_adsubcat3     IN VARCHAR2:= NULL,
    p_adsubcat4     IN VARCHAR2:= NULL,
    p_adsubcat5     IN VARCHAR2:= NULL,
    p_package       IN VARCHAR2:= NULL,
    p_scheme        IN VARCHAR2:= NULL,
    p_agency        IN VARCHAR2:= NULL,
    p_client        IN VARCHAR2:= NULL,
    p_executive     IN VARCHAR2:= NULL,
    p_retainer      IN VARCHAR2:= NULL,
    p_product       IN VARCHAR2:= NULL,
    p_brand         IN VARCHAR2:= NULL,
    p_varient       IN VARCHAR2:= NULL,
    p_pagetype      IN VARCHAR2:= NULL,
    p_pageprem      IN VARCHAR2:= NULL,
    p_postprem      IN VARCHAR2:= NULL,
    p_rostatus      IN VARCHAR2:= NULL,
    p_booktype      IN VARCHAR2:= NULL,
    p_contractname  IN varchar2:= NULL,
    p_filterby      IN varchar2:= NULL,
    p_adcheck       in varchar2:=null,
    p_state         in varchar2:=null,
    p_taluka        in varchar2:=null,
    p_base          in varchar2:=null,
    p_drpstatus     in varchar2:=null,
    p_chkdetail     in varchar2:=null,
    p_insertstatus  in varchar2:=null,
    p_puserid       in varchar2:=null,
    p_baxcode       in varchar2:=null, 
    p_chk_access    in varchar2:=null,
    p_recordset1    OUT Cur_Type_New1.cursor_type,
    p_accounts      OUT Cur_Type_New1.cursor_type)

IS
query1          VARCHAR2(20000);
v_val           number(5);
query2          VARCHAR2(20000);
query3          VARCHAR2(20000);


bookdate        varchar2(50);
noinsert        varchar2(50);
Paidinsert      varchar2(50);
Area            varchar2(50);
Pagepremium     varchar2(50);
cardamt         varchar2(50);
Deviationamt    varchar2(50);
Deviationper    varchar2(50);
aggamt          varchar2(50);
DiscAmt         varchar2(50);
Discper         varchar2(50);
posamt          varchar2(50);
posper          varchar2(50);
Spdiscamt       varchar2(50);
Spdiscper       varchar2(50);
Spacedisc       varchar2(50);
Spacediscper    varchar2(50);
Specialcharge   varchar2(50);
AgencyAddlTDper varchar2(50);
AgencyAddlTDAmt varchar2(50);
Grossamt        varchar2(50);
RetTDper        varchar2(50);
RetTDAmt        varchar2(50);
AgencyTDper     varchar2(50);
AgencyTDAmt     varchar2(50);
Billamt         varchar2(50);
RetCommper      varchar2(50);
RetCommAmt      varchar2(50);
ActualBusines   varchar2(50);



Cursor C1 Is
SELECT /*+ index(TBL_BOOKING_MAST IND_TBL_BOOKING_MAST) index(TBL_BOOKING_INSERT  INSERT_I) */  distinct m."cio_booking_id" AS "CIOID",
m."Package_code" as package_code,m."Gross_amount" as Crate,'1' as chk_var
FROM TBL_BOOKING_MAST m, TBL_BOOKING_INSERT i,agency_mast a
WHERE m."Comp_code"=p_compcode and m."Comp_code"=a."Comp_Code"
AND m."cio_booking_id"=i."Cio_Booking_Id"
AND ((m."Insertion_date" BETWEEN p_fromdate AND p_dateto and p_filterby='Publish Date') or (m."date_time" BETWEEN p_fromdate AND p_dateto and p_filterby='Booking Date'))
AND i."Publication_Code"=nvl(p_publication,i."Publication_Code")
--old version
--and m."branch" IN (SELECT "Branch_Name" FROM BRANCH_MST WHERE m."branch"="Branch_Name" and "pub_center" in (SELECT "Pub_cent_Code" FROM PUB_CENT_MAST WHERE  branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" and "Pub_cent_Code"=p_pub_cent or p_pub_cent is null))
and m."branch" IN (SELECT "Branch_Code" FROM BRANCH_MST WHERE m."branch"="Branch_Code" and "pub_center"=nvl(p_pub_cent,"pub_center"))
and m."branch" =nvl(p_branch,m."branch")

AND m."Ad_type_code"=nvl(p_adtype,m."Ad_type_code")
AND i."Ad_Cat"=nvl(p_adcat,i."Ad_Cat")
AND i."Edition_Code"=nvl(p_edition,i."Edition_Code")
and m."Agency_sub_code"= a."code_subcode" 
and (a."region" =p_region  or p_region is null)
and (m."Revenue_center" =p_revcenter or p_revcenter is null)
and (m."Agency_type" =p_agencytype or p_agencytype is null)
and (i."Ad_Sub_Cat" =p_adsubcat or p_adsubcat is null)
and (i."AD_SUBCAT3" =p_adsubcat3 or p_adsubcat3 is null)
and (i."AD_SUBCAT4" =p_adsubcat4 or p_adsubcat4 is null)
and (i."AD_SUBCAT5" =p_adsubcat5 or p_adsubcat5 is null)
and (m."Package_code" =p_package or p_package is null)
and (m."Scheme_type_code" =p_scheme or p_scheme is null)
and a."Agency_Code" =nvl(p_agency,a."Agency_Code")
and (m."Client_code" =p_client or p_client is null)
and (m."Executive_code" =p_executive or p_executive is null)
and (m.RETAINER =p_retainer or p_retainer is null)
and (m."Product_code" =p_product  or p_product is null)
and (m."Brand_code" =p_brand or p_brand is null)
and (m."Variant_code" =p_varient or p_varient is null)
and (m."Page_type_code" =p_pagetype or p_pagetype is null)
and (m."Page_prem" =p_pageprem or p_pageprem is null)
and (m."Page_position_code" =p_postprem or p_postprem is null)
and (m."ro_status" =p_rostatus or p_rostatus is null)
and (m."Booking_type" =p_booktype or p_booktype is null)
and (m."Contract_name" =p_contractname or p_contractname is null)
and (i."Supp_Code" =p_suppliment or p_suppliment is null)
and (m."Rate_code" =p_ratetype or p_ratetype is null)

and ((p_base='1' and a."City_Code" =p_city or p_city is null)
or (p_base='2' and m."Executive_code"  in(select exec_mast."Exe_no" from exec_mast where exec_mast."city_code" =p_city or p_city is null))
or (p_base='3' and m.RETAINER in(select RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  RETAINERMASTER."City_Code"=p_city or p_city is null)))

and ((p_base='1' and a."zone_code" =p_zone or p_zone is null)
or (p_base='2' and m."Executive_code"  in(select exec_mast."Exe_no" from exec_mast where exec_mast."city_code" in (select city_mst."City_Code" from city_mst where city_mst."Zone_Code"= p_zone or p_zone is null) ))
or (p_base='3' and m.RETAINER in(select RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  RETAINERMASTER."Zone_Code"=p_zone or p_zone is null)))

and ((p_base='1' and a."Dist_Code" =p_district or p_district is null)
or (p_base='2' and m."Executive_code"  in(select exec_mast."Exe_no" from exec_mast where exec_mast."dist_code"= p_district or p_district is null ))
or (p_base='3' and m.RETAINER in(select RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  RETAINERMASTER."Dist_Code"=p_district or p_district is null)))

and ((p_base='1' and a."State_Code" =p_state or p_state is null)
or (p_base='2' and m."Executive_code"  in(select exec_mast."Exe_no" from exec_mast where exec_mast."State_code"= p_state or p_state is null ))
or (p_base='3' and m.RETAINER in(select RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  RETAINERMASTER."State_Code"=p_state or p_state is null)))

and ((p_base='1' and a.TALUKA=p_taluka or p_taluka is null)
or (p_base='2' and m."Executive_code"  in(select exec_mast."Exe_no" from exec_mast where exec_mast.TALUKA= p_taluka or p_taluka is null ))
or (p_base='3' and m.RETAINER in(select RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  RETAINERMASTER.TALUKA=p_taluka or p_taluka is null)))

and ((p_base='1' and m."Agency_sub_code" IS NOT NULL AND m."Agency_sub_code"!='0')
or (p_base='2' and m."Executive_code"    is not null and m."Executive_code" !='0' )
or (p_base='3' and m.RETAINER is not null  and m.RETAINER !='0'))

and ((p_drpstatus is  not null and  i."Insert_Status"!='XYZ') or 
(p_drpstatus is  null and  lower(i."Insert_Status")!='cancel'))
and (lower(i."Insert_Status")=p_insertstatus or p_insertstatus is null)

and ((i."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=p_puserid) and p_chk_access=1)
or  (p_chk_access=0) )
and p_adcheck='1'

union

SELECT /*+ index(TBL_BOOKING_MAST IND_TBL_BOOKING_MAST) index(TBL_BOOKING_INSERT  INSERT_I) */ distinct m."cio_booking_id" AS "CIOID",
m."Package_code" as package_code,i."Gross_Rate" as Crate,'1' as chk_var
FROM TBL_BOOKING_MAST m, TBL_BOOKING_INSERT i,AGENCY_MAST a
WHERE m."Comp_code"=p_compcode
AND m."Comp_code"=i."Comp_Code" AND m."Comp_code"=a."Comp_Code"
AND m."cio_booking_id"=i."Cio_Booking_Id"
AND (i."Insert_Date" BETWEEN p_fromdate AND p_dateto )
AND (i."Publication_Code"=p_publication or p_publication is null)
--old version

--and m."branch" IN (SELECT "Branch_Name" FROM BRANCH_MST WHERE m."branch"="Branch_Name" and "pub_center" in (SELECT "Pub_cent_Code" FROM PUB_CENT_MAST WHERE  branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" and "Pub_cent_Code"=p_pub_cent or p_pub_cent is null))
and m."branch" IN (SELECT "Branch_Code" FROM BRANCH_MST WHERE m."branch"="Branch_Code" and "pub_center" =nvl(p_pub_cent,"pub_center"))
and m."branch" =nvl(p_branch,m."branch")

AND m."Ad_type_code"=nvl(p_adtype,m."Ad_type_code")
AND i."Ad_Cat" =nvl(p_adcat,i."Ad_Cat")
AND i."Edition_Code"=nvl(p_edition,i."Edition_Code")
and m."Agency_sub_code"  =a."code_subcode" 
and (a."region" =p_region  or p_region is null)
and (m."Revenue_center" =p_revcenter or p_revcenter is null)
and (m."Agency_type" =p_agencytype or p_agencytype is null)
and (m."Ad_sub_cat_code" =p_adsubcat or p_adsubcat is null)
and (i."AD_SUBCAT3" =p_adsubcat3 or p_adsubcat3 is null)
and (i."AD_SUBCAT4" =p_adsubcat4 or p_adsubcat4 is null)
and (i."AD_SUBCAT5" =p_adsubcat5 or p_adsubcat5 is null)
and (m."Package_code" =p_package or p_package is null)
and (m."Scheme_type_code" =p_scheme or p_scheme is null)
and a."Agency_Code" =nvl(p_agency,a."Agency_Code")
and (m."Client_code" =p_client or p_client is null)
and (m."Executive_code" =p_executive or p_executive is null)
and (m.RETAINER =p_retainer or p_retainer is null)
and (m."Product_code" =p_product  or p_product is null)
and (m."Brand_code" =p_brand or p_brand is null)
and (m."Variant_code" =p_varient or p_varient is null)
and (m."Page_type_code" =p_pagetype or p_pagetype is null)
and (i."Premium1"  =p_pageprem or p_pageprem is null)
and (i."Page_Post" =p_postprem or p_postprem is null)
and (m."ro_status" =p_rostatus or p_rostatus is null)
and (m."Booking_type" =p_booktype or p_booktype is null)
and (m."Contract_name" =p_contractname or p_contractname is null)
and (i."Supp_Code" =p_suppliment or p_suppliment is null)
and (m."Rate_code" =p_ratetype or p_ratetype is null)
and ((p_base='1' and a."City_Code" =p_city or p_city is null)
or (p_base='2' and m."Executive_code"  in(select exec_mast."Exe_no" from exec_mast where exec_mast."city_code" =p_city or p_city is null))
or (p_base='3' and m.RETAINER in(select RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  RETAINERMASTER."City_Code"=p_city or p_city is null)))
and ((p_base='1' and a."zone_code" =p_zone or p_zone is null)
or (p_base='2' and m."Executive_code"  in(select exec_mast."Exe_no" from exec_mast where exec_mast."city_code" in (select /*+ index(city_mst ind_city_mst) */ city_mst."City_Code" from city_mst where city_mst."Zone_Code"= p_zone or p_zone is null)
))
or (p_base='3' and m.RETAINER in(select RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  RETAINERMASTER."Zone_Code"=p_zone or p_zone is null)))
and ((p_base='1' and a."Dist_Code" =p_district or p_district is null)
or (p_base='2' and m."Executive_code"  in(select exec_mast."Exe_no" from exec_mast where exec_mast."dist_code"= p_district or p_district is null ))
or (p_base='3' and m.RETAINER in(select RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  RETAINERMASTER."Dist_Code"=p_district or p_district is null)))
and ((p_base='1' and a."State_Code" =p_state or p_state is null)
or (p_base='2' and m."Executive_code"  in(select exec_mast."Exe_no" from exec_mast where exec_mast."State_code"= p_state or p_state is null ))
or (p_base='3' and m.RETAINER in(select RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  RETAINERMASTER."State_Code"=p_state or p_state is null)))
and ((p_base='1' and a.TALUKA=p_taluka or p_taluka is null)
or (p_base='2' and m."Executive_code"  in(select exec_mast."Exe_no" from exec_mast where exec_mast.TALUKA= p_taluka or p_taluka is null ))
or (p_base='3' and m.RETAINER in(select RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  RETAINERMASTER.TALUKA=p_taluka or p_taluka is null)))
and ((p_base='1' and m."Agency_sub_code" IS NOT NULL AND m."Agency_sub_code"!='0')
or (p_base='2' and m."Executive_code"    is not null and m."Executive_code" !='0' )
or (p_base='3' and m.RETAINER is not null  and m.RETAINER !='0'))
and ((p_drpstatus is  not null and i."Insert_Status"!='XYZ')
or (p_drpstatus is  null and  lower(i."Insert_Status")!='cancel'))
and (lower(i."Insert_Status")=p_insertstatus or p_insertstatus is null)

and ((i."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id=p_puserid) and p_chk_access=1)
or  (p_chk_access=0) )

and p_adcheck='3'

union

SELECT /*+ index (ad_bills_det ind1_ad_bills_det) */distinct bl."IDNUM" AS "CIOID",
bld.PACKAGE_CODE as package_code,bl.GROSS_AMT as Crate,'2' as chk_var
FROM ad_bills bl, ad_bills_det bld,agency_mast a,branch_mst b
WHERE bl.IDNUM=bld.IDNUM
AND bl.BILDT >= p_fromdate and bl.BILDT <= p_dateto
and (bl."PRIPUB"=p_publication  or p_publication is null)
and (bld."EDITION"=p_edition or p_edition is null)
and bl.AGCODE =a."code_subcode" and (a."region" =p_region  or p_region is null)
and (bld."AD_TYPE_V"=p_adtype or p_adtype is null)
and (a."Agency_Type_Code" =p_agencytype or p_agencytype is null)
and (bld.PRIADCTG =p_adcat or p_adcat is null)
and (bld.SECADCTG =p_adsubcat or p_adsubcat is null)
and (bld."AD_SUBCAT3"  =p_adsubcat3 or p_adsubcat3 is null)
and (bld.AD_SUBCAT4 =p_adsubcat4 or p_adsubcat4 is null)
and (bld.AD_SUBCAT5 =p_adsubcat5 or p_adsubcat5 is null)
and (bld.PACKAGE_CODE =p_package or p_package is null)
and (a."Agency_Code" =p_agency or p_agency is null)
and (bl."CLIENTCD"=p_client or p_client is null)
and (bl."EXECUTIVE_NAME"=p_executive or p_executive is null)
and (bl."PRIPROCTG"=p_product or p_product is null)
and ((bl."PRIPROCTG" in (select /*+ index(brand_mst brand_mst_pk)*/ brand_mst."prod_cat_code" from brand_mst where brand_mst."brand_code"=p_brand or p_brand is null)
and bl."PRIPROCTG" is not null)or (bl."PRIPROCTG" is null))
and ((bl."PRIPROCTG" in (select /*+ index(brand_mst brand_mst_pk)*/ brand_mst."prod_cat_code" from brand_mst where brand_mst."brand_code" in(select /*+ index(varient_mst ind_varient_mst) */ varient_mst."Brand_Code" from varient_mst where varient_mst."Varient_Name"=p_varient or p_varient is null))
and bl."PRIPROCTG" is not null) or (bl."PRIPROCTG" is null))
and (bld.PAGE_PREM =p_pageprem or p_pageprem is null)
and (bld.PAGE_POST =p_postprem or p_postprem is null)
and (bl.CONTRACT_NAME =p_contractname or p_contractname is null)
and (bld.SUPP_CODE =p_suppliment or p_suppliment is null)
and (bl.RETAINER_CODE =p_retainer or p_retainer is null)
and (bld.RATECD =p_ratetype or p_ratetype is null)
and bl.UNIT = b."Branch_Code" and b."Branch_Code" =nvl(p_branch,b."Branch_Code")
and (b."pub_center"=p_pub_cent or p_pub_cent is null)
and (bl.SCHEME=scheme or scheme is null)
and (bl.REVENUE_CENTER =p_revcenter or p_revcenter is null)
and (bl.RO_STATUS =p_rostatus or p_rostatus is null)
and (bl.PAGE_TYPE =p_pagetype or p_pagetype is null)
and (bl.BOOKING_TYPE =p_booktype or p_booktype is null)
 and (bl.SCHEME=p_scheme or p_scheme is null)
 and (bl.REVENUE_CENTER =p_revcenter or p_revcenter is null)
 and (bl.RO_STATUS =p_rostatus or p_rostatus is null)
 and (bl.PAGE_TYPE =p_pagetype or p_pagetype is null)
 and (bl.BOOKING_TYPE =p_booktype or p_booktype is null)
and ((p_base='1' and (a."City_Code" =p_city or p_city is null))
or (p_base='2' and bl.EXECUTIVE_NAME in(select exec_mast."Exe_no" from exec_mast where exec_mast."city_code" =p_city or p_city is null))
or (p_base='3' and bl.RETAINER_CODE in(select RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  RETAINERMASTER."City_Code"=p_city or p_city is null)))

and ((p_base='1' and (a."zone_code" =p_zone or p_zone is null))
or (p_base='2' and bl.EXECUTIVE_NAME in(select exec_mast."Exe_no" from exec_mast where exec_mast."city_code" in (select city_mst."City_Code" from city_mst where city_mst."Zone_Code"= p_zone or p_zone is null) ))
or (p_base='3' and bl.RETAINER_CODE in(select RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  RETAINERMASTER."Zone_Code"=p_zone or p_zone is null)))

and ((p_base='1' and (a."Dist_Code" =p_district or p_district is null))
or (p_base='2' and bl.EXECUTIVE_NAME in(select exec_mast."Exe_no" from exec_mast where exec_mast."dist_code"= p_district or p_district is null ))
or (p_base='3' and bl.RETAINER_CODE in(select RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  RETAINERMASTER."Dist_Code"=p_district or p_district is null)))

and ((p_base='1' and (a."State_Code" =p_state or p_state is null))
or (p_base='2' and bl.EXECUTIVE_NAME in(select exec_mast."Exe_no" from exec_mast where exec_mast."State_code"= p_state or p_state is null ))
or (p_base='3' and bl.RETAINER_CODE in(select RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  RETAINERMASTER."State_Code"=p_state or p_state is null)))

and ((p_base='1' and (a.TALUKA=p_taluka or p_taluka is null) )
or (p_base='2' and bl.EXECUTIVE_NAME   in(select exec_mast."Exe_no" from exec_mast where exec_mast.TALUKA= p_taluka or p_taluka is null ))
or (p_base='3' and bl.RETAINER_CODE  in(select RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  RETAINERMASTER.TALUKA=p_taluka or p_taluka is null)))

and ((p_base='1' and bl.AGCODE IS NOT NULL AND bl.AGCODE!='0')
or (p_base='2' and bl.EXECUTIVE_NAME   is not null and bl.EXECUTIVE_NAME !='0' )
or (p_base='3' and bl.RETAINER_CODE  is not null  and bl.RETAINER_CODE !='0'))

and ((bld."BKFOR" in (select distinct pub_center from login_center where newuser_id=p_puserid) and p_chk_access=1)
or  (p_chk_access=0) )

and p_adcheck='2';

v1 c1%rowtype;


---**************************************  For Billing Data*************************
Cursor C2 Is
SELECT distinct bl."IDNUM" AS "CIOID",bl.BILNO as "BILLNO" ,bl.ag_main_code as "AGMAINCODE",
bl.ag_sub_code as "AG_SUB_CODE",bl.agcode as "AGCODE",
a."Agency_Name" as "AGNAME",nvl(bl.executive_name,0) as "EXECCODE",
AD_GET_EXECNAME(bl.comp_code_v,bl.EXECUTIVE_NAME) as "EXECNAME",bl.RETAINER_CODE as "RETCODE",
AD_GET_RETAINER(bl.comp_code_v,bl.RETAINER_CODE) as "RETNAME"
FROM ad_bills bl ,AGENCY_MAST a,branch_mst b WHERE bl.comp_code_v=p_compcode
and bl.UNIT=b."Branch_Code" and b."Branch_Code" =nvl(p_branch,b."Branch_Code")
and bl.BILDT >= p_fromdate and bl.bildt <=p_dateto
and b."pub_center" =nvl(p_pub_cent,b."pub_center")
and bl.ag_main_code =a."Agency_Code" and bl.ag_sub_code =a."SUB_Agency_Code" and 
(a."region" =p_region  or p_region is null)
and a."Agency_Type_Code" =nvl(p_agencytype,a."Agency_Type_Code")
and (bl."PRIPUB"=p_publication  or p_publication is null)
and a."Agency_Code" =nvl(p_agency,a."Agency_Code")
and (bl."CLIENTCD"=p_client or p_client is null)
and (bl."EXECUTIVE_NAME"=p_executive or p_executive is null)
and (bl."PRIPROCTG"=p_product or p_product is null)
and ((bl."PRIPROCTG" in (select brand_mst."prod_cat_code" from brand_mst where brand_mst."brand_code"=p_brand or p_brand is null) 
and bl."PRIPROCTG" is not null)or (bl."PRIPROCTG" is null))
and ((bl."PRIPROCTG" in (select brand_mst."prod_cat_code" from brand_mst where brand_mst."brand_code" 
in(select varient_mst."Brand_Code" from varient_mst where varient_mst."Varient_Name"=p_varient or p_varient is null)) 
and bl."PRIPROCTG" is not null) or (bl."PRIPROCTG" is null))
and (bl.CONTRACT_NAME =p_contractname or p_contractname is null)
and (bl.RETAINER_CODE =p_retainer or p_retainer is null)
and (bl.SCHEME=p_scheme or p_scheme is null)
and (bl.REVENUE_CENTER =p_revcenter or p_revcenter is null)
and (bl.RO_STATUS =p_rostatus or p_rostatus is null)
and (bl.PAGE_TYPE =p_pagetype or p_pagetype is null)
and (bl.BOOKING_TYPE =p_booktype or p_booktype is null)
and ((p_base='1' and (a."City_Code" =p_city or p_city is null))
or (p_base='2' and bl.EXECUTIVE_NAME in(select exec_mast."Exe_no" from exec_mast where exec_mast."city_code" =p_city or p_city is null))
or (p_base='3' and bl.RETAINER_CODE in(select RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  RETAINERMASTER."City_Code"=p_city or p_city is null)))
and ((p_base='1' and (a."zone_code" =p_zone or p_zone is null))
or (p_base='2' and bl.EXECUTIVE_NAME in(select exec_mast."Exe_no" from exec_mast where exec_mast."city_code" in (select city_mst."City_Code" from city_mst where city_mst."Zone_Code"= p_zone or p_zone is null) ))
or (p_base='3' and bl.RETAINER_CODE in(select RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  RETAINERMASTER."Zone_Code"=p_zone or p_zone is null)))
and ((p_base='1' and (a."Dist_Code" =p_district or p_district is null))
or (p_base='2' and bl.EXECUTIVE_NAME in(select exec_mast."Exe_no" from exec_mast where exec_mast."dist_code"= p_district or p_district is null ))
or (p_base='3' and bl.RETAINER_CODE in(select RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  RETAINERMASTER."Dist_Code"=p_district or p_district is null)))
and ((p_base='1' and (a."State_Code" =p_state or p_state is null))
or (p_base='2' and bl.EXECUTIVE_NAME in(select exec_mast."Exe_no" from exec_mast where exec_mast."State_code"= p_state or p_state is null ))
or (p_base='3' and bl.RETAINER_CODE in(select RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  RETAINERMASTER."State_Code"=p_state or p_state is null)))
and ((p_base='1' and (a.TALUKA=p_taluka or p_taluka is null) )
or (p_base='2' and bl.EXECUTIVE_NAME   in(select exec_mast."Exe_no" from exec_mast where exec_mast.TALUKA= p_taluka or p_taluka is null ))
or (p_base='3' and bl.RETAINER_CODE  in(select RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  RETAINERMASTER.TALUKA=p_taluka or p_taluka is null)))
and ((p_base='1' and bl.AGCODE IS NOT NULL AND bl.AGCODE!='0')
or (p_base='2' and bl.EXECUTIVE_NAME   is not null and bl.EXECUTIVE_NAME !='0' )
or (p_base='3' and bl.RETAINER_CODE  is not null  and bl.RETAINER_CODE !='0'));

v2 C2%rowtype;

--**********************************************************************************

v_edition varchar2(100);
v_edipkg varchar2(500);
prefer   varchar2(10);

BEGIN
/*insert into dbgstr(rdate,str,seq) values(sysdate,'Start of Complete Report',dbg_seq.nextval);commit;
delete from searchtbl;
insert into searchtbl values('compcode-'||p_compcode||'fromdate-'||p_fromdate||'dateto-'||p_dateto||'dateformat-'||p_dateformat||'publication-'||p_publication
||'pub_cent-'||p_pub_cent||'edition-'||p_edition||'suppliment-'||p_suppliment||'zone-'||p_zone||'branch-'||p_branch||'district-'||p_district||'region-'||p_region||
'city-'||p_city||'revcenter-'||p_revcenter||'adtype-'||p_adtype||'agencytype-'||p_agencytype||'ratetype-'||p_ratetype||'adcat-'||p_adcat||'adsubcat-'||p_adsubcat||
'adsubcat3-'||p_adsubcat3||'adsubcat4-'||p_adsubcat4||'adsubcat5-'||p_adsubcat5||'package-'||p_package||'scheme-'||p_scheme||'agency-'||p_agency||'client-'||p_client||
'executive-'||p_executive||'retainer-'||p_retainer||'product-'||p_product||'brand-'||p_brand||'varient-'||p_varient||'pagetype-'||p_pagetype||'pageprem-'||p_pageprem||
'postprem-'||p_postprem||'rostatus-'||p_rostatus||'booktype-'||p_booktype||'contractname-'||p_contractname||'filterby-'||p_filterby||'adcheck-'||p_adcheck||'state-'||p_state||
'taluka-'||p_taluka||'base-'||p_base||'drpstatus-'||p_drpstatus||'chkdetail-'||p_chkdetail||'insertstatus-'||p_insertstatus||'puserid-'||p_puserid||'chk_access-'||p_chk_access);

commit;*/








select DISTINCT AGENCY_RETAINER_COMM into prefer from preferrences where "comp_code"=p_compcode;

delete from multipack_rep where sess_id=userenv('sessionid')  ;
delete from multipack_rat where sess_id=userenv('sessionid') ;
DELETE FROM multipack_ratnew where sess_id=userenv('sessionid')  ;

commit;
--insert into dbgstr(rdate,str,seq) values(sysdate,'Delete multipack tables',dbg_seq.nextval);commit;
open c1;
loop
fetch c1 into v1;
exit when c1%notfound;
    --insert into dbgstr(rdate,str,seq) values(sysdate,'Open C1',dbg_seq.nextval);commit;
    
     v_val:=multipack_report(v1.CIOID,v1.package_code,v1.Crate,v1.chk_var);
   -- insert into dbgstr(rdate,str,seq) values(sysdate,'Open C1 multipack_report',dbg_seq.nextval);commit;
    v_edition:=null;v_edipkg:=null;
end loop;
close c1;
--insert into dbgstr(rdate,str,seq) values(sysdate,'close C1',dbg_seq.nextval);commit;
commit;

if(p_chkdetail='Detail')then

if(p_adcheck=1)
then
query1:=query1||'SELECT distinct m."cio_booking_id" AS "CIOID",
to_char(m."date_time",'''||p_dateformat||''') as "BookDate",
a."Agency_Name" AS "Agency",
NVL((SELECT "Cust_Name" FROM CUST_MAST WHERE "Cust_Code"=m."Client_code"),m."Client_code")  AS "Client",
m."RO_No" AS "RoNo.",
CASE '''||p_dateformat||'''
WHEN ''mm/dd/yyyy'' THEN TO_CHAR(m."RO_Date",''mm/dd/yyyy'')
WHEN ''dd/mm/yyyy'' THEN TO_CHAR(m."RO_Date" ,''dd/mm/yyyy'')
WHEN ''yyyy/mm/dd'' THEN TO_CHAR(m."RO_Date",''yyyy/mm/dd'') END AS "Ro.Date",
(select EXEC_MAST."Exec_name" from exec_mast where m."Executive_code"=to_char(exec_mast."Exe_no")) AS "Executive",
(select RETAINERMASTER."Retain_Name"  FROM  RETAINERMASTER where RETAINERMASTER."Retain_Code"=m.RETAINER ) AS "Retainer",
decode(m."Booking_type",''1'',''Barter'',''2'',''FMG'',''3'',''Normal'',''4'',''InHouse'',''5'',''Complimentary'',''Normal'') as "BookType",
(select col_mast."Col_Alias" from col_mast where m."Color_code"=col_mast."Col_Code") as "Color",
adv_cat_mast."Adv_Cat_Name" as "Adcat",
(select adv_subcat_mast."Adv_Subcat_Name" from adv_subcat_mast where i."Ad_Sub_Cat"=adv_subcat_mast."Adv_Subcat_Code" and  adv_cat_mast."Adv_Cat_Code"=adv_subcat_mast."Adv_Cat_Code")as "Adsubcat",
(select ad_cat3."catname" from ad_cat3,adv_subcat_mast  where m."Ad_Subcat3"=ad_cat3."catcode" and ad_cat3."subcatname"=adv_subcat_mast."Adv_Subcat_Code" and i."Ad_Sub_Cat"=adv_subcat_mast."Adv_Subcat_Code" and  adv_cat_mast."Adv_Cat_Code"=adv_subcat_mast."Adv_Cat_Code") as "Adsubcat3",
(select tbl_cat4."Cat_Name" from tbl_cat4,adv_subcat_mast where i."AD_SUBCAT4"=tbl_cat4."Cat_Code" and tbl_cat4."Sub_Cat_Name"=adv_subcat_mast."Adv_Subcat_Code" and i."Ad_Sub_Cat"=adv_subcat_mast."Adv_Subcat_Code" and  adv_cat_mast."Adv_Cat_Code"=adv_subcat_mast."Adv_Cat_Code") as "Adsubcat4",
(select tbl_cat5."Cat_Name" from tbl_cat5,adv_subcat_mast where i."AD_SUBCAT5"=tbl_cat5."Cat_Code" and tbl_cat5."Sub_Cat_Name"=adv_subcat_mast."Adv_Subcat_Code" and i."Ad_Sub_Cat"=adv_subcat_mast."Adv_Subcat_Code" and  adv_cat_mast."Adv_Cat_Code"=adv_subcat_mast."Adv_Cat_Code") as "Adsubcat5",
--FETCH_PACK(m."cio_booking_id") AS "Package",
case when instr(m."Package_code",'','') >0 then
    FETCH_PACK_new(m."cio_booking_id", m."Package_code" ) 
else
(select distinct min("Combin_Desc") from combin_mast where "Combin_Code"=m."Package_code")
end AS "Package",   
to_char(m."Insertion_date",'''||p_dateformat||''') as "PubDate",
m."No_of_insertion" as "noinsert",
m."Paid_ins" as "Paidinsert",
m."Ad_size_height" as "height",
m."Ad_size_width" as "width",
m."Total_area" as "Area",
(select ADVPOS_PREM_MAST."premiumname" from advpos_prem_mast where m."Page_prem"=ADVPOS_PREM_MAST."Premiumcode") as "Pagepremium",
(select advpos_type_mast."Pos_Type" from advpos_type_mast where m."Page_position_code"=advpos_type_mast."Pos_Type_Code") as "Postprem",
(select scheme_master."Scheme_Name" from scheme_master where m."Scheme_type_code"=scheme_master."scheme_id") as "scheme",
m."Rate_code" as "Ratecode",
m."Card_rate" as "cardrate",
m."Card_amount" as "cardamt",
m."Contract_rate" as "contractrate",
m."Deviation" as "Deviationamt",
m."Deviation" AS "Deviation(%)",
m."Agrred_rate" as "Aggrate",
m."Agreed_amount" as "aggamt",
(m."Card_amount" - DECODE(NVL(m."Agreed_amount",0),0,m."Card_amount",m."Agreed_amount")) as "DiscAmt",
m."Discount_per" as "Discper",
(select SUM(nvl(RAT,0)) from multipack_rat where cioid=m."cio_booking_id"  and sess_id='||userenv('sessionid')||') as  "posamt",
(select SUM(nvl(PER_AMT,0)) from multipack_rat where cioid=m."cio_booking_id"   and sess_id='||userenv('sessionid')||') as "pos(%)",
round(((m."Special_disc_per" * m."Total_area" * m."Card_rate")/100),2) as "Spdiscamt",
m."Special_disc_per" as "Spdiscper",
round(((m."Space_disc_per" * m."Total_area" * m."Card_rate")/100),2) as "Spacedisc",
m."Space_disc_per" as "Spacediscper",
m."Special_charges" as "Specialcharge",
nvl(m."ADD_AGENCY_COMM",''0'') as "AgencyAddlTD(%)",
nvl((nvl(m."Gross_amount",''0'')*nvl(m."ADD_AGENCY_COMM",''0'')/100),''0'') as "AgencyAddlTDAmt",
nvl(m."Gross_amount",''0'') as "Grossamt",
(select DISTINCT TO_NUMBER(NVL("Comm_Rate",''0''))    from RET_COMM_DETAILS WHERE "Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(m."RETAINER",''0'') AND "Eff_from_Date"=(SELECT MAX("Eff_from_Date") FROM RET_COMM_DETAILS WHERE "Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(m."RETAINER",''0'')) AND ROWNUM<=1 ) as "RetTD(%)",
nvl(m."Gross_amount",''0'')*(select DISTINCT TO_NUMBER(NVL("Comm_Rate",''0''))    from RET_COMM_DETAILS WHERE "Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(m."RETAINER",''0'') AND "Eff_from_Date"=(SELECT MAX("Eff_from_Date") FROM RET_COMM_DETAILS WHERE "Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(m."RETAINER",''0'')) AND ROWNUM<=1 )/100 as "RetTDAmt",
nvl(m."Trade_disc",''0'' )as "AgencyTD(%)",
(nvl(m."Gross_amount",''0'')* nvl(m."Trade_disc",''0'' )/100 )as "AgencyTDAmt",
nvl(m."Bill_amount",''0'') as "Billamt",
nvl(case( '''||prefer||''' )
    when ''Y'' then
        ( CASE (select DISTINCT "Discount" from RET_COMM_DETAILS WHERE "Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(m."RETAINER",''0'') AND "Eff_from_Date"=(SELECT MAX("Eff_from_Date") FROM RET_COMM_DETAILS WHERE "Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(m."RETAINER",''0'')) AND ROWNUM<=1)
         when ''Gross'' then
                (
                 CASE to_number(nvl(m.RETAINER_COMM,0))
                 WHEN 0 THEN 0
                 ELSE (to_number(nvl(m.RETAINER_COMM,''0''))-to_number(nvl(m."ADD_AGENCY_COMM",''0'' )))
                 end )
         when ''Net''   then  to_number(nvl(m.RETAINER_COMM,''0''))
        END )

    ELSE (select 0  from dual)
end  ,''0'') as "RetComm(%)",
nvl(
case( '''||prefer||''' )
    when ''Y'' then
        ( CASE (select DISTINCT "Discount" from RET_COMM_DETAILS WHERE "Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(m."RETAINER",''0'') AND "Eff_from_Date"=(SELECT MAX("Eff_from_Date") FROM RET_COMM_DETAILS WHERE "Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(m."RETAINER",''0'')) AND ROWNUM<=1)
         when ''Gross'' then
                 (
                 CASE to_number(nvl(m.RETAINER_COMM_AMT,0))
                 WHEN 0 THEN 0
                 ELSE (to_number(nvl(m.RETAINER_COMM_AMT,''0''))-(nvl((nvl(m."Gross_amount",''0'')*to_number(nvl(m."ADD_AGENCY_COMM",''0''))/100),''0'')))
                 end )


         when ''Net''   then  (nvl(m."Gross_amount",''0'')*(to_number(nvl(m.RETAINER_COMM,''0'')) )/100)
        END )

    ELSE (select 0  from dual)
end
,''0'') as "RetCommAmt",
minus_to_zero(nvl((  NVL(m."Bill_amount",''0'')-
nvl(
case( '''||prefer||''' )
    when ''Y'' then
        ( CASE (select DISTINCT "Discount" from RET_COMM_DETAILS WHERE "Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(m."RETAINER",''0'') AND "Eff_from_Date"=(SELECT MAX("Eff_from_Date") FROM RET_COMM_DETAILS WHERE "Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(m."RETAINER",''0'')) AND ROWNUM<=1)
         when ''Gross'' then

                 (
                 CASE to_number(nvl(m.RETAINER_COMM_AMT,0))
                 WHEN 0 THEN 0
                 ELSE (to_number(nvl(m.RETAINER_COMM_AMT,''0''))-(nvl((nvl(m."Gross_amount",''0'')*to_number(nvl(m."ADD_AGENCY_COMM",''0''))/100),''0'')))
                 end )


         when ''Net''   then  (nvl(m."Gross_amount",''0'')*(to_number(nvl(m.RETAINER_COMM,''0'')) )/100)
         else  (nvl(m."Gross_amount",''0'')*(to_number(nvl(m."ADD_AGENCY_COMM",''0'')) )/100)  
        END )

    ELSE (select 0  from dual)
end
,''0'') ),''0'')) as "ActualBusiness",

(SELECT BRANCH_MST."Branch_Name" FROM BRANCH_MST WHERE m."Revenue_center"=BRANCH_MST."Branch_Code" )as "Revcenter",
UOM_MAST."Uom_Name"  AS "Uom",
uom_mast.UOM_DESC as "uomdesc"
,(select pub_cent_mast."Pub_Cent_name" from pub_cent_mast where pub_cent_mast."Pub_cent_Code" in(select "pub_center" from  BRANCH_MST WHERE m."branch"="Branch_Code") ) as "Printcenter"
,(SELECT "Branch_Name" FROM BRANCH_MST where  m."branch" = "Branch_Code") as "Branch"


,case '''||p_base||'''
when ''1'' then  a."Dist_Code"
when ''2'' then (select dist_mst."Dist_Name" from dist_mst where dist_mst."Dist_Code" in(select exec_mast."dist_code" from exec_mast where  to_char(exec_mast."Exe_no")=m."Executive_code" )  )
when ''3'' then (select dist_mst."Dist_Name" from dist_mst where dist_mst."Dist_Code" in(select RETAINERMASTER."Dist_Code" from RETAINERMASTER where  RETAINERMASTER."Retain_Code"= m.RETAINER )  ) end as "District"
,case '''||p_base||'''
when ''1'' then (select taluka_mast.TALU_NAME  from taluka_mast where a.TALUKA=taluka_mast.TALU_CODE )
when ''2'' then (select taluka_mast.TALU_NAME  from taluka_mast where taluka_mast.TALU_CODE in(select exec_mast.TALUKA from exec_mast where  to_char(exec_mast."Exe_no")=m."Executive_code" )  )
when ''3'' then (select taluka_mast.TALU_NAME  from taluka_mast where taluka_mast.TALU_CODE in(select RETAINERMASTER.TALUKA from RETAINERMASTER where  RETAINERMASTER."Retain_Code"= m.RETAINER )  ) end as "Taluka"
,nvl(m."Page_no",0) as "Page_No"
,m.CASHDISCOUNT as "Cash_Disc"
,m."Box_code" as "BoxCode",m."Userid" as USERID,
(SELECT max("username") from login where com_code = m."Comp_code" and "userid"=m."Userid") as USERNAME,
m."Bill_remarks" as "BillRemark",m."Caption" as "CAPTION",
nvl((SELECT nvl(("Varient_Alias"),'''') FROM varient_mst where "Varient_Code"=m."Variant_code"),'''') as "VARIENT",
nvl((SELECT "Product_Name" FROM PRODUCT_MAST where "Product_Code"=m."Product_code" and "Comp_Code"=m."Comp_code"),'''') as PRODUCT,
nvl((SELECT "brand_alias" FROM brand_mst where "brand_code"=M."Brand_code"),'''') as BRAND
FROM TBL_BOOKING_MAST m,AGENCY_MAST a ,UOM_MAST,
adv_cat_mast,
adv_type_mast,
TBL_BOOKING_insert i
WHERE m."Comp_code"='''||p_compcode||''' AND
m."cio_booking_id"=i."Cio_Booking_Id" AND
UOM_MAST."Uom_Code"=m."Uom_code" and
m."Agency_sub_code"=a."Agency_Code"||a."SUB_Agency_Code" AND
i."Ad_Cat"=adv_cat_mast."Adv_Cat_Code" and
m."Ad_type_code"=adv_type_mast."Adv_Type_Code"
and adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
((i."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id='''||p_puserid||''') and '''||p_chk_access||'''=''1'')
or  ('''||p_chk_access||'''=''0'') )' ;


if(p_base='2')then
query1:=query1||' and (m."Executive_code" is not null and m."Executive_code" !=''0'')  ';
end if;

if(p_base='3')then
query1:=query1||' and (m.RETAINER is not null  and m.RETAINER !=''0'')  ';
end if;


if(p_drpstatus is null) then
query1:=query1||' and lower(i."Insert_Status")!='''||'cancel'||'''';
end if;

if(p_insertstatus is not null) then
query1:=query1||' and lower(i."Insert_Status")='''||p_insertstatus||'''';
end if;

IF(p_fromdate IS NOT NULL AND p_dateto IS NULL  and  p_filterby='Booking Date')
THEN
query1:=query1||' and m."date_time" ='''||p_fromdate||'''';
END IF;

IF(p_fromdate IS NOT NULL AND p_dateto IS NOT NULL and p_filterby='Booking Date' )
THEN
query1:=query1||' and m."date_time" between  '''||p_fromdate ||''' and  '''||p_dateto||''' ';
END IF;

IF(p_fromdate IS NOT NULL AND p_dateto IS NULL  and  p_filterby='Publish Date')
THEN
--query1:=query1||' and m."Insertion_date" ='''||p_fromdate||'''';
query1:=query1||' and i."Insert_Date" ='''||p_fromdate||'''';
END IF;

IF(p_fromdate IS NOT NULL AND p_dateto IS NOT NULL and p_filterby='Publish Date' )
THEN
--query1:=query1||' and m."Insertion_date"  between  '''||p_fromdate ||''' and  '''||p_dateto||''' ';
query1:=query1||' and i."Insert_Date"  between  '''||p_fromdate ||''' and  '''||p_dateto||''' ';
END IF;

IF(p_publication IS NOT NULL)
THEN
query1:=query1||' and i."Publication_Code"='''||p_publication||'''    ';
END IF;

IF(p_pub_cent IS NOT NULL)
THEN
query1:=query1||'  and m."branch" IN (SELECT "Branch_Code" FROM BRANCH_MST WHERE m."branch"="Branch_Code" and "pub_center" ='''||p_pub_cent||''')';
END IF;


IF(p_branch IS NOT NULL)
THEN
query1:=query1||'  and m."branch" ='''||p_branch||'''';
END IF;


IF(p_edition IS NOT NULL)
THEN
query1:=query1||'  and i."Edition_Code"='''||p_edition||'''';
END IF;

IF(p_region IS NOT NULL)
THEN
query1:=query1 ||' and a."region" ='''||p_region ||''' ';
END IF;

IF(p_revcenter IS NOT NULL)
THEN
query1:=query1 ||' and m."Revenue_center" ='''||p_revcenter||'''';
END IF;

IF(p_adtype IS NOT NULL)
THEN
query1:=query1 || ' and m."Ad_type_code"='''||p_adtype||'''';
END IF;

IF(p_agencytype IS NOT NULL)
THEN
query1:=query1 || ' and m."Agency_type" ='''||p_agencytype||'''';
END IF;

IF(p_adcat IS NOT NULL)
THEN
query1:=query1 || ' and i."Ad_Cat" ='''||p_adcat||'''';
END IF;

IF(p_adsubcat IS NOT NULL)
THEN
query1:=query1 || ' and i."Ad_Sub_Cat" ='''||p_adsubcat||'''';
END IF;

IF(p_adsubcat3 IS NOT NULL)
THEN
query1:=query1 || ' and i."AD_SUBCAT3" ='''||p_adsubcat3||'''';
END IF;

IF(p_adsubcat4 IS NOT NULL)
THEN
query1:=query1 || ' and i."AD_SUBCAT4" ='''||p_adsubcat4||'''';
END IF;

IF(p_adsubcat5 IS NOT NULL)
THEN
query1:=query1 || ' and i."AD_SUBCAT5" ='''||p_adsubcat5||'''';
END IF;

IF(p_package IS NOT NULL)
THEN
query1:=query1 || ' and m."Package_code" ='''||p_package||'''';
END IF;

IF(p_scheme IS NOT NULL)
THEN
query1:=query1 || ' and m."Scheme_type_code" ='''||p_scheme||'''';
END IF;

IF(p_agency IS NOT NULL)
THEN
query1:=query1 || ' and m."Agency_code" ='''||p_agency||'''';
END IF;

IF(p_client IS NOT NULL)
THEN
query1:=query1 || ' and m."Client_code" ='''||p_client||'''';
END IF;

IF(p_executive IS NOT NULL)
THEN
query1:=query1 || ' and m."Executive_code" ='''||p_executive||'''';
END IF;

IF(p_retainer IS NOT NULL)
THEN
query1:=query1 || ' and m.RETAINER ='''||p_retainer||'''';
END IF;

IF(p_product IS NOT NULL)
THEN
query1:=query1 || ' and m."Product_code" ='''||p_product||'''';
END IF;

IF(p_brand IS NOT NULL)
THEN
query1:=query1 || ' and m."Brand_code" ='''||p_brand||'''';
END IF;

IF(p_varient IS NOT NULL)
THEN
query1:=query1 || ' and m."Variant_code" ='''||p_varient||'''';
END IF;

IF(p_pagetype IS NOT NULL)
THEN
query1:=query1 || ' and m."Page_type_code" ='''||p_pagetype||'''';
END IF;

IF(p_pageprem IS NOT NULL)
THEN
query1:=query1 || ' and m."Page_prem" ='''||p_pageprem||'''';
END IF;

IF(p_postprem IS NOT NULL)
THEN
query1:=query1 || ' and m."Page_position_code" ='''||p_postprem||'''';
END IF;

IF(p_rostatus IS NOT NULL)
THEN
query1:=query1 || ' and m."ro_status" ='''||p_rostatus||'''';
END IF;

IF(p_booktype IS NOT NULL)
THEN
query1:=query1 || ' and m."Booking_type" ='''||p_booktype||'''';
END IF;

IF(p_contractname  IS NOT NULL)
THEN
query1:=query1 || ' and m."Contract_name" ='''||p_contractname ||'''';
END IF;

IF(p_suppliment  IS NOT NULL)
THEN
query1:=query1 || ' and i."Supp_Code" ='''||p_suppliment||'''';
END IF;

IF(p_ratetype  IS NOT NULL)
THEN
query1:=query1 || ' and m."Rate_code" ='''||p_ratetype||'''';
END IF;

IF(p_city  IS NOT NULL)
THEN
if(p_base='1')then
query1:=query1 || ' and a."City_Code" ='''||p_city||'''';
end if;

if(p_base='2')then
query1:=query1 || ' and m."Executive_code" in(select exec_mast."Exe_no" from exec_mast where exec_mast."city_code" ='''||p_city||''' )';
end if;

if(p_base='3')then
query1:=query1 || ' and m.RETAINER in(select RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  RETAINERMASTER."City_Code"='''||p_city||''')';
end if;
END IF;

IF(p_zone  IS NOT NULL)
THEN
if(p_base='1')then
query1:=query1 || ' and a."zone_code" ='''||p_zone||'''';
end if;

if(p_base='2')then
query1:=query1 || ' and m."Executive_code" in(select exec_mast."Exe_no" from exec_mast where exec_mast."city_code" in (select city_mst."City_Code" from city_mst where city_mst."Zone_Code"= '''||p_zone||''') )';
end if;

if(p_base='3')then
query1:=query1 || ' and m.RETAINER in(select RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  RETAINERMASTER."Zone_Code"='''||p_zone||''')';
end if;
END IF;

IF(p_district  IS NOT NULL)
THEN
if(p_base='1')then
query1:=query1 || ' and a."Dist_Code" ='''||p_district||'''';
end if;

if(p_base='2')then
query1:=query1 || ' and m."Executive_code" in(select exec_mast."Exe_no" from exec_mast where exec_mast."dist_code" ='''||p_district||''' )';
end if;

if(p_base='3')then
query1:=query1 || ' and m.RETAINER in(select RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  RETAINERMASTER."Dist_Code"='''||p_district||''')';
end if;
END IF;

IF(p_state  IS NOT NULL)
THEN
if(p_base='1')then
query1:=query1 || ' and a."State_Code" ='''||p_state||'''';
end if;

if(p_base='2')then
query1:=query1 || ' and m."Executive_code" in(select exec_mast."Exe_no" from exec_mast where exec_mast."State_code" ='''||p_state||''' )';
end if;

if(p_base='3')then
query1:=query1 || ' and m.RETAINER in(select RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  RETAINERMASTER."State_Code"='''||p_state||''')';
end if;
END IF;

IF(p_taluka  IS NOT NULL)
THEN
if(p_base='1')then
query1:=query1 || ' and a.TALUKA='''||p_taluka||'''  ';
end if;

if(p_base='2')then
query1:=query1 || ' and m."Executive_code" in(select exec_mast."Exe_no" from exec_mast where exec_mast.TALUKA ='''||p_taluka||''' )';
end if;

if(p_base='3')then
query1:=query1 || ' and m.RETAINER in(select RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  RETAINERMASTER.TALUKA='''||p_taluka||''')';
end if;
END IF;

query1:=query1 || ' order by m."cio_booking_id"';

DELETE FROM searchtbl;
--insert into searchtbl values(query1);commit;
--insert into dbgstr(rdate,str,seq) values(sysdate,'OPEN p_recordset1 FOR '||query1,dbg_seq.nextval);commit;
OPEN p_recordset1 FOR
query1;


elsif(p_adcheck=2)then
delete from temp_ad_bills_report where sess_id=userenv('sessionid')  ;
--insert into dbgstr(rdate,str,seq) values(sysdate,'open c2  ',dbg_seq.nextval);commit;
open c2;
loop
fetch c2 into v2;
exit when c2%notfound;
--insert into test_amit(a,b)values('amit-',v2.BILLNO);commit;
--insert into dbgstr(rdate,str,seq) values(sysdate,'before FUN_BILL_INSERT  ',dbg_seq.nextval);commit;
         v_val:=FUN_BILL_INSERT(p_compcode,v2.CIOID,v2.BILLNO,prefer,p_dateformat,v2.AGMAINCODE,v2.AG_SUB_CODE,v2.AGCODE,v2.AGNAME,v2.EXECCODE,v2.EXECNAME,v2.RETCODE,v2.RETNAME,p_base );
--insert into dbgstr(rdate,str,seq) values(sysdate,'after FUN_BILL_INSERT  ',dbg_seq.nextval);commit;
        
end loop;
close c2;
commit;
--insert into dbgstr(rdate,str,seq) values(sysdate,'close c2  ',dbg_seq.nextval);commit;
query2:=query2 || 'select CIOID AS "CIOID",BILLNO AS "Billno" ,AGENCY AS "Agency", CLIENT AS "Client" ,
RONO  AS "RoNo.",
CASE '''||p_dateformat||'''
WHEN ''mm/dd/yyyy'' THEN TO_CHAR(RODATE ,''mm/dd/yyyy'')
WHEN ''dd/mm/yyyy'' THEN TO_CHAR(RODATE ,''dd/mm/yyyy'')
WHEN ''yyyy/mm/dd'' THEN TO_CHAR(RODATE,''yyyy/mm/dd'') END AS "Ro.Date",
EXECUTIVE  AS "Executive",RETAINER  AS "Retainer" ,BOOKTYPE as "BookType",COLOR as "Color",ADCAT as "Adcat",
ADSUBCAT as "Adsubcat",ADSUBCAT3 as "Adsubcat3",ADSUBCAT4  as "Adsubcat4",ADSUBCAT5 as "Adsubcat5",PACKAG AS "Package",
to_char(BILLDATE,'''||p_dateformat||''') as "BillDate",
NOINSERT as "noinsert",PAIDINSERT as "Paidinsert" ,HEIGHT as "height",WIDTH as "width",AREA as "Area",PAGEPREMIUM as "Pagepremium",POSTPREM as "Postprem",
SCHEME as "scheme",RATECOD as "Ratecode",CARDRATE as "cardrate",CARDAMT as "cardamt",
CONTRACTRATE as "contractrate",DEVIATIONAMT as "Deviationamt",DEVIATIONPER AS "Deviation(%)",
AGGRATE as "Aggrate",AGGAMT as "aggamt",DISCAMT as "DiscAmt",DISCPER as "Discper",
POSAMT as  "posamt",POSPER as "pos(%)",SPDISCAMT as "Spdiscamt",
SPDISCPER as "Spdiscper",SPACEDISC as "Spacedisc",SPACEDISCPER as "Spacediscper",SPECIALCHARGE as "Specialcharge",AGENCYADDLTDPER  as "AgencyAddlTD(%)",
AGENCYADDLTDAMT as "AgencyAddlTDAmt",GROSSAMT as "Grossamt",
RETTDPER as "RetTD(%)",RETTDAMT as "RetTDAmt",AGENCYTDPER as "AgencyTD(%)",AGENCYTDAMT as "AgencyTDAmt",BILLAMT as "Billamt",
RETCOMMPER as "RetComm(%)",RETCOMMAMT as "RetCommAmt",minus_to_zero(ACTUALBUSINESS) as "ActualBusiness",
REVCENTER as "Revcenter",UOM AS "Uom",UOMDESC as "uomdesc"
,PUB_CENT_NAME as "Printcenter"
,BRANCH_NAME  as "Branch"
,DIST_NAME as "District"
,TALU_NAME as "Taluka"
,PAGE_NO as "Page_No"
,BILL_REMARK as "BillRemark",
nvl((SELECT "brand_alias" FROM brand_mst where "brand_code"=temp_ad_bills_report."BRAND_CODE"),'''') as BRAND,
nvl((SELECT nvl(("Varient_Alias"),'''') FROM varient_mst where "Varient_Code"=temp_ad_bills_report."VARIENT_NAME"),'''') as "VARIENT",
nvl((SELECT "Product_Name" FROM PRODUCT_MAST where "Product_Code"=temp_ad_bills_report."PRIPROCTG" and "Comp_Code"=temp_ad_bills_report."COMP_CODE"),'''') as PRODUCT,
"CAPTION" AS CAPTION
from temp_ad_bills_report where sess_id='||userenv('sessionid') ;


IF(p_fromdate IS NOT NULL AND p_dateto IS NOT NULL )
THEN
query2:=query2||' and BILLDATE between  '''||p_fromdate ||''' and  '''||p_dateto||''' ';
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
query2:=query2 ||' and (EXECUTIVE_NAME   is not null and EXECUTIVE_NAME !=''0'')  ';
end if;

if(p_base='3')then
query2:=query2 ||' and (RETAINER_CODE  is not null  and RETAINER_CODE  !=''0'')  ';
end if;



query2:=query2 || ' order by CIOID';

delete from searchtbl;
--insert into searchtbl values(query2);commit;
--insert into dbgstr(rdate,str,seq) values(sysdate,'OPEN p_recordset1 FOR   '||query2,dbg_seq.nextval);commit;
OPEN p_recordset1 FOR
query2;

elsif(p_adcheck=3) then
query3:=query3 ||'SELECT m."cio_booking_id" AS "CIOID",
to_char(m."date_time",'''||p_dateformat||''') as "BookDate",
a."Agency_Name" AS "Agency",
NVL((SELECT "Cust_Name" FROM CUST_MAST WHERE "Cust_Code"=m."Client_code"),m."Client_code")  AS "Client",
m."RO_No" AS "RoNo.",
CASE '''||p_dateformat||'''
WHEN ''mm/dd/yyyy'' THEN TO_CHAR(m."RO_Date",''mm/dd/yyyy'')
WHEN ''dd/mm/yyyy'' THEN TO_CHAR(m."RO_Date" ,''dd/mm/yyyy'')
WHEN ''yyyy/mm/dd'' THEN TO_CHAR(m."RO_Date",''yyyy/mm/dd'') END AS "Ro.Date",
(select EXEC_MAST."Exec_name" from exec_mast where m."Executive_code"=to_char(exec_mast."Exe_no")) AS "Executive",
(select RETAINERMASTER."Retain_Name"  FROM  RETAINERMASTER where RETAINERMASTER."Retain_Code"=m.RETAINER ) AS "Retainer",
decode(m."Booking_type",''1'',''Barter'',''2'',''FMG'',''3'',''Normal'',''4'',''InHouse'',''5'',''Complimentary'',''Normal'') as "BookType",
(select col_mast."Col_Alias" from col_mast where i."Col_Code" =col_mast."Col_Code") as "Color",
adv_cat_mast."Adv_Cat_Name" as "Adcat",
(select adv_subcat_mast."Adv_Subcat_Name" from adv_subcat_mast where i."Ad_Sub_Cat"=adv_subcat_mast."Adv_Subcat_Code" and  adv_cat_mast."Adv_Cat_Code"=adv_subcat_mast."Adv_Cat_Code")as "Adsubcat",
(select ad_cat3."catname" from ad_cat3,adv_subcat_mast  where m."Ad_Subcat3"=ad_cat3."catcode" and ad_cat3."subcatname"=adv_subcat_mast."Adv_Subcat_Code" and i."Ad_Sub_Cat"=adv_subcat_mast."Adv_Subcat_Code" and  adv_cat_mast."Adv_Cat_Code"=adv_subcat_mast."Adv_Cat_Code") as "Adsubcat3",
(select tbl_cat4."Cat_Name" from tbl_cat4,adv_subcat_mast where i."AD_SUBCAT4"=tbl_cat4."Cat_Code" and tbl_cat4."Sub_Cat_Name"=adv_subcat_mast."Adv_Subcat_Code" and i."Ad_Sub_Cat"=adv_subcat_mast."Adv_Subcat_Code" and  adv_cat_mast."Adv_Cat_Code"=adv_subcat_mast."Adv_Cat_Code") as "Adsubcat4",
(select tbl_cat5."Cat_Name" from tbl_cat5,adv_subcat_mast where i."AD_SUBCAT5"=tbl_cat5."Cat_Code" and tbl_cat5."Sub_Cat_Name"=adv_subcat_mast."Adv_Subcat_Code" and i."Ad_Sub_Cat"=adv_subcat_mast."Adv_Subcat_Code" and  adv_cat_mast."Adv_Cat_Code"=adv_subcat_mast."Adv_Cat_Code") as "Adsubcat5",
-- FETCH_PACK(m."cio_booking_id") AS "Package",
FETCH_PACK_new(m."cio_booking_id", m."Package_code" ) AS "Package",
to_char(i."Insert_Date" ,'''||p_dateformat||''') as "PubDate",
 i."Height" as "height",
 i."Width"  as "width",
i."Size_Book" as "Area",
(select ADVPOS_PREM_MAST."premiumname" from advpos_prem_mast where i."Premium1" =ADVPOS_PREM_MAST."Premiumcode") as "Pagepremium",
(select advpos_type_mast."Pos_Type" from advpos_type_mast where i."Page_Post" =advpos_type_mast."Pos_Type_Code") as "Postprem",
(select scheme_master."Scheme_Name" from scheme_master where m."Scheme_type_code"=scheme_master."scheme_id") as "scheme",
m."Rate_code" as "Ratecode",
m."Card_rate" as "cardrate",
m."Card_rate"*i."Size_Book" as "cardamt",
m."Contract_rate" as "contractrate",
m."Deviation" as "Deviationamt",
m."Deviation" AS "Deviation(%)",
m."Agrred_rate" as "Aggrate",
i."Agreed_Rate"  as "aggamt",
((m."Card_rate"*i."Size_Book") - DECODE(NVL(i."Agreed_Rate",0),0,(m."Card_rate"*i."Size_Book"),i."Agreed_Rate")) as "DiscAmt",
m."Discount_per" as "Discper",
(select SUM(nvl(RAT,0)) from multipack_rat where cioid=m."cio_booking_id"  and sess_id='||userenv('sessionid')||') as  "posamt",
(select SUM(nvl(PER_AMT,0)) from multipack_rat where cioid=m."cio_booking_id"   and sess_id='||userenv('sessionid')||') as "pos(%)",
round(((m."Special_disc_per" * i."Size_Book" * m."Card_rate")/100),2) as "Spdiscamt",
m."Special_disc_per" as "Spdiscper",
round(((m."Space_disc_per" * i."Size_Book" * m."Card_rate")/100),2) as "Spacedisc",
m."Space_disc_per" as "Spacediscper",
m."Special_charges" as "Specialcharge",
nvl(m."ADD_AGENCY_COMM",''0'') as "AgencyAddlTD(%)",
nvl((nvl(i."Gross_Rate" ,''0'')*nvl(m."ADD_AGENCY_COMM",''0'')/100),''0'') as "AgencyAddlTDAmt",
nvl(i."Gross_Rate",''0'') as "Grossamt",
(select DISTINCT TO_NUMBER(NVL("Comm_Rate",''0''))    from RET_COMM_DETAILS WHERE "Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(m."RETAINER",''0'') AND "Eff_from_Date"=(SELECT MAX("Eff_from_Date") FROM RET_COMM_DETAILS WHERE "Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(m."RETAINER",''0'')) AND ROWNUM<=1 ) as "RetTD(%)",
nvl(i."Gross_Rate",''0'')*(select DISTINCT TO_NUMBER(NVL("Comm_Rate",''0''))    from RET_COMM_DETAILS WHERE "Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(m."RETAINER",''0'') AND "Eff_from_Date"=(SELECT MAX("Eff_from_Date") FROM RET_COMM_DETAILS WHERE "Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(m."RETAINER",''0'')) AND ROWNUM<=1 )/100 as "RetTDAmt",
nvl(m."Trade_disc",''0'' )as "AgencyTD(%)",
(nvl(i."Gross_Rate",''0'')* nvl(m."Trade_disc",''0'' )/100 )as "AgencyTDAmt",
NVL(i."Bill_Amt",''0'') as "Billamt",
nvl(case( '''||prefer||''' )
    when ''Y'' then
        ( CASE (select DISTINCT "Discount" from RET_COMM_DETAILS WHERE "Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(m."RETAINER",''0'') AND "Eff_from_Date"=(SELECT MAX("Eff_from_Date") FROM RET_COMM_DETAILS WHERE "Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(m."RETAINER",''0'')) AND ROWNUM<=1)
         when ''Gross'' then

               (
                 CASE to_number(nvl(m.RETAINER_COMM,0))
                 WHEN 0 THEN 0
                 ELSE (to_number(nvl(m.RETAINER_COMM,''0''))-to_number(nvl(m."ADD_AGENCY_COMM",''0'') ))
                end  )


         when ''Net''   then  to_number(nvl(m.RETAINER_COMM,''0''))
        END )

    ELSE (select 0  from dual)
end  ,''0'') as "RetComm(%)",

nvl(
case( '''||prefer||''' )
    when ''Y'' then
        ( CASE (select DISTINCT "Discount" from RET_COMM_DETAILS WHERE "Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(m."RETAINER",''0'') AND "Eff_from_Date"=(SELECT MAX("Eff_from_Date") FROM RET_COMM_DETAILS WHERE "Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(m."RETAINER",''0'')) AND ROWNUM<=1)
         when ''Gross'' then



                (
                 CASE to_number(nvl(m.RETAINER_COMM_AMT,0))
                 WHEN 0 THEN 0
                 ELSE (to_number(nvl(m.RETAINER_COMM_AMT,''0''))-(nvl((nvl(i."Gross_Rate",''0'')*to_number(nvl(m."ADD_AGENCY_COMM",''0''))/100),''0'')))
                 end )


         when ''Net''   then  (nvl(i."Gross_Rate",''0'')*(to_number(nvl(m.RETAINER_COMM,''0'')) )/100)
        END )

    ELSE (select 0  from dual)
end
,''0'') as "RetCommAmt",


minus_to_zero(nvl((  NVL(i."Bill_Amt",''0'')-
nvl(
case( '''||prefer||''' )
    when ''Y'' then
        ( CASE (select DISTINCT "Discount" from RET_COMM_DETAILS WHERE "Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(m."RETAINER",''0'') AND "Eff_from_Date"=(SELECT MAX("Eff_from_Date") FROM RET_COMM_DETAILS WHERE "Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(m."RETAINER",''0'')) AND ROWNUM<=1)
         when ''Gross'' then
           (
                 CASE to_number(nvl(m.RETAINER_COMM_AMT,0))
                 WHEN 0 THEN 0
                 ELSE (to_number(nvl(m.RETAINER_COMM_AMT,''0''))-(nvl((nvl(i."Gross_Rate",''0'')*to_number(nvl(m."ADD_AGENCY_COMM",''0''))/100),''0'')))
                 end )

         when ''Net''   then  (nvl(i."Gross_Rate",''0'')*(to_number(nvl(m.RETAINER_COMM,''0'')) )/100)
          else  (nvl(i."Gross_Rate",''0'')*(to_number(nvl(m."ADD_AGENCY_COMM",''0'')) )/100)  
        END )



    ELSE (select 0  from dual)
end
,''0'') ),''0'')) as "ActualBusiness",
(SELECT BRANCH_MST."Branch_Name" FROM BRANCH_MST WHERE m."Revenue_center"=BRANCH_MST."Branch_Code" )as "Revcenter"
,UOM_MAST."Uom_Name"  AS "Uom",
pub_mast."Pub_Name" as "Publication",
i."Edition" as "Edition",
uom_mast.UOM_DESC as "uomdesc"
,(select pub_cent_mast."Pub_Cent_name" from pub_cent_mast where pub_cent_mast."Pub_cent_Code" in(select "pub_center" from  BRANCH_MST WHERE m."branch"="Branch_Code") ) as "Printcenter"
,(SELECT "Branch_Name" FROM BRANCH_MST where  m."branch" = "Branch_Code") as "Branch"

,case '''||p_base||'''
when ''1'' then  a."Dist_Code"
when ''2'' then (select dist_mst."Dist_Name" from dist_mst where dist_mst."Dist_Code" in(select exec_mast."dist_code" from exec_mast where  to_char(exec_mast."Exe_no")=m."Executive_code" )  )
when ''3'' then (select dist_mst."Dist_Name" from dist_mst where dist_mst."Dist_Code" in(select RETAINERMASTER."Dist_Code" from RETAINERMASTER where  RETAINERMASTER."Retain_Code"= m.RETAINER )  ) end as "District"
,case '''||p_base||'''
when ''1'' then (select taluka_mast.TALU_NAME  from taluka_mast where a.TALUKA=taluka_mast.TALU_CODE )
when ''2'' then (select taluka_mast.TALU_NAME  from taluka_mast where taluka_mast.TALU_CODE in(select exec_mast.TALUKA from exec_mast where  to_char(exec_mast."Exe_no")=m."Executive_code" )  )
when ''3'' then (select taluka_mast.TALU_NAME  from taluka_mast where taluka_mast.TALU_CODE in(select RETAINERMASTER.TALUKA from RETAINERMASTER where  RETAINERMASTER."Retain_Code"= m.RETAINER )  ) end as "Taluka"
,i."Page_No" as "Page_No"
,m.CASHDISCOUNT as "Cash_Disc",i."Insert_Status" as "Status"
,m."Box_code" as "BoxCode",m."Userid" as USERID,(SELECT max("username") from login where com_code = m."Comp_code" and "userid"=m."Userid") as USERNAME
,m."Bill_remarks" as "BillRemark",m."Caption" as "CAPTION",
nvl((SELECT nvl(("Varient_Alias"),'''') FROM varient_mst where "Varient_Code"=m."Variant_code"),'''') as "VARIENT",
nvl((SELECT "Product_Name" FROM PRODUCT_MAST where "Product_Code"=m."Product_code" and "Comp_Code"=m."Comp_code"),'''') as PRODUCT,
nvl((SELECT "brand_alias" FROM brand_mst where "brand_code"=M."Brand_code"),'''') as BRAND
FROM TBL_BOOKING_MAST m,AGENCY_MAST a ,uom_mast,
adv_cat_mast,
adv_type_mast,pub_mast,
TBL_BOOKING_insert i
WHERE m."Comp_code"='''||p_compcode||''' AND
m."cio_booking_id"=i."Cio_Booking_Id" and
UOM_MAST."Uom_Code"=m."Uom_code" and
m."Agency_sub_code"=a."code_subcode" AND
i."Ad_Cat" =adv_cat_mast."Adv_Cat_Code" and
m."Ad_type_code"=adv_type_mast."Adv_Type_Code"
and adv_type_mast."Adv_Type_Code"=adv_cat_mast."Adv_Type" and
pub_mast."Pub_Code"=i."Publication_Code" and
((i."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id='''||p_puserid||''') and '''||p_chk_access||'''=''1'')
or  ('''||p_chk_access||'''=''0'') )' ;

if(p_base='2')then
query3:=query3 ||' and (m."Executive_code" is not null and m."Executive_code" !=''0'')  ';
end if;

if(p_base='3')then
query3:=query3 ||' and (m.RETAINER is not null  and m.RETAINER !=''0'')  ';
end if;


if(p_drpstatus is null) then
query3:=query3||' and lower(i."Insert_Status")!='''||'cancel'||'''';
end if;


if(p_insertstatus is not null) then
query3:=query3||' and lower(i."Insert_Status")='''||p_insertstatus||'''';
end if;


IF(p_fromdate IS NOT NULL AND p_dateto IS NULL )
THEN
query3:=query3 ||' and i."Insert_Date" ='''||p_fromdate||'''';
END IF;

IF(p_fromdate IS NOT NULL AND p_dateto IS NOT NULL)
THEN
query3:=query3 ||' and i."Insert_Date" between  '''||p_fromdate ||''' and  '''||p_dateto||''' ';
END IF;

IF(p_publication IS NOT NULL)
THEN
query3:=query3 ||' and i."Publication_Code"='''||p_publication||'''    ';
END IF;

IF(p_pub_cent IS NOT NULL)
THEN
query3:=query3||'  and m."branch" IN (SELECT "Branch_Code" FROM BRANCH_MST WHERE m."branch"="Branch_Code" and "pub_center"='''||p_pub_cent||''')';
END IF;

IF(p_branch IS NOT NULL)
THEN
query3:=query3 ||'  and m."branch" ='''||p_branch||'''';
END IF;

IF(p_edition IS NOT NULL)
THEN
query3:=query3 ||'  and i."Edition_Code"='''||p_edition||'''';
END IF;
IF(p_region IS NOT NULL)
THEN
query3:=query3  ||' and a."region" ='''||p_region||'''';
END IF;

IF(p_revcenter IS NOT NULL)
THEN
query3:=query3  ||' and m."Revenue_center" ='''||p_revcenter||'''';
END IF;

IF(p_adtype IS NOT NULL)
THEN
query3:=query3  || ' and m."Ad_type_code"='''||p_adtype||'''';
END IF;

IF(p_agencytype IS NOT NULL)
THEN
query3:=query3  || ' and m."Agency_type" ='''||p_agencytype||'''';
END IF;

IF(p_adcat IS NOT NULL)
THEN
query3:=query3  || ' and i."Ad_Cat" ='''||p_adcat||'''';
END IF;

IF(p_adsubcat IS NOT NULL)
THEN
query3:=query3  || ' and i."Ad_Sub_Cat" ='''||p_adsubcat||'''';
END IF;

IF(p_adsubcat3 IS NOT NULL)
THEN
query3:=query3  || ' and i."AD_SUBCAT3" ='''||p_adsubcat3||'''';
END IF;

IF(p_adsubcat4 IS NOT NULL)
THEN
query3:=query3  || ' and i."AD_SUBCAT4" ='''||p_adsubcat4||'''';
END IF;

IF(p_adsubcat5 IS NOT NULL)
THEN
query3:=query3  || ' and i."AD_SUBCAT5" ='''||p_adsubcat5||'''';
END IF;

IF(p_package IS NOT NULL)
THEN
query3:=query3  || ' and m."Package_code" ='''||p_package||'''';
END IF;

IF(p_scheme IS NOT NULL)
THEN
query3:=query3  || ' and m."Scheme_type_code" ='''||p_scheme||'''';
END IF;

IF(p_agency IS NOT NULL)
THEN
query3:=query3  || ' and a."Agency_Code" ='''||p_agency||'''';
END IF;

IF(p_client IS NOT NULL)
THEN
query3:=query3  || ' and m."Client_code" ='''||p_client||'''';
END IF;

IF(p_executive IS NOT NULL)
THEN
query3:=query3  || ' and m."Executive_code" ='''||p_executive||'''';
END IF;

IF(p_retainer IS NOT NULL)
THEN
query3:=query3  || ' and m.RETAINER ='''||p_retainer||'''';
END IF;

IF(p_product IS NOT NULL)
THEN
query3:=query3 || ' and m."Product_code" ='''||p_product||'''';
END IF;

IF(p_brand IS NOT NULL)
THEN
query3:=query3  || ' and m."Brand_code" ='''||p_brand||'''';
END IF;

IF(p_varient IS NOT NULL)
THEN
query3:=query3  || ' and m."Variant_code" ='''||p_varient||'''';
END IF;

IF(p_pagetype IS NOT NULL)
THEN
query3:=query3  || ' and m."Page_type_code" ='''||p_pagetype||'''';
END IF;

IF(p_pageprem IS NOT NULL)
THEN
query3:=query3 || ' and i."Premium1" ='''||p_pageprem||'''';
END IF;

IF(p_postprem IS NOT NULL)
THEN
query3:=query3 || ' and i."Page_Post" ='''||p_postprem||'''';
END IF;

IF(p_rostatus IS NOT NULL)
THEN
query3:=query3 || ' and m."ro_status" ='''||p_rostatus||'''';
END IF;

IF(p_booktype IS NOT NULL)
THEN
query3:=query3 || ' and m."Booking_type" ='''||p_booktype||'''';
END IF;

IF(p_contractname  IS NOT NULL)
THEN
query3:=query3 || ' and m."Contract_name" ='''||p_contractname ||'''';
END IF;

IF(p_suppliment  IS NOT NULL)
THEN
query3:=query3 || ' and i."Supp_Code" ='''||p_suppliment||'''';
END IF;

IF(p_ratetype  IS NOT NULL)
THEN
query3:=query3 || ' and m."Rate_code" ='''||p_ratetype||'''';
END IF;

IF(p_city  IS NOT NULL)
THEN
if(p_base='1')then
query3:=query3 || ' and a."City_Code" ='''||p_city||'''';
end if;

if(p_base='2')then
query3:=query3 || ' and m."Executive_code" in(select exec_mast."Exe_no" from exec_mast where exec_mast."city_code" ='''||p_city||''' )';
end if;

if(p_base='3')then
query3:=query3 || ' and m.RETAINER in(select RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  RETAINERMASTER."City_Code"='''||p_city||''')';
end if;
END IF;

IF(p_zone  IS NOT NULL)
THEN
if(p_base='1')then
query3:=query3 || ' and a."zone_code" ='''||p_zone||'''';
end if;

if(p_base='2')then
query3:=query3 || ' and m."Executive_code" in(select exec_mast."Exe_no" from exec_mast where exec_mast."city_code" in (select city_mst."City_Code" from city_mst where city_mst."Zone_Code"= '''||p_zone||''') )';
end if;

if(p_base='3')then
query3:=query3 || ' and m.RETAINER in(select RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  RETAINERMASTER."Zone_Code"='''||p_zone||''')';
end if;
END IF;

IF(p_district  IS NOT NULL)
THEN
if(p_base='1')then
query3:=query3 || ' and a."Dist_Code" ='''||p_district||'''';
end if;

if(p_base='2')then
query3:=query3 || ' and m."Executive_code" in(select exec_mast."Exe_no" from exec_mast where exec_mast."dist_code" ='''||p_district||''' )';
end if;

if(p_base='3')then
query3:=query3 || ' and m.RETAINER in(select RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  RETAINERMASTER."Dist_Code"='''||p_district||''')';
end if;
END IF;

IF(p_state  IS NOT NULL)
THEN
if(p_base='1')then
query3:=query3 || ' and a."State_Code" ='''||p_state||'''';
end if;

if(p_base='2')then
query3:=query3 || ' and m."Executive_code" in(select exec_mast."Exe_no" from exec_mast where exec_mast."State_code" ='''||p_state||''' )';
end if;

if(p_base='3')then
query3:=query3 || ' and m.RETAINER in(select RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  RETAINERMASTER."State_Code"='''||p_state||''')';
end if;
END IF;

IF(p_taluka  IS NOT NULL)
THEN
if(p_base='1')then
query3:=query3 || ' and a.TALUKA='''||p_taluka||'''  ';
end if;

if(p_base='2')then
query3:=query3 || ' and m."Executive_code" in(select exec_mast."Exe_no" from exec_mast where exec_mast.TALUKA ='''||p_taluka||''' )';
end if;

if(p_base='3')then
query3:=query3 || ' and m.RETAINER in(select RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  RETAINERMASTER.TALUKA='''||p_taluka||''')';
end if;
END IF;

query3:=query3 || ' order by i."Insert_Date" ,m."cio_booking_id"';
delete from searchtbl;
--insert into searchtbl values(query3);commit;
--insert into dbgstr(rdate,str,seq) values(sysdate,'OPEN p_recordset1 FOR   '||query3,dbg_seq.nextval);commit;
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
round(((nvl(sum(a."Deviation"),0)*100)/sum(a."Card_amount")),2) AS "Deviation(%)",
sum(a."Agreed_amount") as "aggamt",
(sum(a."Card_amount")- DECODE(NVL(sum(a."Agreed_amount"),0),0,sum(a."Card_amount"),sum(a."Agreed_amount"))) as "DiscAmt",
round((((sum(a."Card_amount")- DECODE(NVL(sum(a."Agreed_amount"),0),0,sum(a."Card_amount"),sum(a."Agreed_amount"))) *100)/sum(a."Card_amount")),2)  as "Discper",
sum((select SUM(nvl(RAT,0)) from multipack_rat where cioid=a."cio_booking_id"  and sess_id='||userenv('sessionid')||')) as  "posamt",
round(((sum((select SUM(nvl(RAT,0)) from multipack_rat where cioid=a."cio_booking_id"  and sess_id='||userenv('sessionid')||'))*100)/sum(a."Card_amount")),2)   as "pos(%)",
sum(a."Special_disc_per" * a."Total_area" * a."Card_rate"/100) as "Spdiscamt",
round(((sum(a."Special_disc_per" * a."Total_area" * a."Card_rate"/100)*100)/sum(a."Card_amount")),2)  as "Spdiscper",
sum(a."Space_disc_per" * a."Total_area" * a."Card_rate"/100) as "Spacedisc",
round(((sum(a."Space_disc_per" * a."Total_area" * a."Card_rate"/100) *100)/sum(a."Card_amount")),2) as "Spacediscper",
sum(a."Special_charges") as "Specialcharge",
round(((sum(nvl((nvl(a."Gross_amount",''0'')*nvl(a."ADD_AGENCY_COMM",''0'')/100),''0''))*100)/(sum(a."Card_amount")+sum((select SUM(nvl(RAT,0)) from multipack_rat where cioid=a."cio_booking_id" and sess_id='||userenv('sessionid')||'))+sum(a."Special_charges")-sum(a."Deviation")-(sum(a."Card_amount")- DECODE(NVL(sum(a."Agreed_amount"),0),0,sum(a."Card_amount"),sum(a."Agreed_amount"))) -sum(a."Space_disc_per" * a."Total_area" * a."Card_rate"/100)-sum(a."Special_disc_per" * a."Total_area" * a."Card_rate"/100))),2) as "AgencyAddlTD(%)",
sum(nvl((nvl(a."Gross_amount",''0'')*nvl(a."ADD_AGENCY_COMM",''0'')/100),''0'')) as "AgencyAddlTDAmt",
sum(nvl(a."Gross_amount",''0'')) as "Grossamt",
round(((sum(nvl(nvl(a."Gross_amount",''0'')*(select DISTINCT TO_NUMBER(NVL("Comm_Rate",''0''))    from RET_COMM_DETAILS WHERE "Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(a."RETAINER",''0'') AND "Eff_from_Date"=(SELECT MAX("Eff_from_Date") FROM RET_COMM_DETAILS WHERE "Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(a."RETAINER",''0'')) AND ROWNUM<=1 )/100,''0''))*100)/sum(nvl(a."Gross_amount",''0''))),2) as "RetTD(%)",
sum(nvl(nvl(a."Gross_amount",''0'')*(select DISTINCT TO_NUMBER(NVL("Comm_Rate",''0''))    from RET_COMM_DETAILS WHERE "Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(a."RETAINER",''0'') AND "Eff_from_Date"=(SELECT MAX("Eff_from_Date") FROM RET_COMM_DETAILS WHERE "Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(a."RETAINER",''0'')) AND ROWNUM<=1 )/100,''0''))as "RetTDAmt",
round(((sum((nvl(a."Gross_amount",''0'')* nvl(a."Trade_disc",''0'' )/100) )*100)/(sum(a."Card_amount")+sum((select SUM(nvl(RAT,0)) from multipack_rat where cioid=a."cio_booking_id"  and sess_id='||userenv('sessionid')||'))+sum(a."Special_charges")-sum(a."Deviation")-(sum(a."Card_amount")- DECODE(NVL(sum(a."Agreed_amount"),0),0,sum(a."Card_amount"),sum(a."Agreed_amount"))) -sum(a."Space_disc_per" * a."Total_area" * a."Card_rate"/100)-sum(a."Special_disc_per" * a."Total_area" * a."Card_rate"/100))),2)as "AgencyTD(%)",
sum((nvl(a."Gross_amount",''0'')* nvl(a."Trade_disc",''0'' )/100) )as "AgencyTDAmt",
sum(nvl(a."Bill_amount",''0'')) as "Billamt",
round(((sum(nvl(
case( '''||prefer||''' )
    when ''Y'' then
        ( CASE (select DISTINCT "Discount" from RET_COMM_DETAILS WHERE "Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(a."RETAINER",''0'') AND "Eff_from_Date"=(SELECT MAX("Eff_from_Date") FROM RET_COMM_DETAILS WHERE "Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(a."RETAINER",''0'')) AND ROWNUM<=1)
       when ''Gross'' then

         (
                 CASE to_number(nvl(a.RETAINER_COMM,0))
                 WHEN 0 THEN 0
                 ELSE (to_number(nvl(a.RETAINER_COMM,''0''))-to_number(nvl(a."ADD_AGENCY_COMM",''0'') ))
                 end )


         when ''Net''   then  to_number(nvl(a.RETAINER_COMM,''0''))
          END )



    ELSE (select 0  from dual)
end
,''0''))*100)/sum(nvl(a."Gross_amount",''0''))),2) as "RetComm(%)",
sum(nvl(
case( '''||prefer||''' )
    when ''Y'' then
        ( CASE (select DISTINCT "Discount" from RET_COMM_DETAILS WHERE "Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(a."RETAINER",''0'') AND "Eff_from_Date"=(SELECT MAX("Eff_from_Date") FROM RET_COMM_DETAILS WHERE "Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(a."RETAINER",''0'')) AND ROWNUM<=1)
       when ''Gross'' then


                 (
                 CASE to_number(nvl(a.RETAINER_COMM_AMT,0))
                 WHEN 0 THEN 0
                 ELSE (to_number(nvl(a.RETAINER_COMM_AMT,''0''))-(nvl((nvl(a."Gross_amount",''0'')*to_number(nvl(a."ADD_AGENCY_COMM",''0''))/100),''0'')))
                 end )

         when ''Net''   then  (nvl(a."Gross_amount",''0'')*(to_number(nvl(a.RETAINER_COMM,''0'')) )/100)
            END )




    ELSE (select 0  from dual)
end
,''0'')) as "RetCommAmt",

minus_to_zero(sum(nvl((a."Bill_amount"-nvl(
case( '''||prefer||''' )
    when ''Y'' then
        ( CASE (select DISTINCT "Discount" from RET_COMM_DETAILS WHERE "Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(a."RETAINER",''0'') AND "Eff_from_Date"=(SELECT MAX("Eff_from_Date") FROM RET_COMM_DETAILS WHERE "Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(a."RETAINER",''0'')) AND ROWNUM<=1)
       when ''Gross'' then
       (
                 CASE to_number(nvl(a.RETAINER_COMM_AMT,0))
                 WHEN 0 THEN 0
                 ELSE (to_number(nvl(a.RETAINER_COMM_AMT,''0''))-(nvl((nvl(a."Gross_amount",''0'')*to_number(nvl(a."ADD_AGENCY_COMM",''0''))/100),''0'')))
                 end )


         when ''Net''   then  (nvl(a."Gross_amount",''0'')*(to_number(nvl(a.RETAINER_COMM,''0'')) )/100)
         else  (nvl(a."Gross_amount",''0'')*(to_number(nvl(a."ADD_AGENCY_COMM",''0'')) )/100)
           END )

    ELSE (select 0  from dual)
end
,''0'')  ),''0'') ))as "ActualBusiness"

FROM TBL_BOOKING_MAST a,
agency_mast
WHERE a."Comp_code"='''||p_compcode||''' AND
a."Agency_sub_code"=AGENCY_MAST."code_subcode"' ;


if(p_chk_access='1')then
query1:=query1||' and a."cio_booking_id"  in (select distinct b."Cio_Booking_Id" from tbl_booking_insert b where a."cio_booking_id"=b."Cio_Booking_Id" and b."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id='''||p_puserid||''')) ';
end if;

if(p_base='2')then
query1:=query1||' and (a."Executive_code" is not null and a."Executive_code" !=''0'')  ';
end if;

if(p_base='3')then
query1:=query1||' and (a.RETAINER is not null  and a.RETAINER !=''0'')  ';
end if;


if(p_drpstatus is null) then
query1:=query1||' and a."cio_booking_id"  in (select distinct b."Cio_Booking_Id" from tbl_booking_insert b where a."cio_booking_id"=b."Cio_Booking_Id" AND lower("Insert_Status")!='''||'cancel'||''' )';
end if;

if(p_insertstatus is not null) then
query1:=query1||' and a."cio_booking_id"  in (select distinct b."Cio_Booking_Id" from tbl_booking_insert b where a."cio_booking_id"=b."Cio_Booking_Id" AND lower("Insert_Status")='''||p_insertstatus||''' )';
end if;


IF(p_fromdate IS NOT NULL AND p_dateto IS NULL  and  p_filterby='Booking Date')
THEN
query1:=query1||' and a."date_time" ='''||p_fromdate||'''';
END IF;

IF(p_fromdate IS NOT NULL AND p_dateto IS NOT NULL and p_filterby='Booking Date' )
THEN
query1:=query1||' and a."date_time" between  '''||p_fromdate ||''' and  '''||p_dateto||''' ';
END IF;

IF(p_fromdate IS NOT NULL AND p_dateto IS NULL  and  p_filterby='Publish Date')
THEN
query1:=query1||' and a."Insertion_date" ='''||p_fromdate||'''';
END IF;

IF(p_fromdate IS NOT NULL AND p_dateto IS NOT NULL and p_filterby='Publish Date' )
THEN
query1:=query1||' and a."Insertion_date"  between  '''||p_fromdate ||''' and  '''||p_dateto||''' ';
END IF;

IF(p_publication IS NOT NULL)
THEN
query1:=query1||'  and a."cio_booking_id"  in (select distinct b."Cio_Booking_Id" from tbl_booking_insert b where b."Publication_Code"='''||p_publication||''' )    ';
END IF;

--old version
IF(p_pub_cent IS NOT NULL)
THEN
query1:=query1||'  and a."branch" IN (SELECT "Branch_Name" FROM BRANCH_MST WHERE a."branch"="Branch_Name" and "pub_center" in (SELECT "Pub_cent_Code" FROM PUB_CENT_MAST WHERE  branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" and "Pub_cent_Code"='''||p_pub_cent||'''))';
END IF;


IF(p_branch IS NOT NULL)
THEN
query1:=query1||' and a."branch" ='''||p_branch||'''';
END IF;


--new version
/*
IF(p_pub_cent IS NOT NULL)
THEN
query1:=query1||'  and a."branch" IN (SELECT "Branch_Code" FROM BRANCH_MST WHERE a."branch"="Branch_Code" and "pub_center" in (SELECT "Pub_cent_Code" FROM PUB_CENT_MAST WHERE  branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" and "Pub_cent_Code"='''||p_pub_cent||'''))';
END IF;


IF(p_branch IS NOT NULL)
THEN
query1:=query1||'  and a."branch" = (SELECT "Branch_Code" FROM BRANCH_MST where "Branch_Name" ='''||p_branch||''') ';
END IF;
*/

IF(p_edition IS NOT NULL)
THEN
query1:=query1||' and a."cio_booking_id"  in (select distinct b."Cio_Booking_Id" from tbl_booking_insert b where b."Edition_Code"='''||p_edition||''' )';
END IF;

IF(p_region IS NOT NULL)
THEN
query1:=query1 ||'  and agency_mast."region" ='''||p_region||'''';
END IF;

IF(p_suppliment  IS NOT NULL)
THEN
query1:=query1 || '  and a."cio_booking_id"  in (select distinct b."Cio_Booking_Id" from tbl_booking_insert b where b."Supp_Code" ='''||p_suppliment||''' )';
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
query1:=query1 || ' and a."Executive_code" in(select exec_mast."Exe_no" from exec_mast where exec_mast."city_code" ='''||p_city||''' )';
end if;

if(p_base='3')then
query1:=query1 || ' and a.RETAINER in(select RET."Retain_Code" from  RETAINERMASTER RET where  RET."City_Code"='''||p_city||''')';
end if;
END IF;

IF(p_zone  IS NOT NULL)
THEN
if(p_base='1')then
query1:=query1 || ' and AGENCY_MAST."zone_code" ='''||p_zone||'''';
end if;

if(p_base='2')then
query1:=query1 || ' and a."Executive_code" in(select exec_mast."Exe_no" from exec_mast where exec_mast."city_code" in (select city_mst."City_Code" from city_mst where city_mst."Zone_Code"= '''||p_zone||''') )';
end if;

if(p_base='3')then
query1:=query1 || ' and a.RETAINER in(select RET."Retain_Code" from  RETAINERMASTER RET where  RET."Zone_Code"='''||p_zone||''')';
end if;
END IF;

IF(p_district  IS NOT NULL)
THEN
if(p_base='1')then
query1:=query1 || ' and AGENCY_MAST."Dist_Code" ='''||p_district||'''';
end if;

if(p_base='2')then
query1:=query1 || ' and a."Executive_code" in(select exec_mast."Exe_no" from exec_mast where exec_mast."dist_code" ='''||p_district||''' )';
end if;

if(p_base='3')then
query1:=query1 || ' and a.RETAINER in(select RET."Retain_Code" from  RETAINERMASTER RET where  RET."Dist_Code"='''||p_district||''')';
end if;
END IF;

IF(p_state  IS NOT NULL)
THEN
if(p_base='1')then
query1:=query1 || ' and AGENCY_MAST."State_Code" ='''||p_state||'''';
end if;

if(p_base='2')then
query1:=query1 || ' and a."Executive_code" in(select exec_mast."Exe_no" from exec_mast where exec_mast."State_code" ='''||p_state||''' )';
end if;

if(p_base='3')then
query1:=query1 || ' and a.RETAINER in(select RET."Retain_Code" from  RETAINERMASTER RET where  RET."State_Code"='''||p_state||''')';
end if;
END IF;

IF(p_taluka  IS NOT NULL)
THEN
if(p_base='1')then
query1:=query1 || ' and AGENCY_MAST.TALUKA='''||p_taluka||'''  ';
end if;

if(p_base='2')then
query1:=query1 || ' and a."Executive_code" in(select exec_mast."Exe_no" from exec_mast where exec_mast.TALUKA ='''||p_taluka||''' )';
end if;

if(p_base='3')then
query1:=query1 || ' and a.RETAINER in(select RET."Retain_Code" from  RETAINERMASTER RET where  RET.TALUKA='''||p_taluka||''')';
end if;
END IF;

query1:=query1 || ' group by a."date_time" order by "Date" ';

--insert into dbgstr(rdate,str,seq) values(sysdate,'OPEN p_recordset1 FOR1   '||query1,dbg_seq.nextval);commit;

OPEN p_recordset1 FOR
query1;



elsif(p_adcheck=2)then

delete from temp_ad_bills_report where sess_id=userenv('sessionid');
open c2;
loop
fetch c2 into v2;
exit when c2%notfound;
--insert into dbgstr(rdate,str,seq) values(sysdate,'before FUN_BILL_INSERT1   ',dbg_seq.nextval);commit;
     v_val:=FUN_BILL_INSERT(p_compcode,v2.CIOID,v2.BILLNO,prefer,p_dateformat,v2.AGMAINCODE,v2.AG_SUB_CODE,v2.AGCODE,v2.AGNAME,v2.EXECCODE,v2.EXECNAME,v2.RETCODE,v2.RETNAME,p_base );
--insert into dbgstr(rdate,str,seq) values(sysdate,'after FUN_BILL_INSERT1   ',dbg_seq.nextval);commit;     
end loop;
close c2;
commit;
--insert into dbgstr(rdate,str,seq) values(sysdate,'close c2   ',dbg_seq.nextval);commit;

query2:=query2||'SELECT
to_char(BILLDATE,'''||p_dateformat||''') as "Date",
sum(NOINSERT) as "noinsert",
sum(PAIDINSERT) as "Paidinsert" ,
sum(AREA) as "Area",
sum(CARDAMT) as "cardamt",
sum(DEVIATIONAMT) as "Deviationamt",
round(((nvl(sum(DEVIATIONAMT),0) *100)/nvl(sum(CARDAMT),0)),2)   AS "Deviation(%)",
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
round(((nvl(sum(AGENCYADDLTDAMT),0)*100)/(nvl(sum(CARDAMT),0)+nvl(sum(POSAMT),0)+nvl(sum(SPECIALCHARGE),0)-nvl(sum(DEVIATIONAMT),0)-nvl(sum(DISCAMT),0)-nvl(sum(SPDISCAMT),0)-nvl(sum(SPACEDISC),0))),2) as "AgencyAddlTD(%)",
sum(GROSSAMT)  as "Grossamt",
sum(RETTDAMT)as "RetTDAmt",
round(((nvl(sum(RETTDAMT),0)*100)/nvl(sum(GROSSAMT),0) ),2) as "RetTD(%)",
sum(AGENCYTDAMT)as "AgencyTDAmt",
round(((nvl(sum(AGENCYTDAMT),0)*100)/(nvl(sum(CARDAMT),0)+nvl(sum(POSAMT),0)+nvl(sum(SPECIALCHARGE),0)-nvl(sum(DEVIATIONAMT),0)-nvl(sum(DISCAMT),0)-nvl(sum(SPDISCAMT),0)-nvl(sum(SPACEDISC),0))),2)as "AgencyTD(%)",
sum(BILLAMT )as "Billamt",
sum(RETCOMMAMT)as "RetCommAmt",
round(((nvl(sum(RETCOMMAMT),0)*100)/nvl(sum(GROSSAMT),0)),2) as "RetComm(%)",
minus_to_zero(sum(ACTUALBUSINESS))as "ActualBusiness"
from temp_ad_bills_report where sess_id='||userenv('sessionid');




IF(p_fromdate IS NOT NULL AND p_dateto IS NOT NULL )
THEN
query2:=query2||' and BILLDATE between  '''||p_fromdate ||''' and  '''||p_dateto||''' ';
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
query2:=query2 ||' and (EXECUTIVE_NAME   is not null and EXECUTIVE_NAME !=''0'')  ';
end if;

if(p_base='3')then
query2:=query2 ||' and (RETAINER_CODE  is not null  and RETAINER_CODE  !=''0'')  ';
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
round(((sum(a."Deviation")*100)/sum(a."Card_rate"*b."Size_Book")),2) AS "Deviation(%)",
sum(b."Agreed_Rate")  as "aggamt",
(sum(a."Card_rate"*b."Size_Book")- DECODE(NVL(sum(b."Agreed_Rate"),0),0,sum(a."Card_rate"*b."Size_Book"),sum(b."Agreed_Rate"))) as "DiscAmt",
round((((sum(a."Card_rate"*b."Size_Book")- DECODE(NVL(sum(b."Agreed_Rate"),0),0,sum(a."Card_rate"*b."Size_Book"),sum(b."Agreed_Rate")))*100)/sum(a."Card_rate"*b."Size_Book")),2) as "Discper",
sum((select SUM(nvl(RAT,0)) from multipack_rat where cioid=a."cio_booking_id" and sess_id='||userenv('sessionid')||')) as  "posamt",
round(((sum((select SUM(nvl(RAT,0)) from multipack_rat where cioid=a."cio_booking_id" and sess_id='||userenv('sessionid')||'))*100)/sum(a."Card_rate"*b."Size_Book")),2)  as "pos(%)",
sum(a."Special_disc_per" * b."Size_Book" * a."Card_rate"/100) as "Spdiscamt",
round(((sum(a."Special_disc_per" * b."Size_Book" * a."Card_rate"/100)*100)/sum(a."Card_rate"*b."Size_Book")),2) as "Spdiscper",
sum(a."Space_disc_per" * b."Size_Book" * a."Card_rate"/100) as "Spacedisc",
round(((sum(a."Space_disc_per" * b."Size_Book" * a."Card_rate"/100)*100)/sum(a."Card_rate"*b."Size_Book")),2) as "Spacediscper",
sum(a."Special_charges") as "Specialcharge",
round(((sum(nvl((nvl(b."Gross_Rate" ,''0'')*nvl(a."ADD_AGENCY_COMM",''0'')/100),''0''))*100)/(sum(a."Card_rate"*b."Size_Book")+sum((select SUM(nvl(RAT,0)) from multipack_rat where cioid=a."cio_booking_id" and sess_id='||userenv('sessionid')||'))+sum(a."Special_charges") -sum(a."Deviation")-(sum(a."Card_rate"*b."Size_Book")- DECODE(NVL(sum(b."Agreed_Rate"),0),0,sum(a."Card_rate"*b."Size_Book"),sum(b."Agreed_Rate")))-sum(a."Special_discount")-sum(a."Space_discount"))),2) as "AgencyAddlTD(%)",
sum(nvl((nvl(b."Gross_Rate" ,''0'')*nvl(a."ADD_AGENCY_COMM",''0'')/100),''0'')) as "AgencyAddlTDAmt",
ROUND(sum(nvl(b."Gross_Rate",''0'') ))as "Grossamt",
case sum(nvl(b."Gross_Rate",''0'') )
 when  0 then 0
   else  round(((sum(nvl(b."Gross_Rate",''0'')*(select DISTINCT TO_NUMBER(NVL("Comm_Rate",''0''))    from RET_COMM_DETAILS WHERE "Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(a."RETAINER",''0'') AND "Eff_from_Date"=(SELECT MAX("Eff_from_Date") FROM RET_COMM_DETAILS WHERE "Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(a."RETAINER",''0'')) AND ROWNUM<=1 )/100)*100)/sum(nvl(b."Gross_Rate",''0'') )),2)
 end  as "RetTD(%)",
sum(nvl(nvl(b."Gross_Rate",''0'')*(select DISTINCT TO_NUMBER(NVL("Comm_Rate",''0''))    from RET_COMM_DETAILS WHERE "Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(a."RETAINER",''0'') AND "Eff_from_Date"=(SELECT MAX("Eff_from_Date") FROM RET_COMM_DETAILS WHERE "Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(a."RETAINER",''0'')) AND ROWNUM<=1 )/100
,''0''))as "RetTDAmt",

round(((sum((nvl(b."Gross_Rate",''0'')* nvl(a."Trade_disc",''0'' )/100 ))*100)/(sum(a."Card_rate"*b."Size_Book")+sum((select SUM(nvl(RAT,0)) from multipack_rat where cioid=a."cio_booking_id" and sess_id='||userenv('sessionid')||'))+sum(a."Special_charges") -sum(a."Deviation")-(sum(a."Card_rate"*b."Size_Book")- DECODE(NVL(sum(b."Agreed_Rate"),0),0,sum(a."Card_rate"*b."Size_Book"),sum(b."Agreed_Rate")))-sum(a."Special_discount")-sum(a."Space_discount"))),2) as "AgencyTD(%)",

sum((nvl(b."Gross_Rate",''0'')* nvl(a."Trade_disc",''0'' )/100 ))as "AgencyTDAmt",
ROUND(sum(NVL(b."Bill_Amt",''0'')),2) as "Billamt",
 case sum(nvl(b."Gross_Rate",''0'') )
 when  0 then 0
 else  round(((sum(nvl(
case( '''||prefer||''' )
    when ''Y'' then
        ( CASE (select DISTINCT "Discount" from RET_COMM_DETAILS WHERE "Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(a."RETAINER",''0'') AND "Eff_from_Date"=(SELECT MAX("Eff_from_Date") FROM RET_COMM_DETAILS WHERE "Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(a."RETAINER",''0'')) AND ROWNUM<=1)
        when ''Gross'' then

         (
                 CASE to_number(nvl(a.RETAINER_COMM,0))
                 WHEN 0 THEN 0
                 ELSE (to_number(nvl(a.RETAINER_COMM,''0''))-to_number(nvl(a."ADD_AGENCY_COMM",''0'' )))
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
        ( CASE (select DISTINCT "Discount" from RET_COMM_DETAILS WHERE "Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(a."RETAINER",''0'') AND "Eff_from_Date"=(SELECT MAX("Eff_from_Date") FROM RET_COMM_DETAILS WHERE "Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(a."RETAINER",''0'')) AND ROWNUM<=1)
       when ''Gross'' then




                 (
                 CASE to_number(nvl(a.RETAINER_COMM_AMT,0))
                 WHEN 0 THEN 0
                 ELSE (to_number(nvl(a.RETAINER_COMM_AMT,''0''))-(nvl((nvl(b."Gross_Rate",''0'')*to_number(nvl(a."ADD_AGENCY_COMM",''0''))/100),''0'')))
                 end )



         when ''Net''   then  (nvl(b."Gross_Rate",''0'')*(to_number(nvl(a.RETAINER_COMM,''0'')) )/100)
        END )


    ELSE (select 0  from dual)
end
,''0''))as "RetCommAmt",


minus_to_zero(ROUND(sum(nvl((  NVL(b."Bill_Amt",''0'')-nvl(
case( '''||prefer||''' )
    when ''Y'' then
        ( CASE (select DISTINCT "Discount" from RET_COMM_DETAILS WHERE "Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(a."RETAINER",''0'') AND "Eff_from_Date"=(SELECT MAX("Eff_from_Date") FROM RET_COMM_DETAILS WHERE "Comp_code"='''|| p_compcode ||''' and "Retain_Code"=nvl(a."RETAINER",''0'')) AND ROWNUM<=1)
        when ''Gross'' then
        (
                 CASE to_number(nvl(a.RETAINER_COMM_AMT,0))
                 WHEN 0 THEN 0
                 ELSE (to_number(nvl(a.RETAINER_COMM_AMT,''0''))-(nvl((nvl(b."Gross_Rate",''0'')*to_number(nvl(a."ADD_AGENCY_COMM",''0''))/100),''0'')))
                 end )


         when ''Net''   then  (nvl(b."Gross_Rate",''0'')*(to_number(nvl(a.RETAINER_COMM,''0'')) )/100)
           else  (nvl(b."Gross_Rate",''0'')*(to_number(nvl(a."ADD_AGENCY_COMM",''0'')) )/100)
        END )

    ELSE (select 0  from dual)
end
,''0'')  ),''0'')),2)) as "ActualBusiness"
FROM TBL_BOOKING_MAST a,AGENCY_MAST ,TBL_BOOKING_insert b
WHERE a."Comp_code"='''||p_compcode||''' AND
a."Agency_sub_code"=AGENCY_MAST."code_subcode" AND
a."cio_booking_id"=b."Cio_Booking_Id"
and ((b."Pub_Cent_Code" in (select distinct pub_center from login_center where newuser_id='''||p_puserid||''') and '''||p_chk_access||'''=''1'')
or  ('''||p_chk_access||'''=''0'') )';


if(p_base='2')then
query3:=query3 ||' and (a."Executive_code" is not null and a."Executive_code" !=''0'')  ';
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
query3:=query3 ||' and b."Insert_Date" between  '''||p_fromdate ||''' and  '''||p_dateto||''' ';
END IF;

IF(p_publication IS NOT NULL)
THEN
query3:=query3 ||' and b."Publication_Code"='''||p_publication||'''    ';
END IF;

--old version

IF(p_pub_cent IS NOT NULL)
THEN
query3:=query3||'  and a."branch" IN (SELECT "Branch_Name" FROM BRANCH_MST WHERE a."branch"="Branch_Name" and "pub_center" in (SELECT "Pub_cent_Code" FROM PUB_CENT_MAST WHERE  branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" and "Pub_cent_Code"='''||p_pub_cent||'''))';
END IF;

IF(p_branch IS NOT NULL)
THEN
query3:=query3 ||'  and a."branch" ='''||p_branch||'''';
END IF;

--new version
/*
IF(p_pub_cent IS NOT NULL)
THEN
query3:=query3||'  and a."branch" IN (SELECT "Branch_Code" FROM BRANCH_MST WHERE a."branch"="Branch_Code" and "pub_center" in (SELECT "Pub_cent_Code" FROM PUB_CENT_MAST WHERE  branch_mst."pub_center"=pub_cent_mast."Pub_cent_Code" and "Pub_cent_Code"='''||p_pub_cent||'''))';
END IF;


IF(p_branch IS NOT NULL)
THEN
query3:=query3||'  and a."branch" = (SELECT "Branch_Code" FROM BRANCH_MST where "Branch_Name" ='''||p_branch||''') ';
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
query3:=query3 || ' and a."Executive_code" in(select exec_mast."Exe_no" from exec_mast where exec_mast."city_code" ='''||p_city||''' )';
end if;

if(p_base='3')then
query3:=query3 || ' and a.RETAINER in(select RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  RETAINERMASTER."City_Code"='''||p_city||''')';
end if;
END IF;

IF(p_zone  IS NOT NULL)
THEN
if(p_base='1')then
query3:=query3 || ' and AGENCY_MAST."zone_code" ='''||p_zone||'''';
end if;

if(p_base='2')then
query3:=query3 || ' and a."Executive_code" in(select exec_mast."Exe_no" from exec_mast where exec_mast."city_code" in (select city_mst."City_Code" from city_mst where city_mst."Zone_Code"= '''||p_zone||''') )';
end if;

if(p_base='3')then
query3:=query3 || ' and a.RETAINER in(select RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  RETAINERMASTER."Zone_Code"='''||p_zone||''')';
end if;
END IF;

IF(p_district  IS NOT NULL)
THEN
if(p_base='1')then
query3:=query3 || ' and AGENCY_MAST."Dist_Code" ='''||p_district||'''';
end if;

if(p_base='2')then
query3:=query3 || ' and a."Executive_code" in(select exec_mast."Exe_no" from exec_mast where exec_mast."dist_code" ='''||p_district||''' )';
end if;

if(p_base='3')then
query3:=query3 || ' and a.RETAINER in(select RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  RETAINERMASTER."Dist_Code"='''||p_district||''')';
end if;
END IF;

IF(p_state  IS NOT NULL)
THEN
if(p_base='1')then
query3:=query3 || ' and AGENCY_MAST."State_Code" ='''||p_state||'''';
end if;

if(p_base='2')then
query3:=query3 || ' and a."Executive_code" in(select exec_mast."Exe_no" from exec_mast where exec_mast."State_code" ='''||p_state||''' )';
end if;

if(p_base='3')then
query3:=query3 || ' and a.RETAINER in(select RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  RETAINERMASTER."State_Code"='''||p_state||''')';
end if;
END IF;

IF(p_taluka  IS NOT NULL)
THEN
if(p_base='1')then
query3:=query3 || ' and AGENCY_MAST.TALUKA='''||p_taluka||''' ';
end if;

if(p_base='2')then
query3:=query3 || ' and a."Executive_code" in(select exec_mast."Exe_no" from exec_mast where exec_mast.TALUKA ='''||p_taluka||''' )';
end if;

if(p_base='3')then
query3:=query3 || ' and a.RETAINER in(select RETAINERMASTER."Retain_Code" from  RETAINERMASTER where  RETAINERMASTER.TALUKA='''||p_taluka||''')';
end if;
END IF;

query3:=query3 || ' group by b."Insert_Date" order by "Date" ';

OPEN p_recordset1 FOR
query3;

end if;
end if;




OPEN  p_accounts FOR
SELECT to_char( SYSDATE,p_dateformat) AS "Rundate",initcap("Comp_Name") AS "companyname" from comp_mst where "Comp_Code"=p_compcode;
delete from multipack_rep where sess_id=userenv('sessionid')  ;
delete from multipack_rat where sess_id=userenv('sessionid') ;
DELETE FROM multipack_ratnew where sess_id=userenv('sessionid')  ; commit;

END ;
/

=============END===8199=====avinash===============20-aug-2012=============================
-----------------------changes given by Laxman sir(Garima)
ALTER TABLE AD_AGOMAST ADD 
CONSTRAINT ad_agomast_pk
PRIMARY KEY (COMP_CODE, UNIT_CODE, AGCODE, AGSUBCODE, FOR_MONTH)

CREATE INDEX AD_AGOMAST_IDX ON AD_AGOMAST
(COMP_CODE, UNIT_CODE, FOR_MONTH, AGCODE, AGSUBCODE)
-----------------------------------------------------------------