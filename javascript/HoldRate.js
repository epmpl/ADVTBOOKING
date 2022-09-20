

var browser=navigator.appName;
var modiflag=0;
var ds_exec;
var next;
var buttonvalue = "";
var records;



function tabvalue (event)
{
var key = event.keyCode ? event.keyCode : event.which;
if(key==13)
{
if(document.activeElement.id=="txtratcod")
{
document.getElementById("ddlstatus").focus();
return false;
}
else
if(document.activeElement.id=="ddlstatus")
{
document.getElementById("btnSave").focus();
return false;
}
}

if(key==27)
{
 if(document.getElementById("divratecode").style.display=="block")
{
document.getElementById("divratecode").style.display="none";
document.getElementById("lstratecode").options.length=0;
document.getElementById("txtratcod").focus();
}

}

}


function ratecodef2(event) {
   var key = event.keyCode ? event.keyCode : event.which;
   if(key==113)
   {
  
  
//            if (document.getElementById('txtratecode').value.length <= 2) {
//                alert("Please Enter Minimum 3 Character For Searching.");
//                document.getElementById('txtclient').value = "";
//                return false;
//            }
            colName = "";
            document.getElementById("divratecode").style.display = "block";
            aTag = eval(document.getElementById("txtratcod"))
            var btag;
            var leftpos = 0;
            var toppos = 0;
            do {
                aTag = eval(aTag.offsetParent);
                leftpos += aTag.offsetLeft;
                toppos += aTag.offsetTop;
                btag = eval(aTag)
            } while (aTag.tagName != "BODY" && aTag.tagName != "HTML");
            document.getElementById('divratecode').style.top = document.getElementById("txtratcod").offsetTop + toppos + "px";
            document.getElementById('divratecode').style.left = document.getElementById("txtratcod").offsetLeft + leftpos + "px";
            HoldRate.bindratecod(document.getElementById('hiddencompcode').value, document.getElementById('txtratcod').value.toUpperCase(), bindbookingid_callback);
   
 }
 
 function bindbookingid_callback(response) {
        ds = response.value;
        //document.getElementById('drpretainer').value="";
        var pkgitem = document.getElementById("lstratecode");
        pkgitem.options.length = 0;
        pkgitem.options[0] = new Option("-Select Rate Code-", "0");
        if (ds != null && typeof (ds) == "object" && ds.Tables[0].Rows.length > 0) {
            pkgitem.options.length = 1;
            //alert(pkgitem.options.length);
            for (var i = 0; i < ds.Tables[0].Rows.length; ++i) {
                pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].Rate_Mast_Code , ds.Tables[0].Rows[i].Rate_Mast_Code);
                pkgitem.options.length;
            }
        }

        document.getElementById("lstratecode").value = "0";
        document.getElementById("lstratecode").focus();
        return false;
    }

    }
    
    
    function onclicratecode(event) {
var key = event.keyCode ? event.keyCode : event.which;
        if (key == 13 || event.type == "click") {

            if (document.activeElement.id == "lstratecode") {
                if (document.getElementById('lstratecode').value == "0")
                {
                    alert("Please select rate code");
                    return false;
                }
                document.getElementById("divratecode").style.display = "none";
                var datetime = "";
               
                var page = document.getElementById('lstratecode').value;
                
                agencycodeglo = page;
                 for (var k = 0; k <= document.getElementById("lstratecode").length - 1; k++) {
                     if (document.getElementById('lstratecode').options[k].value == page) {
                         if (browser != "Microsoft Internet Explorer") {
                             var abc = document.getElementById('lstratecode').options[k].textContent;
                         }
                         else {
                             var abc = document.getElementById('lstratecode').options[k].innerText;
                         }

                         var split = abc.split("+");
                         var nameagen = split[0];
                    //     var agencycode = split[1];

                         document.getElementById('txtratcod').value = nameagen;
                        document.getElementById('hdnratcod').value = nameagen;
                         
                         document.getElementById('txtratcod').focus();
                         return false;
                     }
                }
            }
        }

        if (key == 27) {
            document.getElementById("divratecode").style.display = "none";
            document.getElementById('txtratcod').focus();
        }
    }
    
    
    function newclick()
{
document.getElementById('txtratcod').disabled=false;
document.getElementById('ddlstatus').disabled=false;
document.getElementById('txtratcod').focus();

document.getElementById('btnSave').disabled = false;	
			document.getElementById('btnNew').disabled = true;	
			document.getElementById('btnQuery').disabled=true;
	setButtonImages();
return false;
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

function saveclick()
{
if(modiflag==1)
   {
       Modifyaghold();
       return false;
   }
if(document.getElementById('txtratcod').value=="")
{
alert("Please Fill Rate code Agency")
document.getElementById('txtratcod').focus();
return false;
}

if(document.getElementById('hdnratcod').value=="")
{
alert("Please fill Rate code By F2")
document.getElementById('txtratcod').focus();
return false;
}

if(modiflag==1)
   {
       Modifyaghold();
       return false;
   }

var compcod="'"+document.getElementById('hiddencompcode').value+"'";
var userid="'"+document.getElementById('hiddenuserid').value+"'";
var ratcode="'"+document.getElementById('txtratcod').value+"'";

var status="'"+"U"+"'";
if(document.getElementById('ddlstatus').value=="0")
{
status="'"+"U"+"'";
}
else
status="'"+document.getElementById('ddlstatus').value+"'";
var today = new Date();
var dd = today.getDate();
var mm = today.getMonth()+1;
var yyyy = today.getFullYear();
 today ="'"+ mm+'/'+dd+'/'+yyyy+"'";
 
 
 
 var str=$('hdncolnam').value;
var str1=str.split("$~$");

var tablename=str1[str1.length-2];
 var action=str1[str1.length-1];
var finalaction=action.split("#");

var insert=finalaction[0];
var update=finalaction[1];
var del=finalaction[2];
var select=finalaction[3];

var finalval = compcod+"$~$"+ratcode+"$~$"+userid+"$~$"+status;
var fields=document.getElementById('hdncolnam').value.replace("$~$"+tablename,"")
fields=fields.replace("$~$"+action,"")

var dateformat = trim($('hiddendateformat').value);
var result=HoldRate.Savename(fields,finalval,tablename,insert,dateformat,"","")
if(result.value=="true")
     {
    // alert("client name saved at" +csisno);
      alert("Saved Successfully ");
     }
     else
     {
      alert("This Rate already Exist");
     }
     
     clearclick();
    return false;
}

function Modifyaghold()
{
 modiflag = 0;
  //  alert("abc")
    var str = $('hdnmod').value;
    var str1 = str.split("$~$");
    var tablename = str1[str1.length - 2];
    var action = str1[str1.length - 1];
    var finalaction = action.split("#");
    var insert = finalaction[0];
    var update = finalaction[1];
    var del = finalaction[2];
    var select = finalaction[3];

   
    document.getElementById('btnSave').focus();

    var str5 = $('hdnwhrname').value;
    var str6 = str5.split("$~$");
    var modcolname = "";
    var modtblname = str6[str6.length - 1];

var compcod="'"+document.getElementById('hiddencompcode').value+"'";
var userid="'"+document.getElementById('hiddenuserid').value+"'";
var ratcode="'"+document.getElementById('txtratcod').value+"'";

var status="'"+"U"+"'";
if(document.getElementById('ddlstatus').value=="0")
{
status="'"+"U"+"'";
}
else
status="'"+document.getElementById('ddlstatus').value+"'";
var today = new Date();
var dd = today.getDate();
var mm = today.getMonth()+1;
var yyyy = today.getFullYear();
 today ="'"+ mm+'/'+dd+'/'+yyyy+"'";
 
 

 if($('hdncon').value=='sql')
 today ="'"+ trim($('hidsysdatesql').value)+"'";
else
today="'"+document.getElementById('hidsysdate').value+"'";

    modcolname = $('hdnwhrname').value;
    modcolname = modcolname + "$~$"

     var finalval = compcod+"$~$"+ratcode+"$~$"+userid+"$~$"+today+"$~$"+status+"$~$";


var dateformat = trim($('hiddendateformat').value);

    

    var fi = document.getElementById('hdnmod').value.replace("$~$" + tablename, "")
    fi = fi.replace("$~$" + action, "")
    fi = fi + "$~$";


  
    var res = HoldRate.tal_modify(fi, finalval, tablename, update, modcolname, dateformat, "", "")
   
var result = res.value

    if (result != "true") {
        if (result.split("(")[0] == "ORA-00001: unique constraint ") {
            alert('This combination is allready exsist please enter some other combination.');
            return false;
        }
        else {
            alert(result)
            return false;
        }

    }

    alert("Data Updated Successfully ")
    modiflag = "";
      

    $('btnModify').disabled = false;
    $('btnQuery').disabled = false;
    $('btnCancel').disabled = false;
    $('btnExit').disabled = false;
    $('btnDelete').disabled = false;
    $('btnSave').disabled = true;
    $('btnModify').focus();
    setButtonImages();


    

   clearclick();


}


function modifyclick()
{
 modiflag = 1;

    $('btnQuery').disabled = true;
    $('btnSave').disabled = false;
    $('btnfirst').disabled = true;
    $('btnlast').disabled = true;
    $('btnModify').disabled = true;
    $('btnprevious').disabled = true;
    $('btnnext').disabled = true;
    $('btnDelete').disabled = true;
    setButtonImages();





  document.getElementById('txtratcod').disabled=true;

document.getElementById('ddlstatus').disabled=false;

 

    $('btnSave').focus();
 
    return false;

}


function clearclick()
{

document.getElementById('btnNew').disabled=false;
 document.getElementById('btnSave').disabled=true;
 document.getElementById('btnModify').disabled=true;
 document.getElementById('btnQuery').disabled=false;
 document.getElementById('btnCancel').disabled=false;
 document.getElementById('btnExecute').disabled=true;
 document.getElementById('btnfirst').disabled=true;
 document.getElementById('btnprevious').disabled=true;
 document.getElementById('btnnext').disabled=true;
 document.getElementById('btnlast').disabled=true;
 document.getElementById('btnDelete').disabled=true;
 document.getElementById('btnExit').disabled=false;
 
 document.getElementById('btnNew').focus()
 
 document.getElementById('txtratcod').disabled=true;

document.getElementById('ddlstatus').disabled=true;

document.getElementById('txtratcod').value="";
document.getElementById('hdnratcod').value="";

document.getElementById('ddlstatus').value="0";
setButtonImages();

}

function queryclick()
{
 document.getElementById('txtratcod').disabled=false;

document.getElementById('ddlstatus').disabled=false;

 document.getElementById('btnExecute').disabled=false;
 document.getElementById('btnCancel').disabled=false;
 document.getElementById('btnExit').disabled=false;
 document.getElementById('btnNew').disabled=true;
 document.getElementById('btnSave').disabled=true;
 document.getElementById('btnModify').disabled=true;
 document.getElementById('btnQuery').disabled=true;
 document.getElementById('btnfirst').disabled=true;
 document.getElementById('btnprevious').disabled=true;
 document.getElementById('btnnext').disabled=true;
 document.getElementById('btnlast').disabled=true;
 document.getElementById('btnDelete').disabled=true;
 setButtonImages();

document.getElementById('btnExecute').focus();

return false;

}


function executeclick()
{
$('btnNew').disabled = true;
    $('btnCancel').disabled = false;
    $('btnExit').disabled = false;
    $('btnSave').disabled = true;
    $('btnExecute').disabled = true;
    $('btnfirst').disabled = true;
    $('btnlast').disabled = false;
    $('btnModify').disabled = false;
    $('btnprevious').disabled = true;
    $('btnnext').disabled = false;
    $('btnDelete').disabled = false;

    setButtonImages();
    document.getElementById('txtratcod').disabled=true;

document.getElementById('ddlstatus').disabled=true;
    
    $('btnModify').focus();
    
     var str=$('hdnexec').value;
var str1=str.split("$~$");

var tablename=str1[str1.length-2];


var action=str1[str1.length-1];
var finalaction=action.split("#");

var cols = document.getElementById('hdnexec').value.replace("$~$" + tablename, "")
    cols = cols.replace("$~$" + action, "")
cols=cols+"$~$";

var insert=finalaction[0];
var update=finalaction[1];
var del=finalaction[2];
var select=finalaction[3];

var compcod="'"+document.getElementById('hiddencompcode').value+"'";
var userid="'"+document.getElementById('hiddenuserid').value+"'";
var ratecod="'"+document.getElementById('txtratcod').value+"'";

var status="''";
if(document.getElementById('ddlstatus').value=="0")
{
status="''";
}
else
status="'"+document.getElementById('ddlstatus').value+"'";

var finalval = compcod+"$~$"+ratecod+"$~$"+status+"$~$";
var dateformat = trim($('hiddendateformat').value);

var exect = HoldRate.clie_execute(tablename, cols, finalval, select, dateformat, "", "")

if (exect.error != null) { 
            alert(exect.error)
            return false;
        }
        else {
            var result = exect.value
            callback_exec(exect)
            return false;
        }

}

function callback_exec(res) { 
    next = 0;
    
    ds_exec = res.value;
    //record_show = rec_page_val
   // record_show1 = 1
    if (ds_exec == null) {
        alert("Your search can not produce any result.")
 
    clearclick();
        return false;
    }
    if (ds_exec.Tables[0].Rows.length == 1) {
      
      //  document.getElementById('txtagnm').value=ds_exec.Tables[0].Rows[0].CODE_SUBCODE;
document.getElementById('txtratcod').value=ds_exec.Tables[0].Rows[0].RATE_CODE;

document.getElementById('ddlstatus').value=ds_exec.Tables[0].Rows[0].FLAG_TYPE;



            
            document.getElementById('btnlast').disabled = true;


            document.getElementById('btnnext').disabled = true;
            setButtonImages();

        }
        
        else if (ds_exec.Tables[0].Rows.length > 0) {

           //  document.getElementById('txtagnm').value=ds_exec.Tables[0].Rows[0].CODE_SUBCODE;
document.getElementById('txtratcod').value=ds_exec.Tables[0].Rows[0].RATE_CODE;

document.getElementById('ddlstatus').value=ds_exec.Tables[0].Rows[0].FLAG_TYPE;
        }
        
        else {
            alert("Your search can not produce any result.")
         //   flg_req = "no"
         //   ClearAll()
         clearclick();
            return false;
        }
       document.getElementById('txtratcod').disabled=true;

document.getElementById('ddlstatus').disabled=true;
        
      
        return false;

        
}

function nextclick()
{
 next++;
    if (next > 0) {
        $('btnfirst').disabled = false;
        $('btnlast').disabled = false;
        $('btnprevious').disabled = false;
        $('btnnext').disabled = false;
        setButtonImages();
    }

  //  next++;
    var records = ds_exec.Tables[0].Rows.length;
    if (next <= records && next >= 0) {
        if (ds_exec.Tables[0].Rows.length != next && next != -1) {

document.getElementById('txtratcod').value=ds_exec.Tables[0].Rows[next].RATE_CODE;

document.getElementById('ddlstatus').value=ds_exec.Tables[0].Rows[next].FLAG_TYPE;
             setButtonImages();
           // return false;
        }
        else {
            $('btnfirst').disabled = false;
            $('btnprevious').disabled = false;
            $('btnnext').disabled = true;
            $('btnlast').disabled = true;
            $('btnNew').disabled = true;
            setButtonImages();
            $('btnprevious').focus();
            return false;

        }

    }
    else {
        $('btnfirst').disabled = false;
        $('btnprevious').disabled = false;
        $('btnnext').disabled = true;
        $('btnlast').disabled = true;
        $('btnNew').disabled = true;
        setButtonImages();
        return false;
    }
    if (next == records - 1) {
        $('btnfirst').disabled = false;
        $('btnprevious').disabled = false;
        $('btnnext').disabled = true;
        $('btnlast').disabled = true;
        $('btnNew').disabled = true;
        setButtonImages();
        return false;
    }

    return false;
}

function prevclick()
{

    next--;

    var record = ds_exec.Tables[0].Rows.length;
    if (next > record) {
        document.getElementById('btnfirst').disabled = false;
        document.getElementById('btnprevious').disabled = false;
        document.getElementById('btnnext').disabled = true;
        document.getElementById('btnlast').disabled = false;
        document.getElementById('Button4').disabled = false;
        setButtonImages();
       
        return false;
    }

    if (next != -1 && next >= 0) {
        if (ds_exec.Tables[0].Rows.length != next) {

//           document.getElementById('txtagnm').value=ds_exec.Tables[0].Rows[next].CODE_SUBCODE;
document.getElementById('txtratcod').value=ds_exec.Tables[0].Rows[next].RATE_CODE;

document.getElementById('ddlstatus').value=ds_exec.Tables[0].Rows[next].FLAG_TYPE;

            document.getElementById('btnnext').disabled = false;
            document.getElementById('btnlast').disabled = false;
            
            setButtonImages();

        }
    }
    if (next == 0) {
        document.getElementById('btnfirst').disabled = true;
        document.getElementById('btnnext').disabled = false;
        document.getElementById('btnprevious').disabled = true;
        document.getElementById('btnlast').disabled = false;
        $('btnnext').focus();
        setButtonImages();

    }


    return false;

}


function firstclick()
{
 buttonvalue = "";
    buttonvalue = "firstrecords";


     next = 0;


         //   document.getElementById('txtagnm').value=ds_exec.Tables[0].Rows[next].CODE_SUBCODE;
 document.getElementById('txtratcod').value=ds_exec.Tables[0].Rows[next].RATE_CODE;

document.getElementById('ddlstatus').value=ds_exec.Tables[0].Rows[next].FLAG_TYPE;


        

    $('btnfirst').disabled = true;
    $('btnprevious').disabled = true;
    if(ds_exec.Tables[next].Rows.length > 0)
    {
    $('btnlast').disabled = false;
   
    $('btnnext').disabled = false;
    }
    else
    {
    $('btnlast').disabled = true;
   
    $('btnnext').disabled = true;
    }
    $('btnNew').disabled = true;
    setButtonImages();
    $('btnnext').focus();
    return false;
}

function lastclick()
{
 buttonvalue = "lastrecords";
    records = ds_exec.Tables[0].Rows.length;

    next = records - 1;
    records = records - 1;
    if (next >= records && records != -1) {
        
 document.getElementById('txtratcod').value=ds_exec.Tables[0].Rows[next].RATE_CODE;

document.getElementById('ddlstatus').value=ds_exec.Tables[0].Rows[next].FLAG_TYPE;
            


        $('btnfirst').disabled = false;
        $('btnlast').disabled = true;
        $('btnprevious').disabled = false;
        $('btnnext').disabled = true;
        $('btnNew').disabled = true;
        setButtonImages();
        $('btnprevious').focus();
        return false;
    }
    return false;
}


function deleteclick()
{
 var str = $('hdncolnam').value;
    var str1 = str.split("$~$");
    var tablename = str1[str1.length - 2];
    var action = str1[str1.length - 1];
    var finalaction = action.split("#");
    var insert = finalaction[0];
    var update = finalaction[1];
    var del = finalaction[2];
    var select = finalaction[3];


 var str5 = $('hdnwhrname').value;
    var str6 = str5.split("$~$");
    var modcolname = "";
    var modtblname = str6[str6.length - 1];



     modcolname = $('hdnwhrname').value;
    modcolname = modcolname + "$~$";

var compcod="'"+document.getElementById('hiddencompcode').value+"'";
var userid="'"+document.getElementById('hiddenuserid').value+"'";
var ratecod="'"+document.getElementById('txtratcod').value+"'";

var status="'"+"U"+"'";
if(document.getElementById('ddlstatus').value=="0")
{
status="'U'";
}
else
status="'"+document.getElementById('ddlstatus').value+"'";

      
    
    var finalval = ratecod+"$~$";
    //var finalval = casesecsubgrUnitCode + "$~$" + casemaingrcode + "$~$" + talcode + "$~$" + casesecsubgrchanel + "$~$" + casesecsubgrname + "$~$" + "'" + "" + "'" + "$~$" + casesecsubgrloc + "$~$" + casesecsubgrtypecode + "$~$";
    // var finalval = casesecsubgrUnitCode + "$~$" + casemaingrcode + "$~$" + talcode + "$~$" + casesecsubgrchanel + "$~$" + casesecsubgrname + "$~$" + casesecsubgrloc + "$~$" + casesecsubgrtypecode + "$~$";

    var fi = document.getElementById('hdnwhrname').value.replace("$~$" + tablename, "")
    fi = fi.replace("$~$" + action, "")
    fi = fi + "$~$";


    

    
   
  var    boolReturn = confirm("Are You Sure You Want To Delete This Data??");
    if (boolReturn == 1) {
        var res = HoldRate.tal_delete(tablename, fi, finalval, del, "", "", "");
        var result = res.value
        if (result != "true") {
            alert("Data Do Not Delete")
            return false;
        }
        else {
            alert("Data Deleted Successfully")
           clearclick();
            return false;
        }
         }

         clearclick();
    return false;


}



function exitclick()
{
if(confirm('Do You Want To Skip This Page?'))
{
window.close();
return false;
}
return false;
}

function trim( value ) 

{
	
	return LTrim(RTrim(value));
	
}

function LTrim( value ) {
	
	var re = /\s*((\S+\s*)*)/;
	return value.replace(re, "$1");
	
}

// Removes ending whitespaces
function RTrim( value ) {
	
	var re = /((\s*\S+)*)\s*/;
	return value.replace(re, "$1");
	
}