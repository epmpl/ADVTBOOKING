var modiflag=0;
var next = 0;
var dsexe="";
var finalvalnew="";
var view_tablename="";
var view_colname="";
var view_colvalues="";
var valueType;
var record_show1=1;
var record_show=10;
var delete_record=0;
var record_show1_other1=10;
var record_show_other=10;
var extra_record_other=0;
var check = true;
var divres="";
var flg_req;
var new_button;
var flag;
var global_ds;
var duplicacydate;
var duplicacyrate;




function form_load()
{

//    if(document.getElementById("hdn_user_right").value=="0" || document.getElementById("hdn_user_right").value=="")
//{
//alert("You are not Authorized to see this form")
//window.close();
//return false;
//}

    
    document.getElementById('btnNew').disabled = false;
    document.getElementById('btnNew').focus();
    document.getElementById('btnSave').disabled = true;
    document.getElementById('btnModify').disabled = true;
    document.getElementById('btnQuery').disabled = false;
    document.getElementById('btnExecute').disabled = true;
    document.getElementById('btnCancel').disabled = false;
    document.getElementById('btnfirst').disabled = true;
    document.getElementById('btnprevious').disabled = true;
    document.getElementById('btnnext').disabled = true;
    document.getElementById('btnlast').disabled = true;
    document.getElementById('btnDelete').disabled = true;
    document.getElementById('btnExit').disabled = false;
document.getElementById('BtnRun').disabled = true;
    
    document.getElementById('txtcompcode').disabled=true;
    document.getElementById('txtcompcode').value=document.getElementById('hdncompname').value;
    document.getElementById('txtqbccode').disabled=true;
    document.getElementById('txtqbccode').value="";
    document.getElementById('txtdate').disabled=true;
    document.getElementById('txtdate').value="";
    document.getElementById('txtbalance').disabled=true;
    document.getElementById('txtbalance').value="";
    document.getElementById('hdnagency').value="";
    
   

    
    // document.getElementById('pagingtab').style.display = 'none';
    // document.getElementById('view19').style.display = 'none';
 //document.getElementById('Button4').style.display = 'none';
//  var urights=document.getElementById('hdn_user_right').value;
//	forgiving_permision_onload(urights);

    setButtonImages();
    return false;   
}







function Newclick() 
{

   // var keycode = event.keyCode ? event.keyCode : event.which;

    document.getElementById('btnNew').disabled = true;
    document.getElementById('btnQuery').disabled = true;
    document.getElementById('btnCancel').disabled = false;
    document.getElementById('btnExit').disabled = false;
    document.getElementById('btnSave').disabled = false;
    document.getElementById('btnExecute').disabled = true;
    document.getElementById('btnfirst').disabled = true;
    document.getElementById('btnlast').disabled = true;
    document.getElementById('btnModify').disabled = true;
    document.getElementById('btnprevious').disabled = true;
    document.getElementById('btnnext').disabled = true;
    document.getElementById('btnDelete').disabled = true;
    
    document.getElementById('txtcompcode').disabled=true;
    document.getElementById('txtqbccode').disabled=false;
    document.getElementById('txtdate').disabled=false;
    document.getElementById('txtbalance').disabled=false;
  


    
     modifyduplicacydesc = "";
    document.getElementById('txtqbccode').focus();
    setButtonImages();
  
    return false;
}

function timeMsg() {
    document.getElementById('btnNew').disabled = false;
   // document.getElementById('btnNew').focus();
    document.getElementById('btnQuery').disabled = false;
    document.getElementById('btnCancel').disabled = false;
    document.getElementById('btnExit').disabled = false;
    document.getElementById('btnSave').disabled = true;
    document.getElementById('btnExecute').disabled = true;
    document.getElementById('btnfirst').disabled = true;
    document.getElementById('btnlast').disabled = true;
    document.getElementById('btnModify').disabled = true;
    document.getElementById('btnprevious').disabled = true;
    document.getElementById('btnnext').disabled = true;
    document.getElementById('btnDelete').disabled = true;
    document.getElementById('tbl_rpt').disabled = true;

//    document.getElementById('tbl_rpt').style.display = 'none';  
   // document.getElementById('Td14').style.display = 'none';
//    document.getElementById('view19').style.display = 'none';
//    document.getElementById('tbl1').style.display = 'none';
//    document.getElementById('Droprpttype').value = "ons";
//    document.getElementById('prepage').style.display='none';
//    document.getElementById('nextpage').style.display='none';
//    document.getElementById('next1').style.display='none';
    // loadXMLfor_new("xml/tv_vehicle_detail.xml")

    
    var t = setTimeout("clear_all()", 1000);
    return false;
}



function clear_all() 
{
if(flg_req=="yes")
{
timeMsg();
return false;
}
else
{
next = 0;
    srt_count = 1
    record_show1 = 1
    extra_record_other = 0;
    srt_count_0ther = 1

check = ""
    viewcolname = "";
    valueType;
    divres = "";
    dsexe = "";
    modiflag="";
    view_tablename = "";
    view_colname = "";
    view_colvalues = "";
    //document.getElementById('Td14').innerHTML = "";
//    document.getElementById('view19').innerHTML = "";
//    document.getElementById('next1').innerHTML = "";
    
     document.getElementById('txtcompcode').disabled=true;
    document.getElementById('txtcompcode').value=document.getElementById('hdncompname').value;
    document.getElementById('txtqbccode').disabled=true;
    document.getElementById('txtqbccode').value="";
    document.getElementById('txtdate').disabled=true;
    document.getElementById('txtdate').value="";
    document.getElementById('txtbalance').disabled=true;
    document.getElementById('txtbalance').value="";
   
document.getElementById('BtnRun').disabled = true;

    document.getElementById('btnNew').disabled = false;
    document.getElementById('btnNew').focus();
    document.getElementById('btnQuery').disabled = false;
    document.getElementById('btnCancel').disabled = false;
    document.getElementById('btnExit').disabled = false;
    document.getElementById('btnSave').disabled = true;
    document.getElementById('btnExecute').disabled = true;
    document.getElementById('btnfirst').disabled = true;
    document.getElementById('btnlast').disabled = true;
    document.getElementById('btnModify').disabled = true;
    document.getElementById('btnprevious').disabled = true;
    document.getElementById('btnnext').disabled = true;
    document.getElementById('btnDelete').disabled = true;
     document.getElementById('hdnagency').value="";
    //document.getElementById('view19').style.display = 'none';
    //document.getElementById('tbl1').style.display='none';
    //document.getElementById('Droprpttype').style.display = 'none';
   
  //document.getElementById('pagingtab').style.display = 'none';
 // document.getElementById('view19').style.display = 'none';
  //document.getElementById('Button4').style.display = 'none';
    
//     var urights=document.getElementById('hdn_user_right').value;
//	forgiving_permision_onload(urights);
if(document.getElementById('DataGrid1')!=null)
document.getElementById('DataGrid1').style.display = 'none';
	
	
    setButtonImages();
    flg_req="no"
    return false;
    }
}

function EnabledonQuery()
{
        
        modiflag == "";
        document.getElementById('btnNew').disabled = true;
        document.getElementById('btnSave').disabled = true;
        document.getElementById('btnModify').disabled = true;
        document.getElementById('btnQuery').disabled = true;
        document.getElementById('btnExecute').disabled = false;
        document.getElementById('btnfirst').disabled = true;
        document.getElementById('btnprevious').disabled = true;
        document.getElementById('btnnext').disabled = true;
        document.getElementById('btnlast').disabled = true;
        document.getElementById('btnDelete').disabled = true;
        document.getElementById('btnCancel').disabled = false;
        document.getElementById('btnExit').disabled = false;
        document.getElementById('btnExit').disabled = false;
        document.getElementById('BtnRun').disabled = false;
       
        document.getElementById('txtcompcode').disabled=true;
        document.getElementById('txtqbccode').disabled=false;
        document.getElementById('txtdate').disabled=false;
        document.getElementById('txtbalance').disabled=false;
        
           
         
          
     
        
       if(document.getElementById('txtqbccode').value!="")
        { 
            document.getElementById('txtqbccode').value="";
        }
    
        if(document.getElementById('txtdate').value!="")
        { 
            document.getElementById('txtdate').value="";
        }
         if(document.getElementById('txtbalance').value!="")
        { 
            document.getElementById('txtbalance').value="";
        }
         
           


        
      
      


//        document.getElementById('tbl_rpt').disabled = false;
//        document.getElementById('tbl_rpt').style.display = "block";
//        document.getElementById('Droprpttype').disabled = false;
//      

  
         setButtonImages();
         flag = "false";
        
        return false;

    }



var global_ds;
function EnableExecute(querytype) 
{
        flg_req="yes"
        next = 0;

        document.getElementById('btnNew').disabled = true;
        document.getElementById('btnQuery').disabled = true;
        document.getElementById('btnCancel').disabled = false;
        document.getElementById('btnExit').disabled = false;
        document.getElementById('btnSave').disabled = true;
        document.getElementById('btnExecute').disabled = true;
        document.getElementById('btnfirst').disabled = true;
        document.getElementById('btnlast').disabled = false;
        document.getElementById('btnModify').disabled = false;
        document.getElementById('btnprevious').disabled = true;
        document.getElementById('btnnext').disabled = false;
        document.getElementById('btnDelete').disabled = false;
//        document.getElementById('Button4').disabled = false;
document.getElementById('BtnRun').disabled = true;
        setButtonImages();
         
        document.getElementById('txtcompcode').disabled=true;
        document.getElementById('txtqbccode').disabled=true;
        document.getElementById('txtdate').disabled=true;
        document.getElementById('txtbalance').disabled=true;
       
       
         
         
         next=0
       
            
        // var uid = "'"+document.getElementById('hiddenuserid').value+"'";
         var str = document.getElementById('tblfields').value;
         var str1=str.split("$~$");
         var tablename = str1[str1.length-2];
       
         var action = str1[str1.length-1];
         var finalaction = action.split("#");
         var insert = finalaction[0];
         var update = finalaction[1];
         var del = finalaction[2];
         var select = finalaction[3];


      
                                                            
    
            var compcode = "'"+trim(document.getElementById('hdncompcode').value)+"'";
            
            
           // var vatcode = "'"+trim(document.getElementById('txtemp_name').value)+"'";
           
            
            var qbccode = "'"+trim(document.getElementById('hdnagency').value)+"'";
      
            
            var date = "'"+trim(document.getElementById('txtdate').value)+"'";
      
            
            var balance = "'"+trim(document.getElementById('txtbalance').value)+"'";
           

          
          
        
        var datef=trim(document.getElementById('hiddendateformat').value);

       var finalval = compcode + "$~$" + qbccode + "$~$" + date + "$~$" + balance;
        var fi = document.getElementById('tblfields').value.replace("$~$" + tablename, "");
        fi=fi.replace("$~$"+action,"");
        view_colname=fi;
      
        var res = Agency_CreditAmount.clie_execute(tablename, fi, finalval, select, datef,"", ""); 
        view_tablename =tablename;
        view_colvalues = finalval;

        global_ds = res.value;

        if (global_ds.Tables[0].Rows.length > 0) 
        {
            if (global_ds != null) {
              
                //binddata(global_ds);
                total_records12 = global_ds.Tables[0].Rows.length;
                if (total_records12 > 0) {
                    document.getElementById('btnnext').disabled = false;
                    document.getElementById('btnlast').disabled = false;
                }
                chk_button(total_records12);
                                    callback_execute(res);
            }
            else {
                total_records12 = "0";
            }

        }
        else {
            alert('There Is No Data Regarding Your Query');
            flg_req = "no";
            clear_all();
            return false;
        }  
        
        
       
        flg_req="no"
        return false;
}


function callback_execute(res)
{
//var urights=document.getElementById('hdn_user_right').value;
    //	        forgiving_permision_execute(urights);
   
	         setButtonImages(); 
   next=0;
   dsexe=res.value; 
    flg_req = "yes" 
   if(dsexe==null || dsexe=="null")
    {
        alert('There is no record Regarding your query')
         flg_req = "no";
         clear_all() 
        return false;
    }
  
    
    if(dsexe.Tables[0].Rows.length==1)
    {       
    
    
     document.getElementById('hdncompcode').value=dsexe.Tables[0].Rows[next].COMP_CODE

   
     
     
        if(dsexe.Tables[0].Rows[next].QBCCODE==null || dsexe.Tables[0].Rows[next].QBCCODE=="")
	    {
	    document.getElementById('txtqbccode').value="";
        }
	    else
	    {
	       document.getElementById('txtqbccode').value=agencyget(document.getElementById('hdncompcode').value,dsexe.Tables[0].Rows[next].QBCCODE);
	       document.getElementById('hdnagency').value=dsexe.Tables[0].Rows[next].QBCCODE
	      
        }


	    if(dsexe.Tables[0].Rows[next].DATETIME==null || dsexe.Tables[0].Rows[next].DATETIME=="")
	    {
	       document.getElementById('txtdate').value="";
        }
	    else
	    {
     	    document.getElementById('txtdate').value=CHKDATE(dsexe.Tables[0].Rows[next].DATETIME)
        }
	
	    if(dsexe.Tables[0].Rows[next].BALANCE==null || dsexe.Tables[0].Rows[next].BALANCE=="")
	    {
	      document.getElementById('txtbalance').value="";
        }
	    else
	    {
	      document.getElementById('txtbalance').value=dsexe.Tables[0].Rows[next].BALANCE
        }
   
       
          

	

	     setButtonImages();
	     flg_req = "no"
	     
	     return false;
    }
    
    else if(dsexe.Tables[0].Rows.length>0)
    {       
    
    
     document.getElementById('hdncompcode').value=dsexe.Tables[0].Rows[next].COMP_CODE


    
        if(dsexe.Tables[0].Rows[next].QBCCODE==null || dsexe.Tables[0].Rows[next].QBCCODE=="")
	    {
	    document.getElementById('txtqbccode').value="";
        }
	    else
	    {
	       document.getElementById('txtqbccode').value=agencyget(document.getElementById('hdncompcode').value,dsexe.Tables[0].Rows[next].QBCCODE);
	       document.getElementById('hdnagency').value=dsexe.Tables[0].Rows[next].QBCCODE
	      
        }


	    if(dsexe.Tables[0].Rows[next].DATETIME==null || dsexe.Tables[0].Rows[next].DATETIME=="")
	    {
	       document.getElementById('txtdate').value="";
        }
	    else
	    {
     	    document.getElementById('txtdate').value=CHKDATE(dsexe.Tables[0].Rows[next].DATETIME)
        }
	
	    if(dsexe.Tables[0].Rows[next].BALANCE==null || dsexe.Tables[0].Rows[next].BALANCE=="")
	    {
	      document.getElementById('txtbalance').value="";
        }
	    else
	    {
	      document.getElementById('txtbalance').value=dsexe.Tables[0].Rows[next].BALANCE
        }
   
	
	     setButtonImages();
	    
	     flg_req = "no"
	     return false;
  }


}

function chk_button(a) {
    if (global_ds.Tables[0].Rows.length == 1 || global_ds.Tables[0].Rows.length == 0) {
        document.getElementById("btnlast").disabled = true;
        document.getElementById("btnnext").disabled = true;
        document.getElementById("btnfirst").disabled = true;
        document.getElementById("btnprevious").disabled = true;
        setButtonImages();
    }
    else if (next == "0") {
        document.getElementById("btnlast").disabled = false;
        document.getElementById("btnnext").disabled = false;
        document.getElementById("btnfirst").disabled = true;
        document.getElementById("btnprevious").disabled = true;
        setButtonImages();
        return false;
    }

    else if (next == global_ds.Tables[0].Rows.length - 1) {
        document.getElementById("btnlast").disabled = true;
        document.getElementById("btnnext").disabled = true;
        document.getElementById("btnfirst").disabled = false;
        document.getElementById("btnprevious").disabled = false;
        setButtonImages();
        return false;
    }

    else {
        document.getElementById("btnlast").disabled = false;
        document.getElementById("btnnext").disabled = false;
        document.getElementById("btnfirst").disabled = false;
        document.getElementById("btnprevious").disabled = false;
        setButtonImages();
        return false;
    }

}

function chkduplicacy()
{

if (trim(document.getElementById('txtqbccode').value) == "") {
            alert("Please Enter QBC Code[F2].!")
            //document.getElementById('txtrate').value = "";
           
            document.getElementById('txtqbccode').focus();
            return false;
        }
        
        if (trim(document.getElementById('txtdate').value) == "") {
            alert("Please Enter Date.!")
            //document.getElementById('txtrate').value = "";
           
            document.getElementById('txtdate').focus();
            return false;
        }
        
        if (trim(document.getElementById('txtbalance').value) == "") {
            alert("Please Enter Balance.!")
            //document.getElementById('txtrate').value = "";
           
            document.getElementById('txtbalance').focus();
            return false;
        }

      if (trim(document.getElementById('hdnagency').value) == "") {
            alert("Please Enter QBC Code[F2].!")
            document.getElementById('txtqbccode').value = "";
           
            document.getElementById('txtqbccode').focus();
            return false;
        }



                    var tablename = "AGENCY_CREDITAMOUNT";
                    
                    var pcol1 = "QBCCODE";
                    var pcol1_val = document.getElementById('hdnagency').value;
                    var pcol2 = "DATETIME";
                    var pcol2_val = document.getElementById('txtdate').value;
                    var pcol3 = "";
                    var pcol3_val = "";
                    var pcol4 = "";
                    var pcol4_val = "";
                    var pcol5 = "";
                    var pcol5_val = "";
                    var pcol6 = "";
                    var pcol6_val = "";
                    var pcol7 = "";
                    var pcol7_val = "";
                    var pcol8 = "";
                    var pcol8_val = "";
                    var pcol9 = "";
                    var pcol9_val = "";
                    var pcol10 = "";
                    var pcol10_val = "";
                    var dateformat = document.getElementById('hiddendateformat').value;
                    var extra1 = "";
                    var extra2 = "";
                    Agency_CreditAmount.checkduplicacy(tablename, pcol1, pcol1_val, pcol2, pcol2_val, pcol3, pcol3_val, pcol4, pcol4_val, pcol5, pcol5_val, pcol6, pcol6_val, pcol7, pcol7_val, pcol8, pcol8_val, pcol9, pcol9_val, pcol10, pcol10_val, dateformat, extra1, extra2, checkforduplicacy)
                    return false;
}

function checkforduplicacy(res) {


    dsd = res.value;

    if (dsd.Tables[0].Rows.length > 0) {

        var VAL = dsd.Tables[0].Rows[0].REC_COUNT;
        if (VAL >= "1") {
            if (trim(document.getElementById('txtdate').value) == duplicacydate && trim(document.getElementById('hdnagency').value) == duplicacyrate) {
                ModifyClass()
                return false;
            }

            else {
                alert('The record already exists.Duplicacy is not Allowed.')
                document.getElementById('txtqbccode').value = "";
                document.getElementById('txtdate').value = "";
                
                //document.getElementById('txtdate').value = duplicacydate;
               // document.getElementById('txtrate').value = duplicacyrate;
                duplicacydate = document.getElementById('txtdate').value;
                duplicacyrate = document.getElementById('hdnagency').value;
                document.getElementById('txtdate').disabled = false;
                document.getElementById('txtqbccode').disabled = false;
                
                document.getElementById('txtqbccode').focus();
                return false;
            }

        }

        else if (document.getElementById('btnSave').disabled == false) {
            if (modiflag == 1) {
                ModifyClass();
                return false;
            }
            else {
                callback_savedata();
                return false;
            }
        }

    }
    else {


        if (modiflag == 1) {
            ModifyClass();
            return false;
        }
        else {
            callback_savedata();
            return false;
        }
    }


}








function callback_savedata()
{   
   //ds=rec.value;

   if(modiflag==1)
   {
       ModifyClass();
       return false;
   }
   else
   {     
         //document.getElementById('txtCode').value=ds.Tables[0].Rows[0].IDNO;
//         var uid = "'"+document.getElementById('hiddenuserid').value+"'";
         var str=document.getElementById ('tblfields').value;
         var str1=str.split("$~$");
         var tablename = str1[str1.length-2];
        
         var action = str1[str1.length-1];
         var finalaction = action.split("#");
         var insert = finalaction[0];
         var update = finalaction[1];
         var del = finalaction[2];
         var select = finalaction[3];
   
       
          document.getElementById('btnSave').focus();
          



  if (trim(document.getElementById('txtqbccode').value) == "") {
            alert("Please Enter QBC Code[F2].!")
            //document.getElementById('txtrate').value = "";
           
            document.getElementById('txtqbccode').focus();
            return false;
        }
        
        if (trim(document.getElementById('txtdate').value) == "") {
            alert("Please Enter Date.!")
            //document.getElementById('txtrate').value = "";
           
            document.getElementById('txtdate').focus();
            return false;
        }
        
        if (trim(document.getElementById('txtbalance').value) == "") {
            alert("Please Enter Balance.!")
            //document.getElementById('txtrate').value = "";
           
            document.getElementById('txtbalance').focus();
            return false;
        }

      if (trim(document.getElementById('hdnagency').value) == "") {
            alert("Please Enter QBC Code[F2].!")
            document.getElementById('txtqbccode').value = "";
           
            document.getElementById('txtqbccode').focus();
            return false;
        }
 
          
          
           var compcode = "'"+trim(document.getElementById('hdncompcode').value)+"'";
            
            
           // var vatcode = "'"+trim(document.getElementById('txtemp_name').value)+"'";
           var datef = trim(document.getElementById('hiddendateformat').value);
            
            var qbccode = "'"+trim(document.getElementById('hdnagency').value)+"'";
            var date =  trim(document.getElementById('txtdate').value);
            if (document.getElementById('hiddenconnection').value == "mysql") {
                var dd = date.split("/")[0];
                var mm = date.split("/")[1];
                var yy = date.split("/")[2];
                date = "'" + trim( yy + "/" + mm + "/" + dd) + "'";
                datef = "yyyy/mm/dd";
            }
          
      
            
            var balance = "'"+trim(document.getElementById('txtbalance').value)+"'";
       
            
           
          
          
        
       

        var finalvalue = compcode + "$~$" + qbccode + "$~$" + date + "$~$" + balance;
              
       
        var fi=document.getElementById('tblfields').value.replace("$~$"+tablename,"")
        fi=fi.replace("$~$"+action,"")
        
        var result=Agency_CreditAmount.Savename(fi,finalvalue,tablename,insert,datef,"","")
//var result=Agency_CreditAmount.savedata(fi,finalvalue,tablename,insert,datef)
       
       
        if(result.value=="true")
        {      
           // document.getElementById('txtvehicle_no').value=num;
            alert(" Data saved successfully.!");
            if(confirm("Do you want to print this page ?"))
             {
               chkfrrun();
               return false;
             }
               clear_all();
               return false;
        }
        else
        {
            var exalert= result.value;
            var exalert1= exalert.split("-");
            if(exalert1.indexOf("ORA")>=0)
            {
                if(exalert1[1].indexOf("06502")>=0)
                {
                    alert("Data Not Saved.Please enter 499 characters only.")
                    
                    document.getElementById('btnNew').focus(); 
                    return false;
                }
            }
                
        }
       return false; 
    }
}


//var duplicacyrate="";
//var duplicacydate="";

function Modify_Records()
{
        modiflag=1;

        document.getElementById('btnQuery').disabled = true;
        document.getElementById('btnSave').disabled = false;
        document.getElementById('btnfirst').disabled = true;
        document.getElementById('btnlast').disabled = true;
        document.getElementById('btnModify').disabled = true;
        document.getElementById('btnprevious').disabled = true;
        document.getElementById('btnnext').disabled = true;
        document.getElementById('btnDelete').disabled = true;
        
        setButtonImages();
        
//        document.getElementById('drpType').disabled=false;
//        document.getElementById('txtCode').disabled=true;
//        document.getElementById('txtName').disabled = false;

        
        document.getElementById('txtcompcode').disabled=true;
        document.getElementById('txtqbccode').disabled=true;
        document.getElementById('txtdate').disabled=true;
        document.getElementById('txtbalance').disabled=false;
       
        document.getElementById('btnSave').focus();
        
        duplicacyrate = document.getElementById('hdnagency').value;
        duplicacydate = document.getElementById('txtdate').value;
        
//        document.getElementById('txtrate').value = duplicacyrate;
//        document.getElementById('txtdate').value = duplicacydate;
       //new_button("Modify");
       return false;
}


function ModifyClass()
{
    modiflag=1;
    var str = document.getElementById('tblfields').value;
    var str1=str.split("$~$");
    var tablename = str1[str1.length-2];
    var action = str1[str1.length-1];
    var finalaction = action.split("#");
    var insert = finalaction[0];
    var update = finalaction[1];
    var del = finalaction[2];
    var select = finalaction[3];




 
    var modcolname="";
        modcolname =document.getElementById('hiddennochangecode').value;
        modcolname=modcolname+"$~$" 
    
           
             var compcode = "'"+trim(document.getElementById('hdncompcode').value)+"'";
            
            
           // var vatcode = "'"+trim(document.getElementById('txtemp_name').value)+"'";
           
            
            var qbccode = "'"+trim(document.getElementById('hdnagency').value)+"'";
      
            
            var date = "'"+trim(document.getElementById('txtdate').value)+"'";
      
            
            var balance = "'"+trim(document.getElementById('txtbalance').value)+"'";
       
            

          
          
        
        var dateformat=trim(document.getElementById('hiddendateformat').value);
        if (document.getElementById('hiddenconnection').value == "mysql") {
            var dd = date.split("/")[0];
            var mm = date.split("/")[1];
            var yy = date.split("/")[2];
            //date = "'" + trim(yy + "/" + mm + "/" + dd) + "'";
            date = yy.replace("'","") + "/" + mm.replace("'","") + "/" + dd.replace("'","");
            date ="'" +date+"'";
            dateformat = "yyyy/mm/dd";
        }
        var finalval = compcode + "$~$" + qbccode + "$~$" + date + "$~$" + balance + "$~$";
        var fi=document.getElementById('tblfields').value.replace("$~$"+tablename,"");
    fi = fi.replace("$~$" + action, "");
    fi = fi + "$~$";

    var wherecondition=name;
    
    var res = Agency_CreditAmount.tal_modify(fi, finalval,tablename,update,modcolname,dateformat,"","");
    var result=res.value;
        if(result!="true")
     {
          if(result.split("(")[0] == "ORA-00001: unique constraint ")
          {
                    alert('This combination already exists, please enter some other combination.');
                    return false;         
          }
         
           
      }
       else
          {
                alert('Data Updated Successfully')
                 clear_all();
                return false;
          }

    
 }




function Find_NextRecord() {


    next++;
    
   var record= dsexe.Tables[0].Rows.length;
   chk_button(record);
if(next<=record && next>=0)
{
 if(dsexe.Tables[0].Rows.length != next && next !=-1)
 {
	 document.getElementById('hdncompcode').value=dsexe.Tables[0].Rows[next].COMP_CODE
     
     
     
     
        if(dsexe.Tables[0].Rows[next].QBCCODE==null || dsexe.Tables[0].Rows[next].QBCCODE=="")
	    {
	    document.getElementById('txtqbccode').value="";
        }
	    else
	    {
	       document.getElementById('txtqbccode').value=agencyget(document.getElementById('hdncompcode').value,dsexe.Tables[0].Rows[next].QBCCODE);
	       document.getElementById('hdnagency').value=dsexe.Tables[0].Rows[next].QBCCODE
	      
        }


	    if(dsexe.Tables[0].Rows[next].DATETIME==null || dsexe.Tables[0].Rows[next].DATETIME=="")
	    {
	       document.getElementById('txtdate').value="";
        }
	    else
	    {
     	    document.getElementById('txtdate').value=CHKDATE(dsexe.Tables[0].Rows[next].DATETIME)
        }
	
	    if(dsexe.Tables[0].Rows[next].BALANCE==null || dsexe.Tables[0].Rows[next].BALANCE=="")
	    {
	      document.getElementById('txtbalance').value="";
        }
	    else
	    {
	      document.getElementById('txtbalance').value=dsexe.Tables[0].Rows[next].BALANCE
        }
        document.getElementById('btnNew').disabled = true;
        document.getElementById('btnQuery').disabled = false;
        document.getElementById('btnCancel').disabled = false;
        document.getElementById('btnExit').disabled = false;
        document.getElementById('btnSave').disabled = true;
        document.getElementById('btnExecute').disabled = true;
        document.getElementById('btnfirst').disabled = false;
        document.getElementById('btnlast').disabled = false;
        document.getElementById('btnModify').disabled = false;
        document.getElementById('btnprevious').disabled = false;
        document.getElementById('btnnext').disabled = false;
        
       
	}
  }
     
     if(next==record-1 )
     {


        document.getElementById('btnNew').disabled = true;
        document.getElementById('btnQuery').disabled = false;
        document.getElementById('btnCancel').disabled = false;
        document.getElementById('btnExit').disabled = false;
        document.getElementById('btnSave').disabled = true;
        document.getElementById('btnExecute').disabled = true;
        document.getElementById('btnfirst').disabled = false;
        document.getElementById('btnlast').disabled = true;
        document.getElementById('btnModify').disabled = false;
        document.getElementById('btnprevious').disabled = false;
        document.getElementById('btnnext').disabled = true;
         
    
         document.getElementById('btnprevious').focus();                  

     }
     
     setButtonImages();
   return false;
   
}

////////////////////////////////// Previous button //////////////////////////////////

function Find_PreRecord() {



    next--;
    chk_button(next);
   
    var record= dsexe.Tables[0].Rows.length;
    if(next>record)
	{
	
			
			document.getElementById('btnfirst').disabled=false;				
			document.getElementById('btnprevious').disabled=false;			
			document.getElementById('btnnext').disabled=true;					
			document.getElementById('btnlast').disabled=false;
			
			
			return false;
			
	}
     
     
if(next!=-1 && next>=0)
{
  if(dsexe.Tables[0].Rows.length != next)
  {
			      
	 document.getElementById('hdncompcode').value=dsexe.Tables[0].Rows[next].COMP_CODE
     
     
     
     
        if(dsexe.Tables[0].Rows[next].QBCCODE==null || dsexe.Tables[0].Rows[next].QBCCODE=="")
	    {
	    document.getElementById('txtqbccode').value="";
        }
	    else
	    {
	       document.getElementById('txtqbccode').value=agencyget(document.getElementById('hdncompcode').value,dsexe.Tables[0].Rows[next].QBCCODE);
	       document.getElementById('hdnagency').value=dsexe.Tables[0].Rows[next].QBCCODE
	      
        }


	    if(dsexe.Tables[0].Rows[next].DATETIME==null || dsexe.Tables[0].Rows[next].DATETIME=="")
	    {
	       document.getElementById('txtdate').value="";
        }
	    else
	    {
     	    document.getElementById('txtdate').value=CHKDATE(dsexe.Tables[0].Rows[next].DATETIME)
        }
	
	    if(dsexe.Tables[0].Rows[next].BALANCE==null || dsexe.Tables[0].Rows[next].BALANCE=="")
	    {
	      document.getElementById('txtbalance').value="";
        }
	    else
	    {
	      document.getElementById('txtbalance').value=dsexe.Tables[0].Rows[next].BALANCE
        }
       
      document.getElementById('btnnext').disabled = false;
      document.getElementById('btnprevious').disabled=false;
      document.getElementById('btnlast').disabled=false;
   }      
      	                  
    setButtonImages();
}
     if (next==0)
     {
          document.getElementById('btnfirst').disabled = true;
          document.getElementById('btnprevious').disabled = true;
          document.getElementById('btnlast').disabled=false;
          document.getElementById('btnnext').disabled=false;
           setButtonImages();
          document.getElementById('btnnext').focus();
           
     }
     
     setButtonImages();  
   return false;
  
   
}

function Find_FirstRecord()
{

    next = 0;
    chk_button(next);
     document.getElementById('hdncompcode').value=dsexe.Tables[0].Rows[next].COMP_CODE
     
     
     
     
        if(dsexe.Tables[0].Rows[next].QBCCODE==null || dsexe.Tables[0].Rows[next].QBCCODE=="")
	    {
	    document.getElementById('txtqbccode').value="";
        }
	    else
	    {
	       document.getElementById('txtqbccode').value=agencyget(document.getElementById('hdncompcode').value,dsexe.Tables[0].Rows[next].QBCCODE);
	       document.getElementById('hdnagency').value=dsexe.Tables[0].Rows[next].QBCCODE
	      
        }


	    if(dsexe.Tables[0].Rows[next].DATETIME==null || dsexe.Tables[0].Rows[next].DATETIME=="")
	    {
	       document.getElementById('txtdate').value="";
        }
	    else
	    {
     	    document.getElementById('txtdate').value=CHKDATE(dsexe.Tables[0].Rows[next].DATETIME)
        }
	
	    if(dsexe.Tables[0].Rows[next].BALANCE==null || dsexe.Tables[0].Rows[next].BALANCE=="")
	    {
	      document.getElementById('txtbalance').value="";
        }
	    else
	    {
	      document.getElementById('txtbalance').value=dsexe.Tables[0].Rows[next].BALANCE
        }
          document.getElementById('btnnext').disabled = false;
          document.getElementById('btnfirst').disabled = true;
          document.getElementById('btnprevious').disabled = true;
          document.getElementById('btnlast').disabled=false;
          setButtonImages();
          document.getElementById('btnnext').focus();
          
          return false;
}


function Find_LastRecord()
{
   
    var record=dsexe.Tables[0].Rows.length;
		 next=record-1;
		 record = record - 1;
		 chk_button(next);
  document.getElementById('hdncompcode').value=dsexe.Tables[0].Rows[next].COMP_CODE
     
     
     
     
        if(dsexe.Tables[0].Rows[next].QBCCODE==null || dsexe.Tables[0].Rows[next].QBCCODE=="")
	    {
	    document.getElementById('txtqbccode').value="";
        }
	    else
	    {
	       document.getElementById('txtqbccode').value=agencyget(document.getElementById('hdncompcode').value,dsexe.Tables[0].Rows[next].QBCCODE);
	       document.getElementById('hdnagency').value=dsexe.Tables[0].Rows[next].QBCCODE
	      
        }


	    if(dsexe.Tables[0].Rows[next].DATETIME==null || dsexe.Tables[0].Rows[next].DATETIME=="")
	    {
	       document.getElementById('txtdate').value="";
        }
	    else
	    {
     	    document.getElementById('txtdate').value=CHKDATE(dsexe.Tables[0].Rows[next].DATETIME)
        }
	
	    if(dsexe.Tables[0].Rows[next].BALANCE==null || dsexe.Tables[0].Rows[next].BALANCE=="")
	    {
	      document.getElementById('txtbalance').value="";
        }
	    else
	    {
	      document.getElementById('txtbalance').value=dsexe.Tables[0].Rows[next].BALANCE
        }

        document.getElementById('btnCancel').disabled = false;
        document.getElementById('btnExit').disabled = false;

        document.getElementById('btnfirst').disabled = false;
        document.getElementById('btnlast').disabled = true;
   
        document.getElementById('btnprevious').disabled = false;
        document.getElementById('btnnext').disabled = true;
        setButtonImages();
        document.getElementById('btnprevious').focus(); 
        return false;
}





			

var viewcolname="";
var valueType

function Delete_Record()
{

//       document.getElementById('Td14').style.display = 'none';
//       document.getElementById('view19').style.display = 'none';
//       document.getElementById('prepage').style.display = 'none';
//       document.getElementById('nextpage').style.display = 'none';
//       document.getElementById('next1').style.display='none';
//       document.getElementById('Button4').disabled= true;

        var str2 = document.getElementById('deltblfields').value;
        var str3=str2.split("$~$");
        var delcolname="";
        var deltblname=str3[str3.length-2];
            
        //delcolname=str2.replace("document.getElementById~document.getElementById"+deltblname,"")
        delcolname="COMP_CODE$~$QBCCODE$~$DATETIME$~$";
       
        var code="'"+trim(document.getElementById('hdncompcode').value)+"'";
        var qbccode="'"+document.getElementById('hdnagency').value+"'"
        var date="'"+document.getElementById('txtdate').value+"'"
        
         var datef=trim(document.getElementById('hiddendateformat').value);
        
        
        var delcolvalue=code + "$~$" + qbccode + "$~$" + date + "$~$";
        
        boolReturn = confirm("Do you want to delete this record?");
        if (boolReturn==1)
        {
          //Agency_CreditAmount.deletedata(delcolname,delcolvalue,deltblname,"delete", "", datef);
          Agency_CreditAmount.tal_delete(deltblname,delcolname,delcolvalue,"delete",datef,"","")
           //Agency_CreditAmount.tal_delete(delcolname,delcolvalue,deltblname,"delete", "", datef);
          
          alert("Data Deleted Successfully.");
          clear_all();
          return false;
	    }
		else
		{
		   document.getElementById('btnDelete').focus();
		   return false;
		}
    
   return false;
}





function F2fillagencycr_allagency(event) {
    var key = event.keyCode ? event.keyCode : event.which;
    if (key == 113|| key == 35)
{
    if(document.activeElement.id=="txtqbccode")
        {       
            //$('txtagency').value="";
            var compcode =document.getElementById('hdncompcode').value;
            var agn =document.getElementById('txtqbccode').value;
            document.getElementById("div1").style.display="block";
            document.getElementById('div1').style.top=215+ "px" ;//314//290
            document.getElementById('div1').style.left=580+ "px";//395//1004
            document.getElementById('lstagency').focus();
            Agency_CreditAmount.fillF2_CreditAgency(compcode,agn,bindAgency_callback1);
      }
    }

    
 else if (((key == 8) || (key == 46)) || (event.ctrlKey == true && key == 88)) 
    {

        if (document.activeElement.id == "txtqbccode")
         {
            document.getElementById('txtqbccode').value = "";
            document.getElementById('hdnagency').value = "";

            //saveagencycode = "";
            //saveagencyname = "";
            //savedpcdcode = "";


            return false;
        }
        return key;
    }
 
 
 
 
 
 

}
function bindAgency_callback1(res)
{
     var ds_AccName=res.value;
      
        if(ds_AccName!= null && typeof(ds_AccName) == "object" && ds_AccName.Tables[0].Rows.length > 0) 
        {
            var pkgitem = document.getElementById("lstagency");
            pkgitem.options.length = 0; 
            pkgitem.options[0]=new Option("-Select Agency Name-","0");
            pkgitem.options.length = 1; 
            for (var i = 0  ;  i < ds_AccName.Tables[0].Rows.length;  ++i)
            {
                pkgitem.options[pkgitem.options.length] = new Option(ds_AccName.Tables[0].Rows[i].Agency_Name,ds_AccName.Tables[0].Rows[i].code_subcode);         
                pkgitem.options.length;
            }
        }
        
             var   aTag = eval(document.getElementById('txtqbccode'))
        var btag;
                 var leftpos = 0;
                 var toppos = 0;
                 do {
                     aTag = eval(aTag.offsetParent);
                     leftpos += aTag.offsetLeft;
                     toppos += aTag.offsetTop;
                     btag = eval(aTag)
                 } while (aTag.tagName != "BODY" && aTag.tagName != "HTML");
                 var tot = document.getElementById('div1').scrollLeft;
                 var scrolltop = document.getElementById('div1').scrollTop;
                 document.getElementById('div1').style.left = document.getElementById('txtqbccode').offsetLeft + leftpos - tot + "px";
                 document.getElementById('div1').style.top = document.getElementById('txtqbccode').offsetTop + toppos - scrolltop + "px"; //"510px";
        
        
        
        document.getElementById("lstagency").value="0";
        document.getElementById("div1").value="";
        document.getElementById('lstagency').focus();
        //alert(ds_AccName.Tables[0].Rows[i].Agency_Name)
        return false;

}


function ClickAgaency1(event) {
    var key = event.keyCode ? event.keyCode : event.which;
    if (key == 13 || event.type == "click")
    {
        if(document.activeElement.id=="lstagency")
        {
        if(document.getElementById('lstagency').value=="0")
            {
                 alert("Please select Agency Name");
                 return false;
            }
            
            var page = document.getElementById('lstagency').value;
            agencycode = page;
            for(var k=0;k<=document.getElementById('lstagency').length-1;k++)
            {   
                if(document.getElementById('lstagency').options[k].value==page)
                {if (browser != "Microsoft Internet Explorer") {
                        var abc = document.getElementById('lstagency').options[k].textContent;
                    }
                    else {
                        var abc = document.getElementById('lstagency').options[k].innerText;
                    }
                    document.getElementById('txtqbccode').value = abc;
                    //document.getElementById('hdnagencytxt').value =abc;
                    document.getElementById('hdnagency').value =page;
                    
                    document.getElementById("div1").style.display="none";
                    document.getElementById('txtqbccode').focus();
                     return false; 
                    
                }
            }
        }
      }
      else if (key == 27||key == 42)
         {
         
        document.getElementById("div1").style.display="none";
        document.getElementById('txtqbccode').focus();
      }
      else if (key == 56)
      {
          document.getElementById("div1").style.display = "none";
          document.getElementById('txtqbccode').focus();
      }
  }







function Exit()
{
   if(confirm("Do you want to skip this page ?"))
     {
       window.close();
       return false;
     }
    return false;
    
}


function chkfld(a)
{
var browser=navigator.appName;
if(browser!="Microsoft Internet Explorer")
{
    
   
             if((a.which=="13" || a.which=="9") && document.activeElement.id=="txtqbccode"  && document.getElementById('btnSave').disabled ==false && document.getElementById('btnCancel').disabled == false && document.getElementById('btnExit').disabled == false )
                    {
                        if(document.getElementById('txtqbccode').value=="" || document.getElementById('txtqbccode').value!="")
                            {
                                if( a.which=="13")
                                    {
                                        if(document.getElementById('txtqbccode').value=="")
                                            {
                                                alert('Please  Enter QBC Code[F2].!');
                                                return false;
                                            }
                                            else
                                                {
                                                    document.getElementById('txtdate').focus();
                                                    return false;
                                                }
                                    }
                    }
            }       
         else if((a.which=="13" || a.which=="9") && document.activeElement.id=="txtdate"  && document.getElementById('btnSave').disabled ==false && document.getElementById('btnCancel').disabled == false && document.getElementById('btnExit').disabled == false )
                {
                    if(document.getElementById('txtdate').value=="" || document.getElementById('txtdate').value!="")
                        {
                            if( a.which=="13")
                                {
                                    if(document.getElementById('txtdate').value=="")
                                        {
                                            alert('Please Enter Date!');
                                            return false;
                                        }
                                        else
                                            {
                                                document.getElementById('txtbalance').focus();
                                               
                                                return false;
                                            }
                                  }
                         }
                 } 
                 
             else if((a.which=="13" || a.which=="9") && document.activeElement.id=="txtbalance"  && document.getElementById('btnSave').disabled ==false && document.getElementById('btnCancel').disabled == false && document.getElementById('btnExit').disabled == false )
                {
                    if(document.getElementById('txtbalance').value=="" || document.getElementById('txtbalance').value!="")
                        {
                            if( a.which=="13")
                                {
                                    if(document.getElementById('txtbalance').value=="")
                                        {
                                            alert('Please Enter Balance');
                                            return false;
                                        }
                                        else
                                            {
                                                document.getElementById('btnSave').focus();
                                              
                                                return false;
                                            }
                                  }
                         }
                 }   
                 
             
                     
                     

      

                     
            else if (document.activeElement.id=="btnSave")
            {
                chkduplicacy();
                return false;
            }                
            else if(a.which=="13" && document.activeElement.id=="btnExecute")
            {
                EnableExecute();
                return false;
            }

     
            
            }
            
            else
            {
            
     
               if((a.keyCode=="13" || a.keyCode=="9") && document.activeElement.id=="txtqbccode"  && document.getElementById('btnSave').disabled ==false && document.getElementById('btnCancel').disabled == false && document.getElementById('btnExit').disabled == false )
                    {
                        if(document.getElementById('txtqbccode').value=="" || document.getElementById('txtqbccode').value!="")
                            {
                                if( a.keyCode=="13")
                                    {
                                        if(document.getElementById('txtqbccode').value=="")
                                            {
                                                alert('Please  Enter QBC Code[F2].!');
                                                return false;
                                            }
                                            else
                                                {
                                                    document.getElementById('txtdate').focus();
                                                    return false;
                                                }
                                    }
                    }
            }       
         else if((a.keyCode=="13" || a.keyCode=="9") && document.activeElement.id=="txtdate"  && document.getElementById('btnSave').disabled ==false && document.getElementById('btnCancel').disabled == false && document.getElementById('btnExit').disabled == false )
                {
                    if(document.getElementById('txtdate').value=="" || document.getElementById('txtdate').value!="")
                        {
                            if( a.keyCode=="13")
                                {
                                    if(document.getElementById('txtdate').value=="")
                                        {
                                            alert('Please Enter Date!');
                                            return false;
                                        }
                                        else
                                            {
                                                document.getElementById('txtbalance').focus();
                                               
                                                return false;
                                            }
                                  }
                         }
                 } 
                 
             else if((a.keyCode=="13" || a.keyCode=="9") && document.activeElement.id=="txtbalance"  && document.getElementById('btnSave').disabled ==false && document.getElementById('btnCancel').disabled == false && document.getElementById('btnExit').disabled == false )
                {
                    if(document.getElementById('txtbalance').value=="" || document.getElementById('txtbalance').value!="")
                        {
                            if( a.keyCode=="13")
                                {
                                    if(document.getElementById('txtbalance').value=="")
                                        {
                                            alert('Please Enter Balance');
                                            return false;
                                        }
                                        else
                                            {
                                                document.getElementById('btnSave').focus();
                                              
                                                return false;
                                            }
                                  }
                         }
                 }   
                 
            
            else if (document.activeElement.id=="btnSave")
            {
                chkduplicacy();
                return false;
            }                
            else if(a.keyCode=="13" && document.activeElement.id=="btnExecute")
            {
                EnableExecute();
                return false;
            }

     
            }
            
            
            }
    



function setButtonImages()
{
     if(document.getElementById('btnNew').disabled==true)
        document.getElementById('btnNew').src="btimages/new-off.jpg";
    else
        document.getElementById('btnNew').src="btimages/new.jpg";
        
    if(document.getElementById('btnSave').disabled==true)
        document.getElementById('btnSave').src="btimages/save-off.jpg";
    else
        document.getElementById('btnSave').src="btimages/save.jpg";
        
    if(document.getElementById('btnModify').disabled==true)
        document.getElementById('btnModify').src="btimages/modify-off.jpg";
    else
        document.getElementById('btnModify').src="btimages/modify.jpg";
        
    if(document.getElementById('btnQuery').disabled==true)
        document.getElementById('btnQuery').src="btimages/query-off.jpg";
    else
        document.getElementById('btnQuery').src="btimages/query.jpg";
    
    if(document.getElementById('btnExecute').disabled==true)
        document.getElementById('btnExecute').src="btimages/execute-off.jpg";
    else
        document.getElementById('btnExecute').src="btimages/execute.jpg";
        
    if(document.getElementById('btnCancel').disabled==true)
        document.getElementById('btnCancel').src="btimages/clear-off.jpg";
    else
        document.getElementById('btnCancel').src="btimages/clear.jpg";
        
    if(document.getElementById('btnfirst').disabled==true)
        document.getElementById('btnfirst').src="btimages/first-off.jpg";
    else
        document.getElementById('btnfirst').src="btimages/first.jpg";
        
    if(document.getElementById('btnprevious').disabled==true)
        document.getElementById('btnprevious').src="btimages/previous-off.jpg";
    else
        document.getElementById('btnprevious').src="btimages/previous.jpg";
        
    if(document.getElementById('btnnext').disabled==true)
        document.getElementById('btnnext').src="btimages/next-off.jpg";
    else
        document.getElementById('btnnext').src="btimages/next.jpg";
        
    if(document.getElementById('btnlast').disabled==true)
        document.getElementById('btnlast').src="btimages/last-off.jpg";
    else
        document.getElementById('btnlast').src="btimages/last.jpg";   
        
    if(document.getElementById('btnDelete').disabled==true)
        document.getElementById('btnDelete').src="btimages/delete-off.jpg";
    else
        document.getElementById('btnDelete').src="btimages/delete.jpg";
        
    if(document.getElementById('btnExit').disabled==true)
        document.getElementById('btnExit').src="btimages/exit-off.jpg";
    else
        document.getElementById('btnExit').src="btimages/exit.jpg";       
        
}

/////////////////////////////check special character function////////////////////////////////////////
var splitsign=0;
var greatersign=0;
var sql_inject=0;
var unicodespl="";
function chksplchar(a,b)
{
    unicodespl=b;
    var result="false";
    var code="abcdefghijklmnopqrstuvwxyz0123456789"
    var myval=b;
    if(b=="")
    {
         return true;
    }

    if(b.indexOf("document.getElementById~document.getElementById")>=0)
    {
        splitsign=1;
        return result
    }
    if(b.indexOf("^")>=0)
    {
        splitsign=1;
        return result
    }
    if(b.indexOf("<")>=0||b.indexOf(">")>=0 || b.indexOf("&lt;")>=0 || b.indexOf("&LT;")>=0 || b.indexOf("&gt;")>=0 || b.indexOf("&GT;")>=0 || b.indexOf("&lt")>=0 || b.indexOf("&LT")>=0 || b.indexOf("&gt")>=0 || b.indexOf("&GT")>=0)
    {
        greatersign=1;
        return result
    }

    if(b.indexOf("select ")>=0 ||b.indexOf("SELECT ")>=0 || b.indexOf("update ")>=0 || b.indexOf("UPDATE ")>=0 || b.indexOf("insert ")>=0 || b.indexOf("INSERT ")>=0 || b.indexOf("delete ")>=0 || b.indexOf("DELETE ")>=0)
    {
        sql_inject=1;
        return result
    }

        code=code.toLowerCase()
        myval=myval.toLowerCase()
    for(i=0;i<=myval.length-1;i++)
    {
        for(j=0;j<=code.length-1;j++)
        {
            if(myval.charAt(i)==code.charAt(j))
            {
            result="true";
            break;
            }
        }
    }
    if(myval.length=="0")
    {
        return "true";
    }
    if(result=="false")
    {
        alert('You cannot enter special character in the text field');
        document.getElementById(a).focus();
        return false
    }
    else
    {
        return b;
    }
}

///////////////////////////////////

function repalcesinglequote(val)
{
    if(val.indexOf("'")>=0)
    {
        while(val.indexOf("'")>=0)
        {
            val=val.replace("'","^");
        }
    }
    return val;
}


function repalcestr2quote(val)
{
    if(val!=null)
    {
         if(val.indexOf("^")>=0)
        {
            while(val.indexOf("^")>=0)
            {
                val=val.replace("^","'");
            }
        }
        return val;
    }
}

function trim(stringToTrim) 
{
  return stringToTrim.replace(/^\s+|\s+document.getElementById/g,"");
}




function CHKDATE(userdate)
{
    var mycondate = ""
    var new_date = userdate;
   
if(userdate==null || userdate=="")
{
    mycondate=""
    return mycondate
}
else
{

      var dateformate = document.getElementById('hiddendateformat').value;
      if(document.getElementById('hiddendateformat').value=="dd/mm/yyyy")
        {
        var spmonth = "'"+userdate+"'";
        var pp = spmonth.split(" ");
        var mon = pp[1];
        var myDate=new Date(userdate);
        var date = myDate.getDate();
        
        if(date==1 || date==2 || date==3 || date==4 || date==5 || date==6 || date==7 || date==8 || date==9)
        date = "0"+date;
        var month = myDate.getMonth()+1;
        if(month==1 || month==2 || month==3 || month==4 || month==5 || month==6 || month==7 || month==8 || month==9)
        month = "0" + month;
        var year = myDate.getFullYear();
        mycondate=date+"/"+month+"/"+year;
        new_date = mycondate;
        validdate = new_date;
        return mycondate;
        }
        else if(document.getElementById('hiddendateformat').value=="mm/dd/yyyy")
        {
            var spmonth = "'"+userdate+"'";
            var pp = spmonth.split(" ");
            var mon = pp[1];
            var myDate=new Date(userdate);
            var date = myDate.getDate();
            var month = myDate.getMonth()+1;
            var year = myDate.getFullYear();
            mycondate=month+"/"+date+"/"+year;
            new_date = mycondate;
            validdate = new_date;
            return mycondate;
        }
        else if(document.getElementById('hiddendateformat').value=="yyyy/mm/dd")
        {
            var spmonth = "'"+userdate+"'";
            var pp = spmonth.split(" ");
            var mon = pp[1];
            var myDate=new Date(userdate);
            var date = myDate.getDate();
            var month = myDate.getMonth()+1;
            var year = myDate.getFullYear();
            mycondate=year+"/"+month+"/"+date;
            new_date = mycondate;
            validdate = new_date;
            
            return mycondate;
        }
   
}
}



function isDatevat(dtStr,txtid,dateformat,hiddenvalue)
{ 
    if(trim(document.getElementById(txtid).value)=="")
    {
        document.getElementById(txtid).value="";
        return false;
    }

    else
    {           
         if(document.getElementById(dateformat=="mm/dd/yyyy"))
         {                       
            var daysInMonth = DaysArray(12);
            var pos1=dtStr.indexOf(dtCh);
            var pos2=dtStr.indexOf(dtCh,pos1+1);
            var strMonth=dtStr.substring(0,pos1);
            var strDay=dtStr.substring(pos1+1,pos2);
            var strYear=dtStr.substring(pos2+1);
            strYr=strYear;
            if (strDay.charAt(0)=="0" && strDay.length>1) strDay=strDay.substring(1)
            if (strMonth.charAt(0)=="0" && strMonth.length>1) strMonth=strMonth.substring(1)
            for (var i = 1; i <= 3; i++) 
            {
                if (strYr.charAt(0)=="0" && strYr.length>1) strYr=strYr.substring(1)
            }
            month=parseInt(strMonth);
            day=parseInt(strDay);
            year=parseInt(strYr);
            if (pos1==-1 || pos2==-1)
            {
                alert("The date format should be : mm/dd/yyyy")
                chk_user_flag="true"
                document.getElementById(txtid).value="";
                document.getElementById(txtid).focus();
                return false;
            }
         }
	
	
         else if((dateformat=="dd/mm/yyyy"))
         {
            var daysInMonth = DaysArray(12);
            var pos1=dtStr.indexOf(dtCh);
            var pos2=dtStr.indexOf(dtCh,pos1+1);
            var strDay=dtStr.substring(0,pos1);
            var strMonth=dtStr.substring(pos1+1,pos2);
            var strYear=dtStr.substring(pos2+1);
            strYr=strYear;
            if (strMonth.charAt(0)=="0" && strMonth.length>1) strMonth=strMonth.substring(1)
            if (strDay.charAt(0)=="0" && strDay.length>1) strDay=strDay.substring(1)
            for (var i = 1; i <= 3; i++) 
            {
	            if (strYr.charAt(0)=="0" && strYr.length>1) strYr=strYr.substring(1)
            }
            day=parseInt(strDay);
            month=parseInt(strMonth);
            year=parseInt(strYr);
            if (pos1==-1 || pos2==-1)
            {
	            alert("The date format should be : dd/mm/yyyy")
	            chk_user_flag="true"
	            document.getElementById(txtid).value="";
	           document.getElementById(txtid).focus();
	            return false;
            }
           
         }
                 
         else
         {
            var daysInMonth = DaysArray(12);
            var pos1=dtStr.indexOf(dtCh);
            var pos2=dtStr.indexOf(dtCh,pos1+1);
            var strYear=dtStr.substring(0,pos1);
            var strMonth=dtStr.substring(pos1+1,pos2);
            var strDay=dtStr.substring(pos2+1);
            strYr=strYear;
            if (strMonth.charAt(0)=="0" && strMonth.length>1) strMonth=strMonth.substring(1)
            if (strDay.charAt(0)=="0" && strDay.length>1) strDay=strDay.substring(1)
            for (var i = 1; i <= 3; i++) 
            {
                if (strYr.charAt(0)=="0" && strYr.length>1) strYr=strYr.substring(1)
            }
            day=parseInt(strDay);
            month=parseInt(strMonth);
            year=parseInt(strYr);
            if (pos1==-1 || pos2==-1)
            {
                alert("The date format should be : yyyy/mm/dd")
                chk_user_flag="true"
                document.getElementById(txtid).value="";
                document.getElementById(txtid).focus();
                return false;
            }
         }
              
         if (strMonth.length<1 || month<1 || month>12)
         {
            alert("Please enter a valid month")
            chk_user_flag="true"
            document.getElementById(txtid).value="";
            document.getElementById(txtid).focus();
            return false;
         }

         if (strDay.length<1 || day<1 || day>31 || (month==2 && day>daysInFebruary(year)) || day > daysInMonth[month])
         {
            alert("Please enter a valid day")
            chk_user_flag="true"
            document.getElementById(txtid).value="";
            document.getElementById(txtid).focus();
            return false;
         }

         if (strYear.length != 4 || year==0 || year<minYear || year>maxYear)
         {
            alert("Please enter a valid 4 digit year between "+minYear+" and "+maxYear)
            chk_user_flag="true"
            document.getElementById(txtid).value="";
           document.getElementById(txtid).focus();
            return false;
         }
                
         if (dtStr.indexOf(dtCh,pos2+1)!=-1 || isInteger(stripCharsInBag(dtStr, dtCh))==false)
         {
            alert("Please enter a valid date")
            chk_user_flag="true"
           document.getElementById(txtid).value="";
            document.getElementById(txtid).focus();
            return false;
         }

//	    splitval = databasedt.split("#");
//	    var result="false";
//	    for(var k=0; k < splitval.length-1; k++)
//	    {
//	      if(document.getElementById('txtopeningdate').value==splitval[k])
//	      {
//	         result="true";
//	         break; 
//	      }
//	    }
//	    if(result=="false")
//	    {
//	       alert('Please enter start date of Financial Year.')
//	       document.getElementById('txtopeningdate').value="";
//           document.getElementById('txtopeningdate').focus();
//	       return false;
//	    }    
	}
    return false;
}

//function chknumber(event)
//{    
//   if((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==127)||(event.keyCode==8)||(event.keyCode==9)||(event.keyCode==46)||(event.keyCode==43)||(event.keyCode==61))
//   {
//     return true;
//   }
//   else
//   {   
//     return false;
//   }

//}

function numeric(event) {
    var keycode = event.keyCode ? event.keyCode : event.which;
    var browser = navigator.appName;
    if (browser != "Microsoft Internet Explorer") {
        if ((keycode >= 48 && keycode <= 57) || (keycode == 9) || (keycode == 11) || (keycode == 8)) {

            return true;
        }
        else {
            //alert('Please enter numeric numbers only.')
            //keyCode=0;
            return false;
        }
    }
    else {

        if ((keycode >= 48 && keycode <= 57) || (keycode == 9) || (keycode == 11) || (keycode == 8)) {

            return true;
        }
        else {
            // alert('Please enter numeric numbers only.')
            // keyCode=0;
            return false;
        }

    }

}




var dtCh= "/";
var minYear=1900;
var maxYear=2100;
var chk_user_flag="False"
function isInteger(s)
{
  var i;
  for (i = 0; i < s.length; i++){   
  // Check that current character is number.
  var c = s.charAt(i);
  if (((c < "0") || (c > "9"))) return false;
}
// All characters are numbers.
return true;
}

function stripCharsInBag(s, bag)
{
  var i;
  var returnString = "";
  // Search through string's characters one by one.
  // If character is not in bag, append to returnString.
  for (i = 0; i < s.length; i++)
  {   
     var c = s.charAt(i);
     if (bag.indexOf(c) == -1) returnString += c;
  }
  return returnString;
}

function daysInFebruary (year)
{
	// February has 29 days in any year evenly divisible by four,
    // EXCEPT for centurial years which are not also divisible by 400.
    return (((year % 4 == 0) && ( (!(year % 100 == 0)) || (year % 400 == 0))) ? 29 : 28 );
}
function DaysArray(n) 
{
	for (var i = 1; i <= n; i++)
	{
	   this[i] = 31
	   if (i==4 || i==6 || i==9 || i==11) {this[i] = 30}
	   if (i==2) {this[i] = 29}
    } 
   return this
}








function exitclick() {
    if (confirm("Do You Want To Close This Page."))
        window.close();

    return false;
}



//function onclickback() {
//    window.open("tv_vehicle_detail.aspx", '_self')
//    return false;
//}


function bindeptid(jour) {
 
    if (jour != "" || jour != "undefined") {
        ds = tv_fpc_formail.bin_deptid(jour, "", "")
        if (ds.value != "" || ds.value != "null") {
            return ds.value;

        }
        else {
            return returnval;

        }

    }
}


function bindsubeptid(jour, jour1) {
 
    if (jour != "" || jour != "undefined") {
        ds = tv_fpc_formail.bindsubdept(jour, jour1, "", "")
        if (ds.value != "" || ds.value != "null") {
            return ds.value;

        }
        else {
            return returnval;

        }

    }
}


function bindemp_name(jour) {
 
    if (jour != "" || jour != "undefined") {
        ds = tv_fpc_formail.bindemp_name(jour, "", "", "", "", "")
        if (ds.value != "" || ds.value != "null") {
            return ds.value;

        }
        else {
            return returnval;

        }

    }
}

function checkemail(a)
{
    if(trim(document.getElementById(a).value)!="")
    {
        if(ValidEmailCheck(a)==false)
        { 
//            document.getElementById('txtcuste_id').focus();
            return false;
        }

    }

}

function ValidEmailCheck(q)
{

    var str=document.getElementById(q).value;
    
    //ds_exec.Tables[0].Rows.length
    
    var str1=str.split(",");
    for (var b = 0; b <= str1.length - 1; b++)
    {
    var theurl=str1[b];
    
    
    //var psubcd="psubcode1_"+tdid.split('_')[1];
    if (/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+document.getElementById/.test(theurl) || document.getElementById(q).value=="")
    {
      
    }
    else
    {
    alert("Invalid E-mail Id! Please re-enter.")
    document.getElementById(q).focus();
    return false;
    }
    }
}

function chknumber(event)
{
//    if((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==127)||(event.keyCode==8)||(event.keyCode==9))
//    {
//        return true;
//    }
//    else
//    {
//        return false;
//    }
    var key = event.keyCode ? event.keyCode : event.which;
    
            if((key>=48 && key<=57)||(key==127)||(key==8)||(key==9)||(key==46))
            {
                  return true;
            }
            else
            {   
                  return false;
            }
}


function agencyget(compcod,codesbcod)
{
//alert("avi")
 var ds = Agency_CreditAmount.Agency_get(compcod,codesbcod);
 //alert(ds.value.Tables[0].Rows[0].Agency_Name)
// if($('hdncon').value=="sql") 
// {return ds.value.Tables[1].Rows[0].Agency_Name;
// }
// else
 {
return ds.value.Tables[0].Rows[0].Agency_Name;
}
}

function dateenter(event) {
    var key = event.keyCode ? event.keyCode : event.which;
    //if((event.keyCode>=46 && event.keyCode<=57)|| (event.keyCode>=96 && event.keyCode<=105) || (event.keyCode==111) || (event.keyCode==127) || (event.keyCode==191) ||(event.keyCode==8)||(event.keyCode==9) || (event.keyCode==13))

    if ((key >= 46 && key <= 57) || (key == 111) || (key == 127) || (key == 191) || (key == 8) || (key == 9) || (key == 13) || (key >= 96 && key <= 105))

    //if((event.keyCode>=46 && event.keyCode<=57)|| (event.keyCode>=96 && event.keyCode<=105) || (event.keyCode==111) || (event.keyCode==127) || (event.keyCode==191) ||(event.keyCode==8)||(event.keyCode==9) || (event.keyCode==13))
    //if((event.keyCode>=46 && event.keyCode<=57) || (event.keyCode==111) || (event.keyCode==127) || (event.keyCode==191) ||(event.keyCode==8)||(event.keyCode==9) || (event.keyCode==13)|| (event.keyCode>=96 && event.keyCode<=105))
    {
        return true;
    }
    else {
        return false;
    }
}



function chkfrrun()
{
if(document.getElementById('txtqbccode').value=="")
{
alert("Please select agency")
document.getElementById('txtqbccode').focus();
return false;
}
var compname =document.getElementById('hdncompname').value;
var qbccode =document.getElementById('txtqbccode').value;
var date =document.getElementById('txtdate').value;
var balance =document.getElementById('txtbalance').value;
var dateformat = document.getElementById('hiddendateformat').value;


window.open("Advance_Deposit_Receipt.aspx?&compname=" + compname + "&qbccode=" + qbccode + "&date=" + date + "&balance=" + balance + "&dateformat=" + dateformat);
    return false;
}