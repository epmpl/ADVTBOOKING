// JScript File

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
if(document.activeElement.id=="txtagency")
{
document.getElementById("ddlstatus").focus();
}
}

if(key==27)
{
 if(document.getElementById("divagency").style.display=="block")
{
document.getElementById("divagency").style.display="none";
document.getElementById("lstagency").options.length=0;
document.getElementById("txtagency").focus();
}

}
if(key==113)
{

if(document.activeElement.id=="txtagency")
{
aTag = eval( document.getElementById("txtagency"))
var btag;
var leftpos=0;
var toppos=0;
do
{
aTag = eval(aTag.offsetParent);
leftpos	+= aTag.offsetLeft;
toppos += aTag.offsetTop;
btag=eval(aTag)
} while(aTag.tagName!="BODY" && aTag.tagName!="HTML");

document.getElementById("divagency").style.left=document.getElementById("txtagency").offsetLeft + leftpos+"px";
document.getElementById("divagency").style.top= document.getElementById("txtagency").offsetTop + toppos + "px";//"510px";
document.getElementById("divagency").style.display="block";
agencynew.bindAgency(document.getElementById('hiddencompcode').value,document.getElementById('txtagency').value.toUpperCase(),bindagencyname_callback);
}

    }
}

function bindagencyname_callback(response)
{       
    ds=response.value;
    
    var pkgitem = document.getElementById("lstagency");
    pkgitem.options.length = 0; 
    pkgitem.options[0]=new Option("-Select Agency-","0");
    if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
    {
        pkgitem.options.length = 1; 
        //alert(pkgitem.options.length);
        for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
        {
            pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].Agency_Name+'('+ ds.Tables[0].Rows[i].Agency_Code + ' + ' + ds.Tables[0].Rows[i].SUB_Agency_Code +')',ds.Tables[0].Rows[i].Agency_Code);        
            pkgitem.options.length;       
        }
    }
    document.getElementById('txtagency').value="";
    document.getElementById("lstagency").value="0";
    document.getElementById("lstagency").focus();
    return false;
}


function eventcalling(event)
{

if(event.keyCode==97) 
    event.keyCode= 65;
if(event.keyCode==98) 
    event.keyCode= 66;
if(event.keyCode==99) 
    event.keyCode= 67;
if(event.keyCode==100) 
    event.keyCode= 68;
if(event.keyCode==101) 
    event.keyCode= 69;
if(event.keyCode==102) 
    event.keyCode= 70;
if(event.keyCode==103) 
    event.keyCode= 71;
if(event.keyCode==104) 
    event.keyCode= 72;
if(event.keyCode==105) 
    event.keyCode= 73;
if(event.keyCode==106) 
    event.keyCode= 74;
if(event.keyCode==107) 
    event.keyCode= 75;
if(event.keyCode==108) 
    event.keyCode= 76;
if(event.keyCode==109) 
    event.keyCode= 77;
if(event.keyCode==110) 
    event.keyCode= 78;
if(event.keyCode==111) 
    event.keyCode= 79;
if(event.keyCode==112) 
    event.keyCode= 80;
if(event.keyCode==113) 
    event.keyCode= 81;
if(event.keyCode==114) 
    event.keyCode= 82;
if(event.keyCode==115) 
    event.keyCode= 83;
if(event.keyCode==116) 
    event.keyCode= 84;
if(event.keyCode==117) 
    event.keyCode= 85;
if(event.keyCode==118) 
    event.keyCode= 86;
if(event.keyCode==119) 
    event.keyCode= 87;
if(event.keyCode==120) 
    event.keyCode= 88;
if(event.keyCode==121) 
    event.keyCode= 89;
if(event.keyCode==122) 
    event.keyCode= 90;

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


function trim( value ) 

{
	
	return LTrim(RTrim(value));
	
}
function fillVal(event)
{
var key = event.keyCode ? event.keyCode : event.which;
if(key==13||event.type=='click')
{
    if(document.activeElement.id=="lstagency")
           {
                if(document.getElementById('lstagency').value=="0" )
                {
                    alert("Please select the agency sub code");
                    return false;
                }
                document.getElementById("divagency").style.display="none";
                document.getElementById('hiddenagcode').value=document.getElementById('lstagency').value;
               if(browser!="Microsoft Internet Explorer")
               {
               var agcode=document.getElementById('lstagency').options[document.getElementById('lstagency').selectedIndex].textContent;
               }
               else
                var agcode=document.getElementById('lstagency').options[document.getElementById('lstagency').selectedIndex].innerText;
                var agcode1=agcode.split('(');
                agcode1=agcode1[1].split('+');
                agencycode=trim(agcode1[0]);
                subagencycode=trim(agcode1[1].replace(')',''));
                document.getElementById('txtagencymaincode').value=agencycode;
                document.getElementById('txtagencysubcode').value=subagencycode;
                if(browser!="Microsoft Internet Explorer")
               {
                document.getElementById('txtagency').value=document.getElementById('lstagency').options[document.getElementById('lstagency').selectedIndex].textContent
                
                }else
                document.getElementById('txtagency').value=document.getElementById('lstagency').options[document.getElementById('lstagency').selectedIndex].innerText
                document.getElementById('txtagency').focus();
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

function newclick()
{
document.getElementById('txtagency').disabled=false;
document.getElementById('ddlstatus').disabled=false;
document.getElementById('txtagency').focus();

document.getElementById('btnSave').disabled = false;	
			document.getElementById('btnNew').disabled = true;	
			document.getElementById('btnQuery').disabled=true;
	setButtonImages();
return false;
}

function saveclick()
{
if(document.getElementById('txtagency').value=="")
{
alert("Please fill Agency")
document.getElementById('txtagency').focus();
return false;
}

if(document.getElementById('txtagencymaincode').value==""||document.getElementById('txtagencysubcode').value=="")
{
alert("Please fill Agency By F2")
document.getElementById('txtagency').focus();
return false;
}

if(modiflag==1)
   {
       Modifyaghold();
       return false;
   }

var compcod="'"+document.getElementById('hiddencompcode').value+"'";
var userid="'"+document.getElementById('hiddenuserid').value+"'";
var agcod="'"+document.getElementById('txtagencymaincode').value+"'";
var agsubcod="'"+document.getElementById('txtagencysubcode').value+"'";
var status="'"+"D"+"'";
if(document.getElementById('ddlstatus').value=="0")
{
status="'"+"D"+"'";
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

var finalval = compcod+"$~$"+agcod+"$~$"+agsubcod+"$~$"+userid+"$~$"+status;
var fields=document.getElementById('hdncolnam').value.replace("$~$"+tablename,"")
fields=fields.replace("$~$"+action,"")

var dateformat = trim($('hiddendateformat').value);
var result=agencynew.Savename(fields,finalval,tablename,insert,dateformat,"","")
if(result.value=="true")
     {
    // alert("client name saved at" +csisno);
      alert("Saved Successfully ");
     }
     else
     {
      alert("This Agency already Exist");
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
var agcod="'"+document.getElementById('txtagencymaincode').value+"'";
var agsubcod="'"+document.getElementById('txtagencysubcode').value+"'";
var status="'"+"D"+"'";
if(document.getElementById('ddlstatus').value=="0")
{
status="'"+"D"+"'";
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

     var finalval = compcod+"$~$"+agcod+"$~$"+agsubcod+"$~$"+userid+"$~$"+today+"$~$"+status+"$~$";


var dateformat = trim($('hiddendateformat').value);

    

    var fi = document.getElementById('hdnmod').value.replace("$~$" + tablename, "")
    fi = fi.replace("$~$" + action, "")
    fi = fi + "$~$";


  //   if($('hdncon').value=="sql") 
  //  var res = Ro_Qbc.ro_modify(document.getElementById('hiddencompcode').value,typ,$('hdnagcod').value,$('txtisudt').value,dateformat,$('txtisuno').value,$('txtfrmno').value,$('txtlrono').value,$('ddlstatus').value,document.getElementById('hdnuserid').value,document.getElementById('hidsysdatesql').value)
//else
    var res = agencynew.tal_modify(fi, finalval, tablename, update, modcolname, dateformat, "", "")
   
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
 
 document.getElementById('txtagency').disabled=true;
document.getElementById('txtagencymaincode').disabled=true;
document.getElementById('txtagencysubcode').disabled=true;
document.getElementById('ddlstatus').disabled=true;

document.getElementById('txtagency').value="";
document.getElementById('txtagencymaincode').value="";
document.getElementById('txtagencysubcode').value="";
document.getElementById('ddlstatus').value="0";
setButtonImages();

}

function queryclick()
{
 document.getElementById('txtagency').disabled=false;
document.getElementById('txtagencymaincode').disabled=true;
document.getElementById('txtagencysubcode').disabled=true;
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
    document.getElementById('txtagency').disabled=true;

document.getElementById('ddlstatus').disabled=true;
    
    $('btnModify').focus();
    
     var str=$('hdnexec').value;
var str1=str.split("$~$");

var tablename=str1[str1.length-2];


var action=str1[str1.length-1];
var finalaction=action.split("#");

var cols = document.getElementById('hdnexec').value.replace("$~$" + tablename, "")
    cols = cols.replace("$~$" + action, "")


var insert=finalaction[0];
var update=finalaction[1];
var del=finalaction[2];
var select=finalaction[3];

var compcod="'"+document.getElementById('hiddencompcode').value+"'";
var userid="'"+document.getElementById('hiddenuserid').value+"'";
var agcod="'"+document.getElementById('txtagencymaincode').value+"'";
var agsubcod="'"+document.getElementById('txtagencysubcode').value+"'";
var status="'"+"D"+"'";
if(document.getElementById('ddlstatus').value=="0")
{
status="''";
}
else
status="'"+document.getElementById('ddlstatus').value+"'";
var dateformat="";
var finalval = compcod+"$~$"+agcod+"$~$"+agsubcod+"$~$"+status;

 dateformat = trim($('hiddendateformat').value);

var exect = agencynew.clie_execute(tablename, cols, finalval, select, dateformat, "", "")

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
document.getElementById('txtagencymaincode').value=ds_exec.Tables[0].Rows[0].AG_MAIN_CODE;
document.getElementById('txtagencysubcode').value=ds_exec.Tables[0].Rows[0].AG_SUB_CODE;
document.getElementById('ddlstatus').value=ds_exec.Tables[0].Rows[0].FLAG_TYPE;

var code_subcode=ds_exec.Tables[0].Rows[0].AG_MAIN_CODE+ds_exec.Tables[0].Rows[0].AG_SUB_CODE;
 document.getElementById('txtagency').value=agencyget($('hiddencompcode').value,code_subcode);

            
            document.getElementById('btnlast').disabled = true;


            document.getElementById('btnnext').disabled = true;
            setButtonImages();

        }
        
        else if (ds_exec.Tables[0].Rows.length > 0) {

           //  document.getElementById('txtagnm').value=ds_exec.Tables[0].Rows[0].CODE_SUBCODE;
document.getElementById('txtagencymaincode').value=ds_exec.Tables[0].Rows[0].AG_MAIN_CODE;
document.getElementById('txtagencysubcode').value=ds_exec.Tables[0].Rows[0].AG_SUB_CODE;
document.getElementById('ddlstatus').value=ds_exec.Tables[0].Rows[0].FLAG_TYPE;

var code_subcode=ds_exec.Tables[0].Rows[0].AG_MAIN_CODE+ds_exec.Tables[0].Rows[0].AG_SUB_CODE;
 document.getElementById('txtagency').value=agencyget($('hiddencompcode').value,code_subcode);
        }
        
        else {
            alert("Your search can not produce any result.")
         //   flg_req = "no"
         //   ClearAll()
         clearclick();
            return false;
        }
       document.getElementById('txtagency').disabled=true;
document.getElementById('txtagencymaincode').disabled=true;
document.getElementById('txtagencysubcode').disabled=true;
document.getElementById('ddlstatus').disabled=true;
        
      
        return false;

        
}

function agencyget(compcod,codesbcod)
{
//alert("avi")
 var ds = agencynew.Agency_get(compcod,codesbcod);
 //alert(ds.value.Tables[0].Rows[0].Agency_Name)
 if($('hdncon').value=="sql") 
 {return ds.value.Tables[1].Rows[0].Agency_Name;
 }
 else
 {
return ds.value.Tables[0].Rows[0].AGENCY_NAME;
}
}


function nextclick()
{
 next++;
    if (next > 0) {
        $('btnfirst').disabled = false;
        $('btnlast').disabled = false;
        $('btnprevious').disabled = false;
        $('btnnext').disabled = false;
        $('btnprevious').focus();
        setButtonImages();
       
    }

  //  next++;
    var records = ds_exec.Tables[0].Rows.length;
    if (next <= records && next >= 0) {
        if (ds_exec.Tables[0].Rows.length != next && next != -1) {

document.getElementById('txtagencymaincode').value=ds_exec.Tables[0].Rows[next].AG_MAIN_CODE;
document.getElementById('txtagencysubcode').value=ds_exec.Tables[0].Rows[next].AG_SUB_CODE;
document.getElementById('ddlstatus').value=ds_exec.Tables[0].Rows[next].FLAG_TYPE;

var code_subcode=ds_exec.Tables[0].Rows[next].AG_MAIN_CODE+ds_exec.Tables[0].Rows[next].AG_SUB_CODE;
 document.getElementById('txtagency').value=agencyget($('hiddencompcode').value,code_subcode);
             setButtonImages();
           // return false;
        }
        else {
            $('btnfirst').disabled = false;
            $('btnprevious').disabled = false;
            $('btnnext').disabled = true;
            $('btnlast').disabled = true;
            $('btnNew').disabled = true;
            $('btnprevious').focus();
            setButtonImages();
            
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

        //document.getElementById('btnprevious').focus();
        setButtonImages();
       
        return false;
    }

    if (next != -1 && next >= 0) {
        if (ds_exec.Tables[0].Rows.length != next) {

//           document.getElementById('txtagnm').value=ds_exec.Tables[0].Rows[next].CODE_SUBCODE;
document.getElementById('txtagencymaincode').value=ds_exec.Tables[0].Rows[next].AG_MAIN_CODE;
document.getElementById('txtagencysubcode').value=ds_exec.Tables[0].Rows[next].AG_SUB_CODE;
document.getElementById('ddlstatus').value=ds_exec.Tables[0].Rows[next].FLAG_TYPE;

var code_subcode=ds_exec.Tables[0].Rows[next].AG_MAIN_CODE+ds_exec.Tables[0].Rows[next].AG_SUB_CODE;
 document.getElementById('txtagency').value=agencyget($('hiddencompcode').value,code_subcode);
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
 document.getElementById('txtagencymaincode').value=ds_exec.Tables[0].Rows[next].AG_MAIN_CODE;
document.getElementById('txtagencysubcode').value=ds_exec.Tables[0].Rows[next].AG_SUB_CODE;
document.getElementById('ddlstatus').value=ds_exec.Tables[0].Rows[next].FLAG_TYPE;

var code_subcode=ds_exec.Tables[0].Rows[next].AG_MAIN_CODE+ds_exec.Tables[0].Rows[next].AG_SUB_CODE;
 document.getElementById('txtagency').value=agencyget($('hiddencompcode').value,code_subcode);
        

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
        
 document.getElementById('txtagencymaincode').value=ds_exec.Tables[0].Rows[next].AG_MAIN_CODE;
document.getElementById('txtagencysubcode').value=ds_exec.Tables[0].Rows[next].AG_SUB_CODE;
document.getElementById('ddlstatus').value=ds_exec.Tables[0].Rows[next].FLAG_TYPE;

var code_subcode=ds_exec.Tables[0].Rows[next].AG_MAIN_CODE+ds_exec.Tables[0].Rows[next].AG_SUB_CODE;
 document.getElementById('txtagency').value=agencyget($('hiddencompcode').value,code_subcode);
            


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





  document.getElementById('txtagency').disabled=true;
document.getElementById('txtagencymaincode').disabled=true;
document.getElementById('txtagencysubcode').disabled=true;
document.getElementById('ddlstatus').disabled=false;

 

    $('btnSave').focus();
 
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
var agcod="'"+document.getElementById('txtagencymaincode').value+"'";
var agsubcod="'"+document.getElementById('txtagencysubcode').value+"'";
var status="'"+"D"+"'";
if(document.getElementById('ddlstatus').value=="0")
{
status="'"+"D"+"'";
}
else
status="'"+document.getElementById('ddlstatus').value+"'";


      
    
    var finalval = agcod + "$~$" + agsubcod + "$~$";
    //var finalval = casesecsubgrUnitCode + "$~$" + casemaingrcode + "$~$" + talcode + "$~$" + casesecsubgrchanel + "$~$" + casesecsubgrname + "$~$" + "'" + "" + "'" + "$~$" + casesecsubgrloc + "$~$" + casesecsubgrtypecode + "$~$";
    // var finalval = casesecsubgrUnitCode + "$~$" + casemaingrcode + "$~$" + talcode + "$~$" + casesecsubgrchanel + "$~$" + casesecsubgrname + "$~$" + casesecsubgrloc + "$~$" + casesecsubgrtypecode + "$~$";

    var fi = document.getElementById('hdnwhrname').value.replace("$~$" + tablename, "")
    fi = fi.replace("$~$" + action, "")
    fi = fi + "$~$";


    

    
   
  var    boolReturn = confirm("Are You Sure You Want To Delete This Data??");
    if (boolReturn == 1) {
        var res = agencynew.tal_delete(tablename, fi, finalval, del, "", "", "");
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