// JScript File

var browser=navigator.appName;
function load_function()
{
$('txtcompcode').value=$('hdncompcode').value
$('txtcompname').value=$('hdncompname').value
$('txtcompcode').disabled=true
$('txtcompname').disabled=true
$('txtunitname').disabled=true
click_clear()
return false
}



function fillunit(event)
{ 

     var key=event.keyCode?event.keyCode:event.which;  
    if(key==113) 
    {
       
        if(document.activeElement.id=="txtunitcode")
        {       
        document.getElementById('lstunit').value="";   
        
          var activeid=document.activeElement.id;
          var listboxid="lstunit";
            var objchannel=document.getElementById(listboxid);
            var divid="divunit";     
            
            aTag = eval(document.getElementById(activeid))
			var btag;
			var leftpos=0;
			var toppos=0;        
			do {
				aTag = eval(aTag.offsetParent);
				leftpos	+= aTag.offsetLeft;
				toppos += aTag.offsetTop;
				btag=eval(aTag)
			} while(aTag.tagName!="BODY" && aTag.tagName!="HTML");  
						
            document.getElementById(activeid).style.backgroundColor="#FFFF80";
            document.getElementById(divid).style.display="block";
            document.getElementById(divid).style.top=document.getElementById(activeid).offsetHeight + toppos + "px";
		    document.getElementById(divid).style.left=document.getElementById(activeid).offsetLeft + leftpos+"px";
		    document.getElementById(listboxid).focus();


		    var compcode = $('hdncompcode').value
		  
		    var citycode = ""
		   
		    var dateformat = $('hiddendateformat').value


		    Invoice_cancellation.bindunit(compcode, citycode, dateformat,"","", bindunit_callback)         
        }
       
    }
    if(key==13)
    {
        if(document.activeElement.type=="button" || document.activeElement.type=="submit" || document.activeElement.type=="image")
        {
            key=13;
            return key;

        }
         else
        {
            key=9;
            return key;
            return false;
        }
     }
}


function bindunit_callback(res)
{


     ds =res.value;
//     document.getElementById("lstunit").innerHTML = "";
     if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0)
     {
        var pkgitem = document.getElementById("lstunit");
        pkgitem.options.length = 0;
        pkgitem.options[0]=new Option("-Select Unit-","");
        pkgitem.options.length = 1;
       
        for (var i = 0  ;  i < ds.Tables[0].Rows.length;  ++i)
        {
        pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].Branch_Name,ds.Tables[0].Rows[i].Branch_Code );
        //pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].center,ds.Tables[0].Rows[i].pub_cent_code );
        pkgitem.options.length;
        }
     }     
     document.getElementById("divunit").style.display="block";
     document.getElementById('lstunit').focus();
     return false;
}


function onclickunit(event)
{

var key=event.keyCode?event.keyCode:event.which;
    if(key==13 || event.type=="click")
    {
     
            if(document.activeElement.id=="lstunit")
            {        
          
 
                if(document.getElementById('lstunit').value=="0")
                {
                alert("Please select the Main group");
                return false;
                }     
                var page=document.getElementById('lstunit').value;
                agencycodeglo=page;               
                if(browser!="Microsoft Internet Explorer")
                {
                       
                    for(var k=0;k <= document.getElementById("lstunit").length-1;k++)
                    {                      
                        
                        if(document.getElementById('lstunit').options[k].value==page)
                        {   
                           var abc=document.getElementById('lstunit').options[k].textContent;                        
                           var allvalues=document.getElementById('lstunit').options[k].value;                            
                           var fival = abc.split("(");
                           document.getElementById('txtunitname').value= fival[0];                          
                           document.getElementById("txtunitcode").value=allvalues;                         
                           document.getElementById("txtunitcode").focus();
                           break;
                        }
                    }
                }
                else
                {
                    for(var k=0;k <= document.getElementById("lstunit").length-1;k++)
                    {
                        if(document.getElementById('lstunit').options[k].value==page)
                        {
                            var abc=document.getElementById('lstunit').options[k].innerText;
                            var allvalues=document.getElementById('lstunit').options[k].value;                          
                            var fival = abc.split("(");
                            document.getElementById('txtunitname').value= fival[0];                          
                           document.getElementById("txtunitcode").value=allvalues;                          
                            document.getElementById("txtunitcode").focus();
                           break;
                          }
                    }
                }
                
                document.getElementById("divunit").style.display='none';
                
                return false;
                }
    }
 
    else if (key==27)
    {
    document.getElementById("divunit").style.display='none';
     document.getElementById("txtunitcode").focus();
    }
}
////////////////////////////////f2 function for voucher no


//function fillvoucher(event)
//{ 

//     var key=event.keyCode?event.keyCode:event.which;  
//    if(key==113) 
//    {
//       
//       
//       
//        if(document.activeElement.id=="txtvoucherno")
//        {       
//        document.getElementById('lstvoucherno').value="";   
//        
//          var activeid=document.activeElement.id;
//          var listboxid="lstvoucherno";
//            var objchannel=document.getElementById(listboxid);
//            var divid="divvoucherno";     
//            
//            aTag = eval(document.getElementById(activeid))
//			var btag;
//			var leftpos=0;
//			var toppos=0;        
//			do {
//				aTag = eval(aTag.offsetParent);
//				leftpos	+= aTag.offsetLeft;
//				toppos += aTag.offsetTop;
//				btag=eval(aTag)
//			} while(aTag.tagName!="BODY" && aTag.tagName!="HTML");  
//						
//            document.getElementById(activeid).style.backgroundColor="#FFFF80";
//            document.getElementById(divid).style.display="block";
//            document.getElementById(divid).style.top=document.getElementById(activeid).offsetHeight + toppos + "px";
//		    document.getElementById(divid).style.left=document.getElementById(activeid).offsetLeft + leftpos+"px";        
//            document.getElementById(listboxid).focus();  
//            
//            var compcode=$('hdncompcode').value  
//            var doctype= $('dpdvouchertyp').value 
//            var unitcode=$('txtunitcode').value                  
//            var rcptdt=$('txtvoucherdt').value                  
//            var dateformat=$('hiddendateformat').value  
//            var voucherno=""                
//         Invoice_cancellation.bindbillno(compcode,doctype,unitcode,rcptdt,dateformat,bindvoucher_callback)         
//        }
//       
//    }
//    if(key==13)
//    {
//        if(document.activeElement.type=="button" || document.activeElement.type=="submit" || document.activeElement.type=="image")
//        {
//            key=13;
//            return key;

//        }
//         else
//        {
//            key=9;
//            return key;
//            return false;
//        }
//     }
//}








function fillvoucher(event) {

    var key = event.keyCode ? event.keyCode : event.which;
    if (key == 113) {

        if (document.getElementById("txtunitcode").value == "" || document.getElementById("txtvoucherdt").value == "") {
            alert('Please Enter unit code and Bill Date');
            return false;
        }

        if (document.activeElement.id == "txtvoucherno") {
            document.getElementById('lstvoucherno').value = "";

            var activeid = document.activeElement.id;
            var listboxid = "lstvoucherno";
            var objchannel = document.getElementById(listboxid);
            var divid = "divvoucherno";

            aTag = eval(document.getElementById(activeid))
            var btag;
            var leftpos = 0;
            var toppos = 0;
            do {
                aTag = eval(aTag.offsetParent);
                leftpos += aTag.offsetLeft;
                toppos += aTag.offsetTop;
                btag = eval(aTag)
            } while (aTag.tagName != "BODY" && aTag.tagName != "HTML");

            document.getElementById(activeid).style.backgroundColor = "#FFFF80";
            document.getElementById(divid).style.display = "block";
            document.getElementById(divid).style.top = document.getElementById(activeid).offsetHeight + toppos + "px";
            document.getElementById(divid).style.left = document.getElementById(activeid).offsetLeft + leftpos + "px";
            document.getElementById(listboxid).focus();

            var compcode = $('hdncompcode').value
            var doctype = $('dpdvouchertyp').value
            var unitcode = $('txtunitcode').value
            var rcptdt = $('txtvoucherdt').value
            var dateformat = $('hiddendateformat').value
            var voucherno = ""
            Invoice_cancellation.bindbillno(compcode, doctype, unitcode, rcptdt, dateformat, bindvoucher_callback)
        }

    }
    if (key == 13) {
        if (document.activeElement.type == "button" || document.activeElement.type == "submit" || document.activeElement.type == "image") {
            key = 13;
            return key;

        }
        else {
            key = 9;
            return key;
            return false;
        }
    }
}


function bindvoucher_callback(res)
{


     ds =res.value;
     //document.getElementById("lstvoucherno").innerHTML = "";
     if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0)
     {
        var pkgitem = document.getElementById("lstvoucherno");
        pkgitem.options.length = 0;
        pkgitem.options[0]=new Option("-Select Bill No-","");
        pkgitem.options.length = 1;
            
        for (var i = 0  ;  i < ds.Tables[0].Rows.length;  ++i)
        {
                    
        pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].bilno,ds.Tables[0].Rows[i].bilno );
        pkgitem.options.length;        
        
      }
      }     
     //document.getElementById("divvoucherno").style.display="block";
      $("lstvoucherno").value = "0";
     document.getElementById('lstvoucherno').focus();
     return false;
}


function onclickvoucher(event)
{

var key=event.keyCode?event.keyCode:event.which;
    if(key==13 || event.type=="click")
    {
     
            if(document.activeElement.id=="lstvoucherno")
            {        
          
 
                if(document.getElementById('lstvoucherno').value=="0")
                {
                alert("Please select the Main group");
                return false;
                }     
                var page=document.getElementById('lstvoucherno').value;
                agencycodeglo=page;               
                if(browser!="Microsoft Internet Explorer")
                {
                       
                    for(var k=0;k <= document.getElementById("lstvoucherno").length-1;k++)
                    {                      
                        
                        if(document.getElementById('lstvoucherno').options[k].value==page)
                        {   
                           var abc=document.getElementById('lstvoucherno').options[k].textContent;                        
                           var allvalues=document.getElementById('lstvoucherno').options[k].value; 
                           document.getElementById("txtvoucherno").value=allvalues;                         
                           document.getElementById("txtvoucherno").focus();
                           break;
                        }
                    }
                }
                else
                {
                    for(var k=0;k <= document.getElementById("lstvoucherno").length-1;k++)
                    {
                        if(document.getElementById('lstvoucherno').options[k].value==page)
                        {
                            var abc=document.getElementById('lstvoucherno').options[k].innerText;
                            var allvalues=document.getElementById('lstvoucherno').options[k].value;  
                           document.getElementById("txtvoucherno").value=allvalues;                          
                            document.getElementById("txtvoucherno").focus();
                           break;
                          }
                    }
                }
                
                document.getElementById("divvoucherno").style.display='none';
                
                return false;
                }
    }
 
    else if (key==27)
    {
    document.getElementById("divvoucherno").style.display='none';
     document.getElementById("txtvoucherno").focus();
    }
}

////////////////////////////////f2 function for receipt no


function fillrcptno(event)
{ 

     var key=event.keyCode?event.keyCode:event.which;  
    if(key==113) 
    {
       
        if(document.activeElement.id=="txtrcptno")
        {       
        document.getElementById('lstrcptno').value="";   
        
          var activeid=document.activeElement.id;
          var listboxid="lstrcptno";
            var objchannel=document.getElementById(listboxid);
            var divid="divrcptno";     
            
            aTag = eval(document.getElementById(activeid))
			var btag;
			var leftpos=0;
			var toppos=0;        
			do {
				aTag = eval(aTag.offsetParent);
				leftpos	+= aTag.offsetLeft;
				toppos += aTag.offsetTop;
				btag=eval(aTag)
			} while(aTag.tagName!="BODY" && aTag.tagName!="HTML");  
						
            document.getElementById(activeid).style.backgroundColor="#FFFF80";
            document.getElementById(divid).style.display="block";
            document.getElementById(divid).style.top=document.getElementById(activeid).offsetHeight + toppos + "px";
		    document.getElementById(divid).style.left=document.getElementById(activeid).offsetLeft + leftpos+"px";        
            document.getElementById(listboxid).focus(); 
             var compcode=$('hdncompcode').value  
            var doctype= $('dpdvouchertyp').value 
            var unitcode=$('txtunitcode').value                  
            var rcptdt=$('txtvoucherdt').value                  
            var dateformat=$('hiddendateformat').value  
             var voucherno=$('txtvoucherno').value                  
         Invoice_cancellation.bindbillno(compcode,doctype,unitcode,rcptdt,dateformat,voucherno,bindrcpt_callback)                      
             
        }
       
    }
    if(key==13)
    {
        if(document.activeElement.type=="button" || document.activeElement.type=="submit" || document.activeElement.type=="image")
        {
            key=13;
            return key;

        }
         else
        {
            key=9;
            return key;
            return false;
        }
     }
}


function bindrcpt_callback(res)
{


     ds =res.value;
     document.getElementById("lstrcptno").innerHTML = "";
     if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0)
     {
        var pkgitem = document.getElementById("lstrcptno");
        pkgitem.options.length = 0;
        pkgitem.options[0]=new Option("-Select Receipt No-","");
        pkgitem.options.length = 1;
       
        for (var i = 0  ;  i < ds.Tables[0].Rows.length;  ++i)
        {
        pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].RECPTNO,ds.Tables[0].Rows[i].RECPTNO );
        pkgitem.options.length;
        }
     }     
     document.getElementById("divrcptno").style.display="block";
     document.getElementById('lstrcptno').focus();
     return false;
}


function onclickrcptno(event)
{

var key=event.keyCode?event.keyCode:event.which;
    if(key==13 || event.type=="click")
    {
     
            if(document.activeElement.id=="lstrcptno")
            {        
          
 
                if(document.getElementById('lstrcptno').value=="0")
                {
                alert("Please select the Main group");
                return false;
                }     
                var page=document.getElementById('lstrcptno').value;
                agencycodeglo=page;               
                if(browser!="Microsoft Internet Explorer")
                {
                       
                    for(var k=0;k <= document.getElementById("lstrcptno").length-1;k++)
                    {                      
                        
                        if(document.getElementById('lstrcptno').options[k].value==page)
                        {   
                           var abc=document.getElementById('lstrcptno').options[k].textContent;                        
                           var allvalues=document.getElementById('lstrcptno').options[k].value; 
                           document.getElementById("txtrcptno").value=allvalues;                         
                           document.getElementById("txtrcptno").focus();
                           break;
                        }
                    }
                }
                else
                {
                    for(var k=0;k <= document.getElementById("lstrcptno").length-1;k++)
                    {
                        if(document.getElementById('lstrcptno').options[k].value==page)
                        {
                            var abc=document.getElementById('lstrcptno').options[k].innerText;
                            var allvalues=document.getElementById('lstrcptno').options[k].value;  
                           document.getElementById("txtrcptno").value=allvalues;                          
                            document.getElementById("txtrcptno").focus();
                           break;
                          }
                    }
                }
                
                document.getElementById("divrcptno").style.display='none';
                
                return false;
                }
    }
 
    else if (key==27)
    {
    document.getElementById("divrcptno").style.display='none';
     document.getElementById("txtrcptno").focus();
    }
}

function click_query()
{

if($('txtunitcode').value=="")
{
alert("Please select unit by f2")
$('txtunitcode').value=""
$('txtunitname').value=""
$('txtunitcode').focus()
return false
}
if($('txtunitname').value=="")
{
alert("Please select unit by f2")
$('txtunitcode').value=""
$('txtunitname').value=""
$('txtunitcode').focus()
return false
}
//if($('dpdvouchertyp').value=="")
//{
//alert("Please select voucher type")
//$('dpdvouchertyp').focus()
//return false
//}
if($('txtvoucherdt').value=="")
{
alert("Please select Bill date")
$('txtvoucherdt').focus()
return false
}

if($('txtvoucherno').value=="")
{
alert("Please select Bill Number by f2")
$('txtvoucherno').focus()
return false
}
//if($('txtrcptno').value=="")
//{
//alert("Please select receipt number by f2")
//$('txtrcptno').focus()
//return false
//}



   var compcode=$('hdncompcode').value  
            //var doctype= $('dpdvouchertyp').value 
            var unit=$('txtunitcode').value                  
            var rcptdt=$('txtvoucherdt').value                  
            var dateformat=$('hiddendateformat').value  
             var voucherno=$('txtvoucherno').value  
             var doctype= "" 
//var rcptno=$('txtrcptno').value 
var res=Invoice_cancellation.bindbilldetail(compcode,doctype,unit,rcptdt,dateformat,voucherno)
var ds=res.value
$('txt_billno').value=fndnull(ds.Tables[0].Rows[0].bilno)
$('txt_billdt').value=date_fun(fndnull(ds.Tables[0].Rows[0].bildt))
$('txtunitcd').value=fndnull(ds.Tables[0].Rows[0].unit)
$('txtunitnm').value=fndnull(ds.Tables[0].Rows[0].unit_name)
$('txt_recno').value=fndnull(ds.Tables[0].Rows[0].rcptno)
if(fndnull(ds.Tables[0].Rows[0].rcptdt)!="")
{
$('txt_recdt').value=date_fun(fndnull(ds.Tables[0].Rows[0].rcptdt))
}
else
{
$('txt_recdt').value="";
}

$('txt_rono').value=fndnull(ds.Tables[0].Rows[0].ronum)
if(fndnull(ds.Tables[0].Rows[0].rodate)!="")
{

$('txtrodate').value=date_fun(fndnull(ds.Tables[0].Rows[0].rodate))
}
else
{
$('txtrodate').value="";
}
//$('txtrodate').value=date_fun(fndnull(ds.Tables[0].Rows[0].rodate))
$('txt_client').value=fndnull(ds.Tables[0].Rows[0].clientname)
$('txt_agcl').value=fndnull(ds.Tables[0].Rows[0].name)
$('txtbill').value=fndnull(ds.Tables[0].Rows[0].billamt)
$('txtagcode').value=fndnull(ds.Tables[0].Rows[0].bk_agcode)
$('txtsubcode').value=fndnull(ds.Tables[0].Rows[0].bk_agsubcode)


//$('txt_pay').value=""
return false
}

function date_fun(str_date)
    {
    var final_date=new Date(str_date);

if(final_date!="" && final_date!=null)
{
var month = final_date.getMonth()+1
var day = final_date.getDate()
var year = final_date.getFullYear()

if(day.toString().length<2)
day="0"+day

if(month.toString().length<2)
month="0"+month

       if ($('hiddendateformat').value == "dd/mm/yyyy")
             final_date = day + "/" + month + "/" + year ;

         else if ($('hiddendateformat').value == "mm/dd/yyyy")
             final_date = month + "/" + day + "/" + year;

         else if ($('hiddendateformat').value == "yyyy/mm/dd")
             final_date = year + "/" + month + "/" + day;
     }
         return final_date;
    }
    
function fndnull(val)
{

var ret_val=""
if(val==null || val=="null" || val=="undefined"  || val==undefined)
ret_val=""
else
ret_val=val;
return ret_val;
}


function click_voucherdelete()
{

if($('txt_billno').value=="")
{
alert("Kindly fetch the data to delete")
$('btn_query').focus()
return false
}
if(!confirm("Do you want to delete this entry?"))
{
 return false
}
if($('txtremark').value=="")
{
alert("Please enter remark before deletion of voucher")
$('txtremark').value=""
return false
}
var compcode=$('hdncompcode').value  
           // var doctype= $('dpdvouchertyp').value 
            var unit=$('txtunitcode').value                  
            var rcptdt=$('txtvoucherdt').value                  
            var dateformat=$('hiddendateformat').value  
             var voucherno=$('txtvoucherno').value
             var doctype = "";
             var userid = "";
//var rcptno=$('txtrcptno').value 
var res=Invoice_cancellation.bindbilldelete(compcode,doctype,unit,rcptdt,dateformat,voucherno,userid)
var ds=res.value
if(ds!=null && res!=null && ds.Tables[0]!=null && ds.Tables[0]!=undefined)
{
if( ds.Tables[0].Rows.length>0)
{
alert(ds.Tables[0].Rows[0].Column1)
}
if(ds.Tables[0].Rows[0].Column1.toString().toUpperCase().indexOf("BILL HAS ALREADY ADJUSTED FROM COLLECTION")>=0)
{
if(confirm("Do You want to Untag the bill?"))
{
var compcode=$('hdncompcode').value  
var rcptdt=$('txtvoucherdt').value 
var voucherno=$('txtvoucherno').value                  
 var userid=$('hdnuserid').value                  
           
  var dateformat=$('hiddendateformat').value             
 var extra1= ""; 
  var extra2= "";     
  var res1=Invoice_cancellation.bindbilladjust(compcode,rcptdt,voucherno,userid,dateformat,extra1,extra2)
  var ds1=res1.value; 
  var res3=Invoice_cancellation.bindbilldelete(compcode,doctype,unit,rcptdt,dateformat,voucherno)
var ds3=res3.value
  if(ds1!=null && res1!=null)
  {
  alert('BILL SUCCESSFULLY CANCELED ')
  } 
 
}
else
return false;
}
else
{
//alert('BILL SUCCESSFULLY CANCELED')
click_clear()
return false
}

}
else
{
alert('BILL SUCCESSFULLY CANCELED')
click_clear()
return false
}
}


function click_exit()
{
if(confirm("Do you want to skip this page"))
{
 window.close();
}
return false;
}

function click_clear()
{
$('txtunitcode').value=""
$('txtunitname').value=""
$('dpdvouchertyp').value=""
$('txtvoucherdt').value=""
$('txtvoucherno').value=""
$('txtrcptno').value=""
$('txtremark').value=""

$('txt_billno').value=""
$('txt_billdt').value=""
$('txtunitcd').value=""
$('txtunitnm').value=""
$('txt_recno').value=""
$('txt_recdt').value=""
$('txt_rono').value=""
$('txtrodate').value=""
$('txt_client').value=""
$('txt_agcl').value=""
$('txtbill').value=""
$('txtagcode').value=""
$('txtsubcode').value=""

$('txt_rono').disabled=true
$('txt_agcl').disabled=true
$('txt_billno').disabled=true
$('txt_billdt').disabled=true
$('txtunitcd').disabled=true
//$('txtunitnic').disabled=true
$('txtunitnm').disabled=true
$('txt_recno').disabled=true
$('txt_recdt').disabled=true
$('txt_rono').disabled=true
$('txtrodate').disabled=true
$('txt_client').disabled=true
$('txtbill').disabled=true
$('txtagcode').disabled=true
$('txtsubcode').disabled=true
$('txt_pay').disabled=true
return false
}

function chk_key(event)
{
var key=event.keyCode?event.keyCode:event.which; 

    if(key==8) 
    {
     if(document.activeElement.id=="txtunitcode")
        { 
        $('txtunitname').value=""
         $('txtunitcode').value=""
        }
        
         if(document.activeElement.id=="txtvoucherno")
        { 
        $('txtvoucherno').value=""
       
        }
        
         if(document.activeElement.id=="txtrcptno")
        { 
        $('txtrcptno').value=""
        
        }
   
    }
    return false
}