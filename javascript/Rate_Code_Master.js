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
var hiddentext;



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

    
    document.getElementById('txtratecode').disabled=true;
    document.getElementById('txtratecode').value="";
    document.getElementById('txtratedesc').disabled=true;
    document.getElementById('txtratedesc').value="";
    
    document.getElementById('txtremarks').disabled=true;
    document.getElementById('txtremarks').value="";
    document.getElementById('drpstatus').disabled=true;
   // document.getElementById('drpstatus').value="0";
    
    
   

    
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

  if(document.getElementById('hiddenauto').value==1)
		         {
		          document.getElementById('txtratecode').disabled=true;
                  document.getElementById('txtratedesc').disabled=false;
		          
                  document.getElementById('txtratedesc').focus();
		          
    	          }
		         else
		           {
		           document.getElementById('txtratecode').disabled=false;
                   document.getElementById('txtratecode').focus();
 		           
    	           }
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
    
   // document.getElementById('txtratecode').disabled=false;
   
    document.getElementById('txtratedesc').disabled=false;
     document.getElementById('txtremarks').disabled=false;
 
    document.getElementById('drpstatus').disabled=false;
   


    hiddentext="new";
     modifyduplicacydesc = "";
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

    hiddentext=""
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
    
   document.getElementById('txtratecode').disabled=true;
    document.getElementById('txtratecode').value="";
    document.getElementById('txtratedesc').disabled=true;
    document.getElementById('txtratedesc').value="";
    document.getElementById('txtremarks').disabled=true;
    document.getElementById('txtremarks').value="";
    document.getElementById('drpstatus').disabled=true;
   // document.getElementById('drpstatus').value="ACTIVE";


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

	
	hiddentext=""
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
       
       document.getElementById('txtratecode').disabled=false;
 
    document.getElementById('txtratedesc').disabled=false;
    
         document.getElementById('txtremarks').disabled=false;
   
    document.getElementById('drpstatus').disabled=false;
  
           
         
          
     
        
       if(document.getElementById('txtratecode').value!="")
        { 
            document.getElementById('txtratecode').value="";
        }
    
        if(document.getElementById('txtratedesc').value!="")
        { 
            document.getElementById('txtratedesc').value="";
        }
         if(document.getElementById('txtremarks').value!="")
        { 
            document.getElementById('txtremarks').value="";
        }
        if(document.getElementById('drpstatus').value!="")
        { 
            document.getElementById('drpstatus').value="";
        }
      document.getElementById('drpstatus').value="";
       
        
      


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

        setButtonImages();
         
        document.getElementById('txtratecode').disabled=true;
 
        document.getElementById('txtratedesc').disabled=true;
         
         
         next=0
       
           document.getElementById('txtremarks').disabled=true;
   
    document.getElementById('drpstatus').disabled=true;
     
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


      
                                                            
    
            var ratecode = "'"+trim(document.getElementById('txtratecode').value)+"'";
            ratecode = ratecode.toUpperCase();
           
            
            var ratedesc = "'"+trim(document.getElementById('txtratedesc').value)+"'";
            ratedesc = ratedesc.toUpperCase();
            
            
             var remarks = "'"+trim(document.getElementById('txtremarks').value)+"'";
            remarks = remarks.toUpperCase();
            
            var browser=navigator.appName;
           if(browser!="Microsoft Internet Explorer")
           {
           var status = "''";
           }
           else
           {
            var status = "'"+ document.getElementById('drpstatus').value +"'";
            status = status.toUpperCase();
           }
            
            var compcode = "'"+trim(document.getElementById('hdncompcode').value)+"'";
            //ratecode = ratecode.toUpper();
            
            var createdby = "''";
            var createddt = "''";
            
            var updatedby = "''";
            var updateddate = "''";
       
           

          
          
        
        var datef=trim(document.getElementById('hiddendateformat').value);

       var finalval = ratecode + "$~$" + ratedesc + "$~$" + remarks + "$~$"+ status + "$~$" + compcode + "$~$" + createdby+ "$~$" + createddt + "$~$" + updatedby + "$~$" + updateddate;
        var fi = document.getElementById('tblfields').value.replace("$~$" + tablename, "");
        fi=fi.replace("$~$"+action,"");
        view_colname=fi;
      
        var res = Rate_Code_Master.clie_execute(tablename, fi, finalval, select, datef,"", ""); 
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
     
     
     
     
        if(dsexe.Tables[0].Rows[next].RATE_CODE==null || dsexe.Tables[0].Rows[next].RATE_CODE=="")
	    {
	    document.getElementById('txtratecode').value="";
        }
	    else
	    {
	       
	       document.getElementById('txtratecode').value=dsexe.Tables[0].Rows[next].RATE_CODE
	      
        }


	    if(dsexe.Tables[0].Rows[next].RATE_DESC==null || dsexe.Tables[0].Rows[next].RATE_DESC=="")
	    {
	       document.getElementById('txtratedesc').value="";
        }
	    else
	    {
     	    document.getElementById('txtratedesc').value=dsexe.Tables[0].Rows[next].RATE_DESC
        }
        
        if(dsexe.Tables[0].Rows[next].REMARKS==null || dsexe.Tables[0].Rows[next].REMARKS=="")
	    {
	       document.getElementById('txtremarks').value="";
        }
	    else
	    {
     	    document.getElementById('txtremarks').value=dsexe.Tables[0].Rows[next].REMARKS
        }
        
        if(dsexe.Tables[0].Rows[next].STATUS==null || dsexe.Tables[0].Rows[next].STATUS=="")
	    {
	       document.getElementById('drpstatus').value="";
        }
	    else
	    {
     	    document.getElementById('drpstatus').value=dsexe.Tables[0].Rows[next].STATUS
        }
	
	   
   
       
          

	

	     setButtonImages();
	     flg_req = "no"
	     
	     return false;
    }
    
    else if(dsexe.Tables[0].Rows.length>0)
    {       
    
    
     document.getElementById('hdncompcode').value=dsexe.Tables[0].Rows[next].COMP_CODE
     
     
     
     
         document.getElementById('hdncompcode').value=dsexe.Tables[0].Rows[next].COMP_CODE
     
     
     
     
        if(dsexe.Tables[0].Rows[next].RATE_CODE==null || dsexe.Tables[0].Rows[next].RATE_CODE=="")
	    {
	    document.getElementById('txtratecode').value="";
        }
	    else
	    {
	       
	       document.getElementById('txtratecode').value=dsexe.Tables[0].Rows[next].RATE_CODE
	      
        }


	    if(dsexe.Tables[0].Rows[next].RATE_DESC==null || dsexe.Tables[0].Rows[next].RATE_DESC=="")
	    {
	       document.getElementById('txtratedesc').value="";
        }
	    else
	    {
     	    document.getElementById('txtratedesc').value=dsexe.Tables[0].Rows[next].RATE_DESC
        }
        
         if(dsexe.Tables[0].Rows[next].REMARKS==null || dsexe.Tables[0].Rows[next].REMARKS=="")
	    {
	       document.getElementById('txtremarks').value="";
        }
	    else
	    {
     	    document.getElementById('txtremarks').value=dsexe.Tables[0].Rows[next].REMARKS
        }
        
        if(dsexe.Tables[0].Rows[next].STATUS==null || dsexe.Tables[0].Rows[next].STATUS=="")
	    {
	       document.getElementById('drpstatus').value="";
        }
	    else
	    {
     	    document.getElementById('drpstatus').value=dsexe.Tables[0].Rows[next].STATUS
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


function duplicacy_fordesc()
{

if (trim(document.getElementById('txtratecode').value) == "" && document.getElementById('hiddenauto').value==0) {
            alert("Please Enter Rate ID.!")
            //document.getElementById('txtrate').value = "";
           
            document.getElementById('txtratecode').focus();
            return false;
        }
        
        if (trim(document.getElementById('txtratedesc').value) == "") {
            alert("Please Enter Rate Code.!")
            //document.getElementById('txtrate').value = "";
           
            document.getElementById('txtratedesc').focus();
            return false;
        }


 var tablename = "Rate_Code_Mast";
                    
                    var pcol1 = "RATE_DESC";
                    var pcol1_val = document.getElementById('txtratedesc').value;
                    var pcol2 = "";
                    var pcol2_val = "";
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
                    var res =  Rate_Code_Master.checkduplicacy(tablename, pcol1, pcol1_val, pcol2, pcol2_val, pcol3, pcol3_val, pcol4, pcol4_val, pcol5, pcol5_val, pcol6, pcol6_val, pcol7, pcol7_val, pcol8, pcol8_val, pcol9, pcol9_val, pcol10, pcol10_val, dateformat, extra1, extra2)
                    var res1 = res.value;
                    if(res1.Tables[0].Rows[0].REC_COUNT >= '1')
                    {
                    if(modiflag!=1)
                    {
                    alert('Rate decsription already exists.Please RE-Enter.')
                     document.getElementById('txtratedesc').value = "";
                      document.getElementById('txtratedesc').focus();
                    
                    return false;
                    }
                    else
                    {
                    chkduplicacy();
                    }
                    }
                    else
                    {
                    chkduplicacy();
                    }
                    return false;
}

function chkduplicacy()
{


 if (trim(document.getElementById('txtratecode').value) == "") {
            alert("Please Enter Rate ID.!")
            //document.getElementById('txtrate').value = "";
           
            document.getElementById('txtratecode').focus();
            return false;
        }
        
        if (trim(document.getElementById('txtratedesc').value) == "") {
            alert("Please Enter Rate Code.!")
            //document.getElementById('txtrate').value = "";
           
            document.getElementById('txtratedesc').focus();
            return false;
        }

                    //duplicacy_fordesc();
                    var tablename = "Rate_Code_Mast";
                    
                    var pcol1 = "RATE_CODE";
                    var pcol1_val = document.getElementById('txtratecode').value;
                    var pcol2 = "";
                    var pcol2_val = "";
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
                    Rate_Code_Master.checkduplicacy(tablename, pcol1, pcol1_val, pcol2, pcol2_val, pcol3, pcol3_val, pcol4, pcol4_val, pcol5, pcol5_val, pcol6, pcol6_val, pcol7, pcol7_val, pcol8, pcol8_val, pcol9, pcol9_val, pcol10, pcol10_val, dateformat, extra1, extra2, checkforduplicacy)
                    return false;
}

function checkforduplicacy(res) {


    dsd = res.value;

    if (dsd.Tables[0].Rows.length > 0) {

        var VAL = dsd.Tables[0].Rows[0].REC_COUNT;
        if (VAL >= "1") {
            if (trim(document.getElementById('txtratecode').value) == duplicacyrate) {
                ModifyClass()
                return false;
            }

            else {
                alert('Rate Code already exists.Please RE-Enter.')
               
                document.getElementById('txtratecode').value = "";
                
                
                duplicacyrate = document.getElementById('txtratecode').value;
                document.getElementById('txtratecode').disabled = false;
              
                
                document.getElementById('txtratecode').focus();
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
   //autoornot();
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
          



  if (trim(document.getElementById('txtratecode').value) == "") {
            alert("Please Enter Rate Code.!")
            //document.getElementById('txtrate').value = "";
           
            document.getElementById('txtratecode').focus();
            return false;
        }
        
        if (trim(document.getElementById('txtratedesc').value) == "") {
            alert("Please Enter Rate Description.!")
            //document.getElementById('txtrate').value = "";
           
            document.getElementById('txtratedesc').focus();
            return false;
        }
        
       
              
          
            var ratecode = "'"+trim(document.getElementById('txtratecode').value)+"'";
            ratecode = ratecode.toUpperCase();
           
            
            var ratedesc = "'"+trim(document.getElementById('txtratedesc').value)+"'";
            ratedesc = ratedesc.toUpperCase();
            
            var remarks = "'"+trim(document.getElementById('txtremarks').value)+"'";
            remarks = remarks.toUpperCase();
            
            var status = "'"+trim(document.getElementById('drpstatus').value)+"'";
            status = status.toUpperCase();
            
            var compcode = "'"+trim(document.getElementById('hdncompcode').value)+"'";
            //ratecode = ratecode.toUpper();
            
            var createdby = "'"+trim(document.getElementById('hdnuserid').value)+"'";
            var createddt = "'"+trim(document.getElementById('HDN_server_date').value)+"'";
            
            var updatedby = "''";
            var updateddate = "''";
       
            

          
          
        
        var datef=trim(document.getElementById('hiddendateformat').value);

        var finalvalue = ratecode + "$~$" + ratedesc + "$~$" + remarks + "$~$"+ status + "$~$" + compcode + "$~$" + createdby+ "$~$" + createddt + "$~$" + updatedby + "$~$" + updateddate;
              
       
        var fi=document.getElementById('tblfields').value.replace("$~$"+tablename,"")
        fi=fi.replace("$~$"+action,"")
        
        var result=Rate_Code_Master.Savename(fi,finalvalue,tablename,insert,datef,"","")
//var result=Rate_Code_Master.savedata(fi,finalvalue,tablename,insert,datef)
       
       
        if(result.value=="true")
        {      
           // document.getElementById('txtvehicle_no').value=num;
            alert(" Data saved successfully.!");

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






// ******************************Code For Auto Generation********************

function autoornot()
 {
  if(hiddentext=="new")
  {
  if(document.getElementById('hiddenauto').value==1)
    {
    autochange();
    
    return false;
    }
else
    {
    userdefine();

    return false;
    }
    }
//return false;
}

// Auto generated
// This Function is for check that whether this is case for new or modify

function autochange()
{
if(hiddentext=="new" )
			{
	
            UPPERCASE();
           
           }
            else
            {
            document.getElementById('txtratedesc').value=document.getElementById('txtratedesc').value.toUpperCase();
            	//document.getElementById('hiddenagtypename').value=document.getElementById('txtagencyname').value;	
            }
return false;
}


//auto generated
//this is used for increment in code

function UPPERCASE()
		{
		document.getElementById('txtratedesc').value=document.getElementById('txtratedesc').value.toUpperCase();
			
		document.getElementById('txtratedesc').value=trim(document.getElementById('txtratedesc').value);
		//document.getElementById('hiddenagtypename').value=document.getElementById('txtagencyname').value;	
		  //document.getElementById('txtalias').value=trim(document.getElementById('txtalias').value);
		    document.getElementById('txtremarks').focus();
		  lstr=document.getElementById('txtratedesc').value;
            cstr=lstr.substring(0,1);
            var mstr="";
            			   if(lstr.indexOf(" ")==1)
			            {
			            var leng=lstr.length;
			           mstr= cstr + lstr.substring(2,leng);
			            }
			            else
			            {
			             var leng=lstr.length;
			            mstr=cstr + lstr.substring(1,leng);
			            }
		
		    if(document.getElementById('txtratedesc').value!="")
                {
                 
        
		document.getElementById('txtratedesc').value=document.getElementById('txtratedesc').value.toUpperCase();
		//document.getElementById('hiddenagtypename').value=document.getElementById('txtagencyname').value;	
	    //document.getElementById('txtalias').value=document.getElementById('txtagencyname').value;
		//str=document.getElementById('txtagencyname').value;
		str=mstr;
		Rate_Code_Master.chkratetype(str,fillcall);
		return false;
                }
		       
               
 return false;
		
}

function fillcall(res)
		{
		var ds=res.value;
		
		var newstr;
		
		    if(ds.Tables[0].Rows.length!=0)
		    {
		    alert("This Rate Code has already been assigned !! ");
		    document.getElementById('txtratedesc').value="";
			//document.getElementById('txtagencycode').value="";
			//document.getElementById('txtalias').value="";
		
		    document.getElementById('txtremarks').focus();
    		
		    return false;
		    }
//		
//		        else
//		        {
		                    if(ds.Tables[1].Rows.length==0)
		                        {
		                        newstr=null;
		                        }
		                    else
		                        {
		                         newstr=ds.Tables[1].Rows[0].RATE_CODE;
		                        }
		                    if(newstr !=null )
		                        {
		                        var code=newstr;
		                        //var code=newstr.substr(2,4);
		                        str=str.toUpperCase();
		                        code++;
		                        document.getElementById('txtratecode').value=str.substr(0,2)+ code;
		                         }
		                    else
		                         {
		                            str=str.toUpperCase();
		                          document.getElementById('txtratecode').value=str.substr(0,2)+ "0";
		                          }
		     //}
	return false;
		}
		
function userdefine()
    {
        if(hiddentext=="new")
        {
        
        document.getElementById('txtratecode').disabled=false;
        document.getElementById('txtratedesc').value=document.getElementById('txtratedesc').value.toUpperCase();
        document.getElementById('txtratedesc').value=trim(document.getElementById('txtratedesc').value);
        //document.getElementById('hiddenagtypename').value=document.getElementById('txtagencyname').value;	
//        document.getElementById('txtalias').value=trim(document.getElementById('txtalias').value);
//        document.getElementById('txtalias').value=document.getElementById('txtagencyname').value;
        document.getElementById('txtremarks').focus();
        auto=document.getElementById('hiddenauto').value;
         return false;
        }

//return false;
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

        
        document.getElementById('txtratecode').disabled=true;
 
        document.getElementById('txtratedesc').disabled=false;
        document.getElementById('txtremarks').disabled=false;
 
        document.getElementById('drpstatus').disabled=false;
       
        document.getElementById('btnSave').focus();
        
        duplicacyrate = document.getElementById('txtratecode').value;
       // duplicacydate = document.getElementById('txtdate').value;
        
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
    
           
             var ratecode = "'"+trim(document.getElementById('txtratecode').value)+"'";
            ratecode = ratecode.toUpperCase();
           
            
            var ratedesc = "'"+trim(document.getElementById('txtratedesc').value)+"'";
            ratedesc = ratedesc.toUpperCase();
            
            
            var remarks = "'"+trim(document.getElementById('txtremarks').value)+"'";
            remarks = remarks.toUpperCase();
            
            var status = "'"+trim(document.getElementById('drpstatus').value)+"'";
            status = status.toUpperCase();
            
            var compcode = "'"+trim(document.getElementById('hdncompcode').value)+"'";
            //ratecode = ratecode.toUpper();
            
            var updatedby = "'"+trim(document.getElementById('hdnuserid').value)+"'";
            var updateddate = "'"+trim(document.getElementById('HDN_server_date').value)+"'";
            
            var createdby = "''";
            var createddt = "''";
       
            

          
          
        
        var dateformat=trim(document.getElementById('hiddendateformat').value);

       var finalvalue = ratecode + "$~$" + ratedesc + "$~$" + remarks + "$~$"+ status + "$~$" + compcode + "$~$" + createdby+ "$~$" + createddt + "$~$" + updatedby + "$~$" + updateddate + "$~$";
       var fi=document.getElementById('tblfields').value.replace("$~$"+tablename,"");
         fi = fi.replace("$~$" + action, "");
         fi = fi + "$~$";

    var wherecondition=name;
    
    
       var res10 = Rate_Code_Master.rate_validate(document.getElementById('hdncompcode').value, document.getElementById('txtratecode').value, "", "")
        var ds10 = res10.value;
        var res16 = ds10.Tables[0].Rows[0].res;

        if(ds10.Tables[0].Rows[0].Return_Value == "Y") 
        {
        var res = Rate_Code_Master.tal_modify(fi, finalvalue,tablename,update,modcolname,dateformat,"","");
      
        }

      else 
      {
          alert('Rate Code already in use. Cannot Modify this Rate Code.!')
          clear_all();
          return false;
      }
           
  
    
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
     
     
     
     
        if(dsexe.Tables[0].Rows[next].RATE_CODE==null || dsexe.Tables[0].Rows[next].RATE_CODE=="")
	    {
	    document.getElementById('txtratecode').value="";
        }
	    else
	    {
	       
	       document.getElementById('txtratecode').value=dsexe.Tables[0].Rows[next].RATE_CODE
	      
        }


	    if(dsexe.Tables[0].Rows[next].RATE_DESC==null || dsexe.Tables[0].Rows[next].RATE_DESC=="")
	    {
	       document.getElementById('txtratedesc').value="";
        }
	    else
	    {
     	    document.getElementById('txtratedesc').value=dsexe.Tables[0].Rows[next].RATE_DESC
        }
         if(dsexe.Tables[0].Rows[next].REMARKS==null || dsexe.Tables[0].Rows[next].REMARKS=="")
	    {
	       document.getElementById('txtremarks').value="";
        }
	    else
	    {
     	    document.getElementById('txtremarks').value=dsexe.Tables[0].Rows[next].REMARKS
        }
        
        if(dsexe.Tables[0].Rows[next].STATUS==null || dsexe.Tables[0].Rows[next].STATUS=="")
	    {
	       document.getElementById('drpstatus').value="";
        }
	    else
	    {
     	    document.getElementById('drpstatus').value=dsexe.Tables[0].Rows[next].STATUS
        }
        document.getElementById('btnNew').disabled = true;
        document.getElementById('btnQuery').disabled = false;
        document.getElementById('btnCancel').disabled = false;
        document.getElementById('btnExit').disabled = false;
        document.getElementById('btnSave').disabled = true;
        document.getElementById('btnExecute').disabled = true;
        document.getElementById('btnfirst').disabled = false;
        document.getElementById('btnlast').disabled = false;
        document.getElementById('btnModify').disabled = true;
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
        document.getElementById('btnModify').disabled = true;
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
     
     
     
     
        if(dsexe.Tables[0].Rows[next].RATE_CODE==null || dsexe.Tables[0].Rows[next].RATE_CODE=="")
	    {
	    document.getElementById('txtratecode').value="";
        }
	    else
	    {
	       
	       document.getElementById('txtratecode').value=dsexe.Tables[0].Rows[next].RATE_CODE
	      
        }


	    if(dsexe.Tables[0].Rows[next].RATE_DESC==null || dsexe.Tables[0].Rows[next].RATE_DESC=="")
	    {
	       document.getElementById('txtratedesc').value="";
        }
	    else
	    {
     	    document.getElementById('txtratedesc').value=dsexe.Tables[0].Rows[next].RATE_DESC
        }
         if(dsexe.Tables[0].Rows[next].REMARKS==null || dsexe.Tables[0].Rows[next].REMARKS=="")
	    {
	       document.getElementById('txtremarks').value="";
        }
	    else
	    {
     	    document.getElementById('txtremarks').value=dsexe.Tables[0].Rows[next].REMARKS
        }
        
        if(dsexe.Tables[0].Rows[next].STATUS==null || dsexe.Tables[0].Rows[next].STATUS=="")
	    {
	       document.getElementById('drpstatus').value="";
        }
	    else
	    {
     	    document.getElementById('drpstatus').value=dsexe.Tables[0].Rows[next].STATUS
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
     
     
     
     
        if(dsexe.Tables[0].Rows[next].RATE_CODE==null || dsexe.Tables[0].Rows[next].RATE_CODE=="")
	    {
	    document.getElementById('txtratecode').value="";
        }
	    else
	    {
	       
	       document.getElementById('txtratecode').value=dsexe.Tables[0].Rows[next].RATE_CODE
	      
        }


	    if(dsexe.Tables[0].Rows[next].RATE_DESC==null || dsexe.Tables[0].Rows[next].RATE_DESC=="")
	    {
	       document.getElementById('txtratedesc').value="";
        }
	    else
	    {
     	    document.getElementById('txtratedesc').value=dsexe.Tables[0].Rows[next].RATE_DESC
        }
         if(dsexe.Tables[0].Rows[next].REMARKS==null || dsexe.Tables[0].Rows[next].REMARKS=="")
	    {
	       document.getElementById('txtremarks').value="";
        }
	    else
	    {
     	    document.getElementById('txtremarks').value=dsexe.Tables[0].Rows[next].REMARKS
        }
        
        if(dsexe.Tables[0].Rows[next].STATUS==null || dsexe.Tables[0].Rows[next].STATUS=="")
	    {
	       document.getElementById('drpstatus').value="";
        }
	    else
	    {
     	    document.getElementById('drpstatus').value=dsexe.Tables[0].Rows[next].STATUS
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
     
     
     
     
        if(dsexe.Tables[0].Rows[next].RATE_CODE==null || dsexe.Tables[0].Rows[next].RATE_CODE=="")
	    {
	    document.getElementById('txtratecode').value="";
        }
	    else
	    {
	       
	       document.getElementById('txtratecode').value=dsexe.Tables[0].Rows[next].RATE_CODE
	      
        }


	    if(dsexe.Tables[0].Rows[next].RATE_DESC==null || dsexe.Tables[0].Rows[next].RATE_DESC=="")
	    {
	       document.getElementById('txtratedesc').value="";
        }
	    else
	    {
     	    document.getElementById('txtratedesc').value=dsexe.Tables[0].Rows[next].RATE_DESC
        }
         if(dsexe.Tables[0].Rows[next].REMARKS==null || dsexe.Tables[0].Rows[next].REMARKS=="")
	    {
	       document.getElementById('txtremarks').value="";
        }
	    else
	    {
     	    document.getElementById('txtremarks').value=dsexe.Tables[0].Rows[next].REMARKS
        }
        
        if(dsexe.Tables[0].Rows[next].STATUS==null || dsexe.Tables[0].Rows[next].STATUS=="")
	    {
	       document.getElementById('drpstatus').value="";
        }
	    else
	    {
     	    document.getElementById('drpstatus').value=dsexe.Tables[0].Rows[next].STATUS
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
        delcolname="RATE_CODE$~$";
       
        var ratecode="'"+trim(document.getElementById('txtratecode').value)+"'";
        var ratedesc="'"+document.getElementById('txtratedesc').value+"'"
      
        
         var datef=trim(document.getElementById('hiddendateformat').value);
        
        
        var delcolvalue=ratecode + "$~$";
        
        boolReturn = confirm("Do you want to delete this record?");
        if (boolReturn==1)
        {
         var res10 = Rate_Code_Master.rate_validate(document.getElementById('hdncompcode').value, document.getElementById('txtratecode').value, "", "")
        var ds10 = res10.value;
        var res16 = ds10.Tables[0].Rows[0].res;

        if(ds10.Tables[0].Rows[0].Return_Value == "Y") 
        {
          
          Rate_Code_Master.tal_delete(deltblname,delcolname,delcolvalue,"delete",datef,"","")
        }
        else
        {
         alert('Rate Code already in use. Cannot Delete this Rate Code.!')
          clear_all();
          return false;
        }
        
         
          
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
    
   
             if((a.which=="13" || a.which=="9") && document.activeElement.id=="txtratecode"  && document.getElementById('btnSave').disabled ==false && document.getElementById('btnCancel').disabled == false && document.getElementById('btnExit').disabled == false )
                    {
                        if(document.getElementById('txtratecode').value=="" || document.getElementById('txtratecode').value!="")
                            {
                                if( a.which=="13")
                                    {
                                        if(document.getElementById('txtratecode').value=="")
                                            {
                                                alert('Please  Enter Rate ID.!');
                                                return false;
                                            }
                                            else
                                                {
                                                    document.getElementById('txtratedesc').focus();
                                                    return false;
                                                }
                                    }
                    }
            }  
            
             if((a.which=="13" || a.which=="9") && document.activeElement.id=="txtratedesc"  && document.getElementById('btnSave').disabled ==false && document.getElementById('btnCancel').disabled == false && document.getElementById('btnExit').disabled == false )
                    {
                        if(document.getElementById('txtratedesc').value=="" || document.getElementById('txtratedesc').value!="")
                            {
                                if( a.which=="13")
                                    {
                                        if(document.getElementById('txtratedesc').value=="")
                                            {
                                            
                                                alert('Please  Enter Rate Code.!');
                                                return false;
                                            }
                                            else
                                                {
                                                    document.getElementById('txtremarks').focus();
                                                    return false;
                                                }
                                    }
                    }
            }  
             if((a.which=="13" || a.which=="9") && document.activeElement.id=="txtremarks"  && document.getElementById('btnSave').disabled ==false && document.getElementById('btnCancel').disabled == false && document.getElementById('btnExit').disabled == false )
                    {
                        if(document.getElementById('txtremarks').value=="" || document.getElementById('txtremarks').value!="")
                            {
                                if( a.which=="13")
                                    {
                                        
                                                    document.getElementById('drpstatus').focus();
                                                    return false;
                                                
                                    }
                    }
            }       
         
                 
             else if((a.which=="13" || a.which=="9") && document.activeElement.id=="drpstatus"  && document.getElementById('btnSave').disabled ==false && document.getElementById('btnCancel').disabled == false && document.getElementById('btnExit').disabled == false )
                {
                    if(document.getElementById('drpstatus').value=="" || document.getElementById('drpstatus').value!="")
                        {
                            if( a.which=="13")
                                {
                                  
                                                document.getElementById('btnSave').focus();
                                              
                                                return false;
                                            
                                  }
                         }
                 }   
                 
             
                     
                     

      

                     
            else if (document.activeElement.id=="btnSave")
            {
                duplicacy_fordesc();
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
            
     
               if((a.keyCode=="13" || a.keyCode=="9") && document.activeElement.id=="txtratecode"  && document.getElementById('btnSave').disabled ==false && document.getElementById('btnCancel').disabled == false && document.getElementById('btnExit').disabled == false )
                    {
                        if(document.getElementById('txtratecode').value=="" || document.getElementById('txtratecode').value!="")
                            {
                                if( a.keyCode=="13")
                                    {
                                        if(document.getElementById('txtratecode').value=="")
                                            {
                                               alert('Please  Enter Rate ID.!');
                                                return false;
                                            }
                                            else
                                                {
                                                    document.getElementById('txtratedesc').focus();
                                                    return false;
                                                }
                                    }
                    }
            }       
         
                 
             else if((a.keyCode=="13" || a.keyCode=="9") && document.activeElement.id=="txtratedesc"  && document.getElementById('btnSave').disabled ==false && document.getElementById('btnCancel').disabled == false && document.getElementById('btnExit').disabled == false )
                {
                    if(document.getElementById('txtratedesc').value=="" || document.getElementById('txtratedesc').value!="")
                        {
                            if( a.keyCode=="13")
                                {
                                    if(document.getElementById('txtratedesc').value=="")
                                        {
                                            alert('Please Enter Rate Code.!');
                                            return false;
                                        }
                                        else
                                            {
                                                document.getElementById('txtremarks').focus();
                                              
                                                return false;
                                            }
                                  }
                         }
                 }  
                  if((a.keyCode=="13" || a.keyCode=="9") && document.activeElement.id=="txtremarks"  && document.getElementById('btnSave').disabled ==false && document.getElementById('btnCancel').disabled == false && document.getElementById('btnExit').disabled == false )
                    {
                        if(document.getElementById('txtremarks').value=="" || document.getElementById('txtremarks').value!="")
                            {
                                if( a.keyCode=="13")
                                    {
                                       
                                                    document.getElementById('drpstatus').focus();
                                                    return false;
                                                
                                    }
                    }
            }  
             if((a.keyCode=="13" || a.keyCode=="9") && document.activeElement.id=="drpstatus"  && document.getElementById('btnSave').disabled ==false && document.getElementById('btnCancel').disabled == false && document.getElementById('btnExit').disabled == false )
                    {
                        if(document.getElementById('drpstatus').value=="" || document.getElementById('drpstatus').value!="")
                            {
                                if( a.keyCode=="13")
                                    {
                                        
                                                    document.getElementById('btnSave').focus();
                                                    return false;
                                                
                                    }
                    }
            }   
                 
            
            else if (document.activeElement.id=="btnSave")
            {
                duplicacy_fordesc();
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


function ClientSpecialcharrep(event)
{
//alert(event.keyCode)
var browser=navigator.appName;
//alert(event.keyCode);
 if(browser!="Microsoft Internet Explorer")
 {
    if((event.which>=48 && event.which<=57)|| (event.which==0) ||(event.which==8)|| (event.keyCode==38)|| (event.which==189)||(event.which>=97 && event.which<=122)||( event.which==32)||(event.which>=65 && event.which<=90) || event.which==92 || event.which==43 || event.which==45 || event.keyCode==45)
	{
		return true;
	}
	else
	{
		return false;
	}
 }
 else
 {
	if((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode>=97 && event.keyCode<=122)||(event.keyCode==107|| event.keyCode==109)||(event.keyCode>=65 && event.keyCode<=90) || event.keyCode==92 || event.keyCode==43 || event.keyCode==45|| event.keyCode==32)
	{
		return true;
	}
	else
	{
		return false;
	}
}	
}